using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reiner_Autoworker.DataStructures
{
    public class Transaction
    {
        public string customerName { get; private set; }        //Customer Name
        public float sum { get; private set; }                  //How much money 
        

        public Transaction(string customerName, string sum)
        {
            this.customerName = customerName;
            this.sum = convertSum(sum);
        }


        protected float convertSum(string sumString)
        {
            float fSum = 0f;
            if (sumString.Contains("."))
            {
                fSum = float.Parse(sumString, CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                fSum = float.Parse(sumString);
            }
            return fSum;
        }
    }

    public class payPalTransaction : Transaction
    {
        public string currency { get; private set; }                //The currency of the transaction
        public string transID { get; private set; }                 //The paypal identification number of the transaction
        public string transType { get; private set; }               //The type of the transaction (soll, haben...)
        public string source { get; private set; }                  //The source of the transaction (ebay, online shop)
        public string invoiceNumber { get; set; } = "";             //The invoice number --> To be filled with data from ebay/online shop
        public float fee { get; private set; } = 0.0F;

        public bool noInvoiceFound { get; set; } = true;         //Must be set false if invoice number could be found
        public bool nameIssueFound { get; set; } = false;        //Shall be set true if name contains more than three words or something like "GBR" or "GmbH"...



        public payPalTransaction(string customerName, string sum, string transID, string currency, string transType, string source) : base(customerName, sum)
        {
            this.transID = transID;
            this.currency = currency;
            this.transType = transType;
            this.source = source;
        }


        public bool checkForFee()
        {
            if (fee == 0.0F)
                return false;
            else
                return true;
        }
    }
}
