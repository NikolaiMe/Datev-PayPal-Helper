using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using Reiner_Autoworker.DataStructures;

namespace Reiner_Autoworker.WorkerClasses
{
    public delegate void ParseCompletedCallBack(List<payPalTransaction> transactionList, int errorCode);
    




    class PayPalParser
    {
        public const int DATA_ERROR = 1, DATA_NOT_FOUND_ERROR = 2;
        private string[] titleArray = new string[] { "Name", "Brutto", "Transaktionscode", "Währung", "Auswirkung auf Guthaben", "Typ", "Gebühr"};
        String fileLocation;
        ParseCompletedCallBack callback;
        int test = 0;

        public PayPalParser(string fileLocation, ParseCompletedCallBack callback)
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
                    int[] dataPositions = new int[7];
                    int size = header.Length;
                    int counter = 0;
                    for (int i = 0; i < 7; i++)
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
                            liste.Add(new payPalTransaction(fields[dataPositions[0]], fields[dataPositions[1]], fields[dataPositions[2]], fields[dataPositions[3]], fields[dataPositions[4]], fields[dataPositions[5]], fields[dataPositions[6]]));
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


}
