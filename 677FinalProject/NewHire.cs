using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace _677FinalProject
{
    class NewHire
    {
        //constructor
        public NewHire()
        {

        }

        //initializes a counter for the number of employees being added
        private int icount = 0;
        //creates a list of employees
        List<Employee> employees = new List<Employee>();

        //this method adds employees to the database
        public void add(List<Employee> nEmployees)
        {
            //ths establishes a connection to the database
            SqlConnection pushn = new SqlConnection();
            DBcnn daterbase = new DBcnn(pushn);
            daterbase.connect(null);
            daterbase.open();
            //this sql statement takes each attribute of employee "e" and pushes them to the database
            foreach (Employee e in nEmployees)
            {
                SqlCommand addin = new SqlCommand("INSERT INTO EMPLOYEES(EMPLOYEE_ID, FIRST_NAME, LAST_NAME, TITLE, PASSWORD, DATE_OF_BIRTH, BACKGROUND, GENDER) VALUES(@employeeID, @firstN, @lastN, @empTitle, @emPassword, @bday, @CBGB, @gander)", pushn);
                addin.Parameters.Add(new SqlParameter("@employeeID", e.employeeID));
                addin.Parameters.Add(new SqlParameter("@firstN", e.firstN));
                addin.Parameters.Add(new SqlParameter("@lastN", e.lastN));
                addin.Parameters.Add(new SqlParameter("@empTitle", e.empTitle));
                addin.Parameters.Add(new SqlParameter("@emPassword", e.emPassword));
                addin.Parameters.Add(new SqlParameter("@bday", e.bday));
                addin.Parameters.Add(new SqlParameter("@CBGB", e.CBGB));
                addin.Parameters.Add(new SqlParameter("@gander", e.gander));
                addin.ExecuteNonQuery();
            }
            daterbase.close();
        }

        //this method gets the largest id number from the database
        public int Counter()
        {
            //creates a counter for the employee id
            int idCounter = 0;

            //this is a stored procedure call for the idCounter
            //ths establishes a connection to the database
            SqlConnection cnn = new SqlConnection();
            DBcnn daterbase = new DBcnn(cnn);
            daterbase.connect(null);
            daterbase.open();


            //if adding an employee id doesnt work, then this is the culprit 
            SqlCommand getID = new SqlCommand(@"SELECT MAX(EMPLOYEE_ID) FROM EMPLOYEES", cnn);
            using(SqlDataReader reader = getID.ExecuteReader())
            {
                while (reader.Read())
                {
                    idCounter = Convert.ToInt32(reader[0].ToString());
                }
            }
            daterbase.close();
            return idCounter++;

        }

        //this method returns a list of employees
        public List<Employee> getJson()
        {
            //all of this can be inserted into a method that can be called when the form initializes
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://art0ou1dii.execute-api.us-east-1.amazonaws.com/dev/resources");
                string sjson = json.ToString();
                sjson = sjson.Substring(0, sjson.Length - 1);
                sjson = sjson.Substring(1, sjson.Length - 1);

                //this determines the number entries in the json that need to be split
                int numArray = sjson.Count(x => x == '}');
                string[] jsonArray = new string[numArray];

                //this creates an array of strings, each array index containing an entry from the json file
                jsonArray = sjson.Split('}');

                //this 

                //this splits each entry at character ',' giving us a new array holding the individual column headings and their
                //data i.e. sex:M
                string[,] dataArray = new string[numArray, 5];
                string[] data = new string[5];


                //this splits each entry in the json into its individual bits of information and assigns them to a new array
                //next it takes that data in the array and assigns it to a multi dimensional array so that all of the 
                //data can be stored and indexed  easily.
                for (int i = 0; i < numArray - 1; i++)
                {
                    //gets rid of an extra comma
                    if (i > 0)
                    {
                        jsonArray[i] = jsonArray[i].Substring(1, jsonArray[i].Length - 1);
                    }
                    //splits
                    data = jsonArray[i].Split(',');

                    for (int j = 0; j <= 4; j++)
                    {
                        //this switch statement eliminates all the junk from the info that we want
                        //each case represents one piece of info 0:first name, 1: last name, 2: gender, 3: DOB, 4: background check status
                        switch (j)
                        {
                            //first name
                            case 0:
                                data[0] = data[0].Substring(0, data[0].Length - 1);
                                data[0] = data[0].Substring(14, data[0].Length - 14);
                                break;
                            //last name
                            case 1:
                                data[1] = data[1].Substring(0, data[1].Length - 1);
                                data[1] = data[1].Substring(12, data[1].Length - 12);
                                break;
                            //gender
                            case 2:
                                data[2] = data[2].Substring(0, data[2].Length - 1);
                                data[2] = data[2].Substring(7, data[2].Length - 7);
                                break;
                            //DOB
                            case 3:
                                data[3] = data[3].Substring(0, data[3].Length - 1);
                                data[3] = data[3].Substring(15, data[3].Length - 15);
                                break;
                            //Background status
                            case 4:
                                data[4] = data[4].Substring(0, data[4].Length - 1);
                                data[4] = data[4].Substring(20, data[4].Length - 20);
                                break;
                        }

                        //saves the information in the data array to the multi-dimensonal dataArray, [json entry,column heading]
                        dataArray[i, j] = data[j];
                    }
                    icount++;
                }

                //this gets the top ID# from the database
                int idCounter = Counter();
                idCounter++;

                //iterates through each employee
                for(int i = 0; i<icount;i++)
                {

                    //creates a new employee and passing each attribute that was saved in the dataArray multidimensional array
                    Employee newGuy = new Employee(dataArray[i, 0], dataArray[i, 1], dataArray[i, 2], dataArray[i, 3], dataArray[i, 4], idCounter, dataArray[i, 1], "New Hire");

                    //adds the employee created above to the list of employees
                    employees.Add(newGuy);

                    idCounter++;
                }

                //returns the list of employees that were brought in from the AWS json file
                return employees;
            }
        }
    }  
}
