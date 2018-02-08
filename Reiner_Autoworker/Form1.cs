using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.InteropServices;
using Reiner_Autoworker.DataStructures;
using Reiner_Autoworker.WorkerClasses;

namespace Reiner_Autoworker
{
    public partial class Form1 : Form
    {

        List<payPalTransaction> datenSatz;

        private string[] tableTitles = new string[] {
            "Name",
            "Umsatz",
            "Währung",
            "Auswirkung auf Guthaben",
            "Ursprung",
            "Gebühr",
            "Rechnungsnummer"
        };

        private DataTable dataTable = new DataTable();


        public void payPalParserCallback(List<payPalTransaction> liste, int errorCode)
        {
            if(errorCode == 0)
            {
                datenSatz = removeUnneccesarryRows(liste);
               /* DataColumn[] columns = new DataColumn[7];
                for (int i = 0; i < 7; i++)
                {
                    columns[i] = new DataColumn(tableTitles[i]);
                }
                dataTable.Columns.AddRange(columns);

                foreach(payPalTransaction trans in liste)
                {
                    string[] fields = new string[] { trans.customerName, trans.sum.ToString(), trans.currency.ToString(), trans.transType.ToString(), trans.transReason.ToString(), trans.fee.ToString() };
                    dataTable.Rows.Add(fields);
                }*/
                Invoke(new Action(() => {
                    this.myTable.AutoGenerateColumns = false;
                    this.myTable.AllowUserToAddRows = false;
                    this.myTable.DataSource = datenSatz;

                    DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                    column1.Name = "customerName";
                    column1.HeaderText = tableTitles[0];
                    column1.DataPropertyName = "customerName";
                    this.myTable.Columns.Add(column1);

                    DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                    column2.Name = "sum";
                    column2.HeaderText = tableTitles[1];
                    column2.DataPropertyName = "sum";
                    this.myTable.Columns.Add(column2);

                    DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
                    column3.Name = "currency";
                    column3.HeaderText = tableTitles[2];
                    column3.DataPropertyName = "currency";
                    this.myTable.Columns.Add(column3);

                    DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
                    column4.Name = "transType";
                    column4.HeaderText = tableTitles[3];
                    column4.DataPropertyName = "transType";
                    this.myTable.Columns.Add(column4);

                    DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
                    column5.Name = "transReason";
                    column5.HeaderText = tableTitles[4];
                    column5.DataPropertyName = "transReason";
                    this.myTable.Columns.Add(column5);

                    DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
                    column6.Name = "fee";
                    column6.HeaderText = tableTitles[5];
                    column6.DataPropertyName = "fee";
                    this.myTable.Columns.Add(column6);

                    DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
                    column7.Name = "invoiceNumber";
                    column7.HeaderText = tableTitles[6];
                    column7.DataPropertyName = "invoiceNumber";
                    this.myTable.Columns.Add(column7);

                }));
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nFehlercode "+ errorCode.ToString());
            }
        }

        public void ebayParserCallback(List<ebayPPTransaction> ebayList, int errorCode)
        {
            if(errorCode == 0)
            {
                foreach (payPalTransaction payPal in datenSatz)
                {
                    foreach(ebayPPTransaction ebay in ebayList)
                    {
                        if(payPal.transID.Equals(ebay.transID))
                        {
                            payPal.invoiceNumber = ebay.invoiceNumber;
                        }
                    }
                }

                Invoke(new Action(() =>
                {
                    myTable.DataSource = null;
                    myTable.DataSource = datenSatz;
                }
                ));

            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nFehlercode " + errorCode.ToString());

            }
        }

        public Form1()
        {
            InitializeComponent();
            //parsData();
            PaypalParseCompletedCallBack callback = payPalParserCallback;
            PayPalParser parser = new PayPalParser(@"C:\Users\nikol\Desktop\Reiner_Testdaten\pp.csv", callback);
            parser.startParsing();

            EbayParseCompletedCallBack eCallback = ebayParserCallback;
            ebayPPParser eParser = new ebayPPParser(@"C:\Users\nikol\Desktop\Reiner_Testdaten\ebay.csv", eCallback);
            eParser.startParsing();
        }

        private List<payPalTransaction> payPalDataStructure = new List<payPalTransaction>();

        private void parsData()
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\nikol\Desktop\Reiner_Testdaten\ebay.csv"))
            {
                DataTable dataTable = new DataTable();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                try
                {
                    string[] header = parser.ReadFields();
                    int size = header.Length;
                    DataColumn[] columns = new DataColumn[size];
                    for (int i = 0; i < size; i++)
                    {
                        columns[i] = new DataColumn(header[i]);
                    }
                    dataTable.Columns.AddRange(columns);

                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        dataTable.Rows.Add(fields);
                        //foreach (string field in fields)
                        //{
                        //TODO: Process field
                        //}
                    }
                    myTable.DataSource = dataTable;

                }
                catch
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nDie gewählte Datei scheint nicht korrekt formatiert zu sein. Bitte korrekte Paypal Datei auswählen!");
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            myTable.Size = new Size (control.Width-40,control.Height-120);

        }


        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private void button1_Click(object sender, EventArgs e)
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow(null, "Unbenannt - Editor");

            // Verify that Calculator is a running process.
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
        }

        private List<payPalTransaction> removeUnneccesarryRows(List<payPalTransaction> list)
        {
            List<payPalTransaction> cleanList = new List<payPalTransaction>();
            foreach (payPalTransaction trans in list)
            {
                if (!(trans.transType == TransTypes.MEMO))
                {
                    cleanList.Add(trans);
                }
            }


            return cleanList;
        }

    }

}
