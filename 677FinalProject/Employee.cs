using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _677FinalProject
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private string gender;
        private string dOB;
        private string backgroundStatus;

        //constructor
        public Employee(string fname, string lname, string gen, string birthday, string bgstat)
        {
            firstName = fname;
            lastName = lname;
            gender = gen;
            dOB = birthday;
            backgroundStatus = bgstat;
        }

        //getter/setter for first name
        public string firstN
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        //getter/setter for last name
        public string lastN
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        //getter/setter for gender
        public string gander
        {
            get
            {
                return gender;
            }
            set
            {
               gender = value;
            }
        }

        //getter/setter for date of birth
        public string bday
        {
            get
            {
                return dOB;
            }
            set
            {
                dOB = value;
            }
        }

        //getter/setter for background status
        public string CBGB
        {
            get
            {
                return backgroundStatus;
            }
            set
            {
                backgroundStatus = value;
            }
        }
    }
}
