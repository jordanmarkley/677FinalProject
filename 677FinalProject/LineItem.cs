using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _677FinalProject
{
    class LineItem
    {
        //Variables
        private int lineItemID;
        private int reqID;
        private int softwareHardwareID;
        private int quantity;
        private decimal itemPrice;
        private decimal lineTotal;

        //Constructor - 5 parameters
        public LineItem(int rID, int softID, int q, decimal p, decimal t)
        {
            lineItemID = Convert.ToInt32(rID.ToString() + softID.ToString());
            reqID = rID;
            softwareHardwareID = softID;
            quantity = q;
            itemPrice = p;
            lineTotal = t;
        }

        //Accessors for variables
        public int LineItemID
        {
            get
            {
                return lineItemID;
            }
            set
            {
                lineItemID = value;
            }
        }

        public int RequestID
        {
            get
            {
                return reqID;
            }
            set
            {
                reqID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return softwareHardwareID;
            }
            set
            {
                softwareHardwareID = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public decimal ItemPrice
        {
            get
            {
                return itemPrice;
            }
            set
            {
                itemPrice = value;
            }
        }

        public decimal LineTotal
        {
            get
            {
                return lineTotal;
            }
            set
            {
                lineTotal = value;
            }
        }
    }
}
