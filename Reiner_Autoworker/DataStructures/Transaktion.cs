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
            if (sumString.Equals("")) return 0f;

            float fSum = 0f;
            if (sumString.Contains("."))
            {
                if (sumString.Contains(","))
                {
                    sumString = sumString.Replace(".", string.Empty);
                    fSum = float.Parse(sumString);
                }
                else
                {
                    fSum = float.Parse(sumString, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            else
            {
                fSum = float.Parse(sumString);
            }
            return fSum;
        }
    }
    public enum TransTypes {SOLL, HABEN, MEMO, ERROR};
    public enum TransReasons {EBAY, ONLINESHOP, REPAYMENT, DEBIT, TRANSLATION, ERROR};

    public class payPalTransaction : Transaction
    {
        private String[] listOfCompanyIndicators = new  String[] { "GmbH", "AG", "GBR", "OHG", "KG", "eG", "se",  };
        
        public string currency { get; private set; }                //The currency of the transaction
        public string transID { get; private set; }                 //The paypal identification number of the transaction
        public TransTypes transType { get; private set; }               //The type of the transaction (soll, haben...)
        public TransReasons transReason { get; private set; }             //The source of the transaction (ebay, online shop)
        public string invoiceNumber { get; set; } = "";             //The invoice number --> To be filled with data from ebay/online shop
        public float fee { get; private set; } = 0.0F;
        public string outputName { get; private set; }
        public DateTime date { get; private set; }

        public bool noInvoiceFound { get; set; } = true;            //Must be set false if invoice number could be found
        public bool nameIssueFound { get; private set; } = false;        //Shall be set true if name contains more than three words or something like "GBR" or "GmbH"...
        public bool foreignCurrencyFound { get; private set; } = false;


        public payPalTransaction(string customerName, string sum, string transID, string currency, string transType, string transReason, string fee, string timeDate) : base(customerName, sum)
        {
            this.transID = transID;

            this.currency = currency;
            if (currency != "EUR") foreignCurrencyFound = true;
            this.date = convertDate(timeDate);

            switch(transType)
            {
                case "Haben":
                    this.transType = TransTypes.HABEN;
                    break;
                case "Soll":
                    this.transType = TransTypes.SOLL;
                    break;
                case "Memo":
                    this.transType = TransTypes.MEMO;
                    break;
                default:
                    this.transType = TransTypes.ERROR;
                    break;
            }

            switch(transReason)
            {
                case "eBay-Auktionszahlung":
                    this.transReason = TransReasons.EBAY;
                    break;
                case "PayPal Express-Zahlung":
                    this.transReason = TransReasons.ONLINESHOP;
                    break;
                case "Allgemeine Abbuchung":
                    this.transReason = TransReasons.DEBIT;
                    break;
                case "Rückzahlung":
                    this.transReason = TransReasons.REPAYMENT;
                    break;
                case "Währungsumrechnung durch Nutzer":
                    this.transReason = TransReasons.TRANSLATION;
                    break;
                default:
                    this.transReason = TransReasons.ERROR;
                    break;
            }

            this.fee = convertSum(fee);

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

        private DateTime convertDate(string timeDate)
        {
            return DateTime.ParseExact(timeDate, "dd.MM.yyyyHH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }

        private bool isNameValid(string name)           // Method checks whether there is more than one Space in the name --> If yes the user have to choose the surname
        {
            int index = 0;
            int counter = 0;
            if (name.Equals("")) return false;
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

    public class ebayPPTransaction : Transaction
    {
        public string transID { get; private set; }                 //The paypal identification number of the transaction
        public string invoiceNumber { get; set; }             //The invoice number --> To be filled with data from ebay/online shop

        public ebayPPTransaction(string name, string sum, string paypalTransactionCode, string invoiceNumber):base(name, sum)
        {
            this.transID = paypalTransactionCode;
            this.invoiceNumber = invoiceNumber;
        }
    }
}
