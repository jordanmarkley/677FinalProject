using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _677FinalProject
{
    class SoftwareHardware
    {
        private int itemID;
        private string description;
        private double itemPrice;

        public SoftwareHardware(int id, string desc, double price)
        {
            itemID = id;
            description = desc;
            itemPrice = price;
        }

        public int ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public double Price
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
    }
}
