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
using System.Reflection;

namespace Reiner_Autoworker
{
    public partial class Form1 : Form
    {

        //------------Variables ----------------------
        List<payPalTransaction> datenSatz;
        private string[] tableTitles = new string[] {
            "Name",
            "Umsatz",
            "Währung",
            "Auswirkung auf Guthaben",
            "Ursprung",
            "Gebühr",
            "Rechnungsnummer",
            "Status der Rechnungsnummer"
        };
        private bool isPaypalAvailable = false;
        private bool isDataTabelInitialized = false;


        // --------------------- Form Event Listener -------------------------------------


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            myTable.Size = new Size(control.Width - 40, control.Height - 170);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            myTable.Size = new Size(control.Width - 40, control.Height - 170);

        }

        private void paypalButton_Click(object sender, EventArgs e)
        {
            isPaypalAvailable = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PayPal Export csv|*.csv";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPayPalData(ofd.FileName);
            }
        }

        private void ebayButton_Click(object sender, EventArgs e)
        {
            if (isPaypalAvailable)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "ebay Export csv|*.csv";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    getEbayData(ofd.FileName);
                }
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Bitte zuerst Paypal Daten laden");

            }
        }

        private void myTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr windowHandler = FindWindow(null, "Unbenannt - Editor");

            // Verify that Calculator is a running process.
            if (windowHandler == IntPtr.Zero)
            {
                MessageBox.Show("Éditor läuft nicht");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.

            foreach(payPalTransaction trans in datenSatz)
            {
                SetForegroundWindow(windowHandler);
                SendKeys.SendWait(trans.sum.ToString());
                if (trans.transType == TransTypes.HABEN)
                {
                    SendKeys.SendWait("\t\t");
                }
                else
                {
                    SendKeys.SendWait("\t{+}\t");
                }
                SendKeys.SendWait("Gegenkonto");
                SendKeys.SendWait("\t");
                SendKeys.SendWait(trans.invoiceNumber);
                SendKeys.SendWait("\t");
                SendKeys.SendWait(trans.date.ToString("dd.MM."));
                SendKeys.SendWait("\t");
                SendKeys.SendWait("Konto");
                SendKeys.SendWait("\t");
                SendKeys.SendWait(trans.outputName);
                SendKeys.SendWait("\n");




            }

        }

        private void onlineShopButton_Click(object sender, EventArgs e)
        {
            if (isPaypalAvailable)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Onlineshop Export xml|*.xml";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    getOnlShopData(ofd.FileName);
                }
            }

            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Bitte zuerst Paypal Daten laden");
            }
        }

        // ---------------- Callbacks ----------------------------

        public void payPalParserCallback(List<payPalTransaction> liste, int errorCode)
        {
            if (errorCode == 0)
            {
                datenSatz = removeUnneccesarryRows(liste);
                if (!isDataTabelInitialized)
                {
                    Invoke(new Action(() =>
                    {
                        this.myTable.AutoGenerateColumns = false;
                        this.myTable.DoubleBuffered(true);
                        this.myTable.AllowUserToAddRows = false;
                        this.myTable.DataSource = datenSatz;

                        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                        column1.Name = "customerName";
                        column1.ReadOnly = true;
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
                        column7.ReadOnly = true;
                        column7.HeaderText = tableTitles[6];
                        column7.DataPropertyName = "invoiceNumber";
                        this.myTable.Columns.Add(column7);

                        DataGridViewImageColumn column8 = new DataGridViewImageColumn();
                        column8.Name = "invoiceNumberState";
                        column8.ReadOnly = true;
                        column8.HeaderText = " ";
                        column8.DataPropertyName = "hint_image";
                        this.myTable.Columns.Add(column8);
                        isDataTabelInitialized = true;
                    }));
                    isDataTabelInitialized = true;
                }
                refreshTable();
                isPaypalAvailable = true;
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nFehlercode " + errorCode.ToString());
            }
        }

        public void ebayParserCallback(List<ebayPPTransaction> ebayList, int errorCode)
        {

            var ebayPPTransactions = datenSatz.Where(trans => trans.transReason == TransReasons.EBAY);
            if (errorCode == 0)
            {
                foreach (payPalTransaction payPal in ebayPPTransactions)
                {
                    foreach (ebayPPTransaction ebay in ebayList)
                    {
                        if (payPal.transID.Equals(ebay.transID))
                        {
                            payPal.invoiceNumber = ebay.invoiceNumber;
                            payPal.invoiceNumberState = InvoiceState.SAFE;
                        }
                    }
                }

                refreshTable();
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nFehlercode " + errorCode.ToString());

            }
        }



        public void onlineShopParserCallback(List<OnlineShopTransaction> onlineShopList, int errorCode)
        {
            if (errorCode == 0)
            {
                var onlineShopPPTransactions = datenSatz.Where(trans => trans.transReason == TransReasons.ONLINESHOP);

                foreach (payPalTransaction trans in onlineShopPPTransactions)
                {
                    //Filtern nach Nachnamen
                    trans.onlineShopUnsureList = onlineShopList.Where(osTrans => trans.outputName.ToUpper().Contains(osTrans.customerName.ToUpper())).ToList();
                    if (trans.onlineShopUnsureList.Count() > 0)
                    {
                        //Filtern nach Betrag
                        var supportList = trans.onlineShopUnsureList.Where(osTrans => trans.sum == osTrans.sum);
                        if (supportList.Count() == 1) // Eindeutige Zuordnung erfolgt
                        {
                            trans.invoiceNumber = supportList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.SAFE;
                            trans.onlineShopUnsureList = null;
                        }
                        else if (supportList.Count() > 1) // Mehrere Möglichkeiten
                        {
                            trans.invoiceNumber = supportList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.MULTIPLE;
                            trans.onlineShopUnsureList = supportList.ToList();
                        }
                        else // Keine passende Summe gefunden
                        {
                            trans.invoiceNumber = trans.onlineShopUnsureList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.UNSURE_SUM;
                        }
                    }
                    else // Kein Passender Name gefunden --> Nochmal suchen ob eine passende Summe existiert
                    {
                        trans.onlineShopUnsureList = onlineShopList.Where(osTrans2 => trans.sum == osTrans2.sum).ToList();
                        if (trans.onlineShopUnsureList.Count > 0)
                        {
                            trans.invoiceNumber = trans.onlineShopUnsureList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.UNSURE_NAME;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Ups, hier ist etwas schief gelaufen:\nFehlercode " + errorCode.ToString());

            }

            refreshTable();
        }



        // -------------Helpful Functions --------------------
        private void refreshTable()
        {
            Invoke(new Action(() =>
            {
                myTable.DataSource = null;
                myTable.DataSource = datenSatz;
            }
            ));
        }

        private void getPayPalData(String fileLocation)
        {
            PaypalParseCompletedCallBack callback = payPalParserCallback;
            PayPalParser parser = new PayPalParser(fileLocation, callback);
            parser.startParsing();
        }

        private void getEbayData(String fileLocation)
        {
            EbayParseCompletedCallBack eCallback = ebayParserCallback;
            ebayPPParser eParser = new ebayPPParser(fileLocation, eCallback);
            eParser.startParsing();
        }

        private void getOnlShopData(String fileLocation)
        {
            OnlineShopParseCompletedCallBack osCallback = onlineShopParserCallback;
            OnlineShopParser osParser = new OnlineShopParser(fileLocation, osCallback);
            osParser.startParsing();
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


        //---------- Write to Datev --> Shall be new class in future ------------

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }



 


}


// ---------------- Performance Improvements ----------------------------

public static class ExtensionMethods
{
    public static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
        Type dgvType = dgv.GetType();
        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(dgv, setting, null);
    }
}
