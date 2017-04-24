using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _677FinalProject
{
    class Request
    {
        //Variables
        private int requestID;
        private List<SoftwareHardware> requestList;
        private decimal subtotalPrice;
        private decimal salesTax;
        private decimal totalPrice;
        private Employee emp;

        //Blank constructor
        public Request()
        {

        }

        //Constructor - 5 parameters
        public Request(int id, List<SoftwareHardware> list, decimal subtotal, decimal tax, decimal total)
        {
            requestID = id;
            requestList = list;
            subtotalPrice = subtotal;
            salesTax = tax;
            totalPrice = total;
        }

        //Getters and setters for variables
        public int RequestID
        {
            get
            {
                return requestID;
            }

            set
            {
                requestID = value;
            }
        }

        public List<SoftwareHardware> ItemList
        {
            get
            {
                return requestList;
            }

            set
            {
                requestList = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotalPrice;
            }

            set
            {
                subtotalPrice = value;
            }
        }

        public decimal SalesTax
        {
            get
            {
                return salesTax;
            }

            set
            {
                salesTax = value;
            }
        }

        public decimal Total
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }
    }
}
