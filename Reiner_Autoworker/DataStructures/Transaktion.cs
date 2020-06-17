using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reiner_Autoworker.DataStructures
{
    public class Transaction
    {
        public string customerName { get; protected set; }        //Customer Name
        public float sum { get; private set; }                  //How much money 
        public string invoiceNumber { get; set; } = "";             //The invoice number --> To be filled with data from ebay/online shop
        public DateTime date { get; set; }

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
    public enum InvoiceState {NO_DATA, SAFE, UNSURE_NAME, UNSURE_SUM, MULTIPLE};

    public class payPalTransaction : Transaction
    {
        private String[] listOfCompanyIndicators = new String[] { "GmbH", "AG", "GBR", "OHG", "KG", "eG", "se" };

        public string currency { get; private set; }                //The currency of the transaction
        public string transID { get; private set; }                 //The paypal identification number of the transaction
        public TransTypes transType { get; private set; }               //The type of the transaction (soll, haben...)
        public TransReasons transReason { get; private set; }             //The source of the transaction (ebay, online shop)
        public float fee { get; private set; } = 0.0F;
        public string outputName { get; private set; }
        public string accountNr { get; set; } = "";
        public string ggAccountNr { get; set; } = "";
        public Bitmap hint_image
        {
            get
            {
                switch (this.invoiceNumberState)
                {
                    case InvoiceState.NO_DATA:
                        return (Bitmap) new Bitmap(Properties.Resources.NO_DATA, new Size(15,15));
                    case InvoiceState.SAFE:
                        return (Bitmap)new Bitmap(Properties.Resources.ALL_GOOD, new Size(15, 15));
                    default:
                        return (Bitmap)new Bitmap(Properties.Resources.WARNING, new Size(16, 15));
                }
            }
        }
        public InvoiceState invoiceNumberState { get; set; } = InvoiceState.NO_DATA;            //Must be set false if invoice number could be found
        public bool nameIssueFound { get; private set; } = false;        //Shall be set true if name contains more than three words or something like "GBR" or "GmbH"...
        public bool foreignCurrencyFound { get; private set; } = false;
        public List<Transaction> invoiceList {get;set;} // If there are several possibilities for Invoices
        public int invoiceIndex { get; set; } = -1;

        public payPalTransaction(string customerName, string sum, string transID, string currency, string transType, string transReason, string fee, string timeDate) : base(customerName, sum)
        {
            this.transID = transID;

            this.currency = currency;
            if (currency != "EUR") foreignCurrencyFound = true;
            this.date = convertDate(timeDate);

            this.invoiceList = new List<Transaction>();

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
        public string taxRate { get; private set; }
        public float salePrice { get; private set; }
        public float shippingPrice { get; private set; }

        public float salePrice19 { get; set; }
        public float salePrice5 { get; set; }
        public float salePrice0 { get; set; }

        public ebayPPTransaction(string name, string sum, string paypalTransactionCode, string invoiceNumber, string paidOn, string taxRate, string salePrice, string shippingPrice) :base(name, sum)
        {
            this.transID = paypalTransactionCode;
            this.invoiceNumber = invoiceNumber;
            this.date = convertDate(paidOn);
            this.taxRate = taxRate;
            this.salePrice = convertSum(salePrice);
            this.shippingPrice = convertSum(shippingPrice);
        }

        private DateTime convertDate(string timeDate)
        {
            if (timeDate != "")
            {
                string date = timeDate.Substring(0, 6) + "20" + timeDate.Substring(6, 2);
                return DateTime.ParseExact(date, "dd.MM.yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                return new DateTime();
            }
        }
    }


    public class OnlineShopTransaction : Transaction
    {
        public string firstName { get; private set; }
        public string fullName { get; private set; }
        public string currency { get; private set; }
        public string type { get; private set; }
        public int errorCode { get; private set; }

        public OnlineShopTransaction(string name, string firstName, string sum, string invoiceNumber , string currency, string type, int errorCode, string date) :base(name, sum)
        {
            this.invoiceNumber = invoiceNumber;
            this.firstName = firstName;
            this.currency = currency;
            this.type = type;
            this.errorCode = errorCode;
            this.fullName = firstName + @" " + name;
            this.date = convertDate(date);
        }


        private DateTime convertDate(string timeDate)
        {
            if ((this.errorCode & 64) == 0)
            {
                return DateTime.ParseExact(timeDate, "yyyy-MM-ddTHH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture);
            }
            else
                return new DateTime();
        }
    }
}
