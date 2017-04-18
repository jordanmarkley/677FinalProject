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
    }
}
