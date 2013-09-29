using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotWforum.Classes
{
    class Transaction
    {
        public String Date { get; set; }
        public String Amount { get; set; }
        public String Type { get; set; }
        
        public Transaction(String date, String amount, String type)
        {
            this.Date = date;
            this.Amount = amount;
            switch (type)
            {
                case "Food":
                    break;
                default:
                    break;
            }
        }
    }
}
