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
        public string customerName { get; protected set; }        //Customer Name
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
        private String[] listOfCompanyIndicators = new  String[] { "GmbH", "AG", "GBR", "OHG", "KG", "eG", "se",  };

        public string currency { get; private set; }                //The currency of the transaction
        public string transID { get; private set; }                 //The paypal identification number of the transaction
        public string transType { get; private set; }               //The type of the transaction (soll, haben...)
        public string source { get; private set; }                  //The source of the transaction (ebay, online shop)
        public string invoiceNumber { get; set; } = "";             //The invoice number --> To be filled with data from ebay/online shop
        public float fee { get; private set; } = 0.0F;
        public string outputName { get; private set; }

        public bool noInvoiceFound { get; set; } = true;         //Must be set false if invoice number could be found
        public bool nameIssueFound { get; set; } = false;        //Shall be set true if name contains more than three words or something like "GBR" or "GmbH"...



        public payPalTransaction(string customerName, string sum, string transID, string currency, string transType, string source) : base(customerName, sum)
        {
            this.transID = transID;
            this.currency = currency;
            this.transType = transType;
            this.source = source;
            if(!checkForCompany(customerName, listOfCompanyIndicators))
            {
                if (isNameValid(customerName))
                {
                    this.outputName = customerName.Substring(customerName.IndexOf(" ")+1);
                }
                else
                {
                    this.outputName = customerName;
                    nameIssueFound = true;
                }
            }
            else
            {
                this.outputName = customerName;
            }

            Console.WriteLine(outputName);
            

        }

        private bool isNameValid(string name)           // Method checks whether there is more than one Space in the name --> If yes the user have to choose the surname
        {
            int index = 0;
            int counter = 0;
            do
            {
                index = name.IndexOf(" ", index+1);
                if (index > 0) counter++;

            } while (index > 0);
            if (counter == 1) return true;
            else return false;
        }

        private bool checkForCompany(String name, String[] listOfIndicators)    // Method checks whether there is an "AG" or "GmbH" at the end of the name
        {
            foreach (String ind in listOfIndicators)
            {
                int i = CultureInfo.InvariantCulture.CompareInfo.IndexOf(name, " " + ind, CompareOptions.IgnoreCase);
                int a = name.Length;
                int b = ind.Length;
                if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(name, " "+ind, CompareOptions.IgnoreCase) == name.Length-ind.Length-1) return true;
            }

            return false;
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
