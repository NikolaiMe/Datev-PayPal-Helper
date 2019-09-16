using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualBasic;
using Reiner_Autoworker.DataStructures;
using System.Xml.Linq;


namespace Reiner_Autoworker.WorkerClasses
{
    public delegate void PaypalParseCompletedCallBack(List<payPalTransaction> transactionList, int errorCode);
    public delegate void EbayParseCompletedCallBack(List<ebayPPTransaction> ebayList, int errorCode);
    public delegate void OnlineShopParseCompletedCallBack(List<OnlineShopTransaction> onlineShopList, int errorCode);
 


    class PayPalParser
    {
        public const int DATA_ERROR = 1, DATA_NOT_FOUND_ERROR = 2;
        private string[] titleArray = new string[] { "Name", "Brutto", "Transaktionscode", "Währung", "Auswirkung auf Guthaben", "Typ", "Gebühr", "Datum", "Uhrzeit" };
        String fileLocation;
        PaypalParseCompletedCallBack callback;

        public PayPalParser(string fileLocation, PaypalParseCompletedCallBack callback)
        {
            this.fileLocation = fileLocation;
            this.callback = callback;
        }

        public void startParsing()
        {
            Thread parsingThread = new Thread(pPPThread);
            parsingThread.Start();
        }

        public void pPPThread()
        {
            List<payPalTransaction> liste = new List<payPalTransaction>();
            bool dataNotFound = false;
            using (TextFieldParser parser = new TextFieldParser(fileLocation))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
               // try
                {
                    string[] header = parser.ReadFields();
                    int[] dataPositions = new int[titleArray.Length];
                    int size = header.Length;
                    int counter = 0;
                    for (int i = 0; i < titleArray.Length; i++)
                    {
                        while (!titleArray[i].Equals(header[counter]))
                        {
                            //int test = String.Compare(titleArray[i], header[counter], false);
                            if (counter < size - 1)
                            {
                                counter++;
                            }
                            else
                            {
                                dataNotFound = true;
                                break;
                            }
                        }
                        if (!dataNotFound)
                        {
                            dataPositions[i] = counter;
                            counter = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!dataNotFound)
                    {
                        while (!parser.EndOfData)
                        {
                            //Process row
                            string[] fields = parser.ReadFields();
                            if (!fields[dataPositions[2]].Equals(""))
                            {
                                liste.Add(new payPalTransaction(fields[dataPositions[0]], fields[dataPositions[1]], fields[dataPositions[2]], fields[dataPositions[3]], fields[dataPositions[4]], fields[dataPositions[5]], fields[dataPositions[6]], fields[dataPositions[7]] + fields[dataPositions[8]]));
                            }
                        }
                        callback(liste, 0);


                    }
                    else
                    {
                        callback(liste, DATA_NOT_FOUND_ERROR);
                    }
                }
                /*catch
                {
                    callback(liste, DATA_ERROR);
                }*/
            
            
        }
        }
    }



    class ebayPPParser
    {
        public const int DATA_ERROR = 1, DATA_NOT_FOUND_ERROR = 2;
        private string[] titleArray = new string[] { "Buyer Fullname", "Total Price", "PayPal Transaction ID", "Invoice Number"};
        String fileLocation;
        EbayParseCompletedCallBack callback;

        public ebayPPParser(string fileLocation, EbayParseCompletedCallBack callback)
        {
            this.fileLocation = fileLocation;
            this.callback = callback;
        }

        public void startParsing()
        {
            Thread parsingThread = new Thread(pEbayPPThread);
            parsingThread.Start();
        }

        private int findFirstNumber(String price)
        {
            if (price.Equals("")) return 0;
    
            int index = 0;
            while ((index < price.Length) && (!((Strings.GetChar(price, index+1)>='0') && (Strings.GetChar(price, index+1) <= '9'))))
            {
                index++;
            }
            return index;
        }

        public void pEbayPPThread()
        {
            List<ebayPPTransaction> liste = new List<ebayPPTransaction>();
            bool dataNotFound = false;
            using (TextFieldParser parser = new TextFieldParser(fileLocation))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                // try
                {
                    string[] header = parser.ReadFields();
                    int[] dataPositions = new int[titleArray.Length];
                    int size = header.Length;
                    int counter = 0;
                    for (int i = 0; i < titleArray.Length; i++)
                    {
                        while (!titleArray[i].Equals(header[counter]))
                        {
                            int test = String.Compare(titleArray[i], header[counter], false);
                            if (counter < size - 1)
                            {
                                counter++;
                            }
                            else
                            {
                                dataNotFound = true;
                                break;
                            }
                        }
                        if (!dataNotFound)
                        {
                            dataPositions[i] = counter;
                            counter = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!dataNotFound)
                    {
                        while (!parser.EndOfData)
                        {
                            //Process row
                            string[] fields = parser.ReadFields();
                            liste.Add(new ebayPPTransaction(fields[dataPositions[0]], fields[dataPositions[1]].Substring(findFirstNumber(fields[dataPositions[1]])), fields[dataPositions[2]], fields[dataPositions[3]]));
                        }

                        callback(liste, 0);


                    }
                    else
                    {
                        callback(liste, DATA_NOT_FOUND_ERROR);
                    }
                }
                /*catch
                {
                    callback(liste, DATA_ERROR);
                }*/


            }
        }
    }

    class OnlineShopParser
    {
        public const int DATA_ERROR = 1, DATA_NOT_FOUND_ERROR = 2;
        private string[] titleArray = new string[] { "FirstName", "LastName", "GrandTotal", "Currency", "InvoiceNumber" };
        String fileLocation;
        OnlineShopParseCompletedCallBack callback;

        public OnlineShopParser(string fileLocation, OnlineShopParseCompletedCallBack callback)
        {
            this.fileLocation = fileLocation;
            this.callback = callback;
        }

        public void startParsing()
        {
            Thread parsingThread = new Thread(pOSParserThread);
            parsingThread.Start();
        }

        public void pOSParserThread()
        {
            try
            {
                List<OnlineShopTransaction> liste = new List<OnlineShopTransaction>();
                XDocument xDoc;
                xDoc = XDocument.Load(fileLocation);

                foreach (XElement invoice in xDoc.Descendants("Order"))
                {
                    int errorCode = 0;
                    String fname;
                    try
                    {
                        fname = invoice.Element("Addresses").Element("BillingAddress").Element("FirstName").Value;
                    }
                    catch
                    {
                        fname = "";
                        errorCode |= 1;
                    }

                    String name;
                    try
                    {
                        name = invoice.Element("Addresses").Element("BillingAddress").Element("LastName").Value;
                    }
                    catch
                    {
                        name = "";
                        errorCode |= 2;
                    }

                    String sum;
                    try
                    {
                        sum = invoice.Element("GrandTotal").Value;
                    }
                    catch
                    {
                        sum = "";
                        errorCode |= 4;
                    }

                    String currency;
                    try
                    {
                        currency = invoice.Element("Currency").Value;
                    }
                    catch
                    {
                        currency = "";
                        errorCode |= 8;
                    }

                    String invoiceNr;
                    try
                    {
                        invoiceNr = invoice.Element("OrderDocuments").Element("Invoices").Element("Invoice").Element("InvoiceNumber").Value;
                    }
                    catch
                    {
                        invoiceNr = "";
                        errorCode |= 16;
                    }

                    String type;
                    try
                    {
                        type = invoice.Element("LineItems").Element("LineItemPayment").Element("Id").Value;
                    }
                    catch
                    {
                        type = "";
                        errorCode |= 32;
                    }

                    String paidOn;
                    try
                    {
                        paidOn = invoice.Element("PaidOn").Value;
                    }
                    catch
                    {
                        paidOn = "";
                        errorCode |= 64;
                    }

                    liste.Add(new OnlineShopTransaction(name, fname, sum, invoiceNr, currency, type, errorCode, paidOn));
                }
                callback(liste.Where(x => (x.errorCode & 16) == 0).ToList(), 0);
            }
            catch
            {
                callback(new List<OnlineShopTransaction>(), DATA_ERROR);
            }
        }
        
    }

}
