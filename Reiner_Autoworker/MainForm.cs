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
    public partial class MainForm : Form
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
            "Kontonr.",
            "GG Kontonr.",
            "Status der Rechnungsnummer"
        };
        private bool isPaypalAvailable = false;
        private bool isDataTabelInitialized = false;

        private const int XPOS_LEFT = 280;
        private const int XPOS_TAB1 = 200;


        private const int LB_DATE_RE_YPOS = LB_SUM_RE_YPOS + 20;
        private const int LB_SUM_RE_YPOS = LB_CUSTOMER_RE_YPOS + 20;
        private const int LB_CUSTOMER_RE_YPOS = CB_INVOICE_YPOS + 30;
        private const int CB_INVOICE_YPOS = LB_INVOICE_YPOS + 20;
        private const int LB_INVOICE_YPOS = LB_TITLE_RE_YPOS + 30;
        private const int LB_TITLE_RE_YPOS = 240;


        private const int LB_GGACCOUNT_YPOS = LB_ACCOUNT_YPOS + 30;
        private const int LB_ACCOUNT_YPOS = LB_ACCOUNT_TITLE_YPOS + 30;
        private const int LB_ACCOUNT_TITLE_YPOS = 410;

        private const int LB_FEE_PP_YPOS = LB_DATE_PP_YPOS + 20;
        private const int LB_DATE_PP_YPOS = LB_SUM_PP_YPOS + 20;
        private const int LB_SUM_PP_YPOS = LB_CUSTOMER_PP_YPOS + 20;
        private const int LB_CUSTOMER_PP_YPOS = LB_TITLE_PP_YPOS + 30;
        private const int LB_TITLE_PP_YPOS = 100;



        private int selectedRowNumber = -1;


        // --------------------- Form Event Listener -------------------------------------


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            myTable.Size = new Size(control.Width - 300, control.Height - 170);

            cb_invoice.Size = new Size(220, 24);
            btn_addinvoice.Size = new Size(21, 21);
            cb_invoice.Location = new Point(control.Width - XPOS_LEFT, CB_INVOICE_YPOS);
            btn_addinvoice.Location = new Point(control.Width - 55, CB_INVOICE_YPOS);
            lb_fx_invoice.Location =new Point(control.Width - XPOS_LEFT, LB_INVOICE_YPOS);

            lb_fx_pp_title.Location = new Point(control.Width - XPOS_LEFT, LB_TITLE_PP_YPOS);
            lb_fx_pp_customer.Location = new Point(control.Width - XPOS_LEFT, LB_CUSTOMER_PP_YPOS);
            lb_fx_pp_date.Location = new Point(control.Width - XPOS_LEFT, LB_DATE_PP_YPOS);
            lb_fx_pp_sum.Location = new Point(control.Width - XPOS_LEFT, LB_SUM_PP_YPOS);
            lb_fx_pp_fee.Location = new Point(control.Width - XPOS_LEFT, LB_FEE_PP_YPOS);

            lb_pp_customer.Location = new Point(control.Width - XPOS_TAB1, LB_CUSTOMER_PP_YPOS);
            lb_pp_date.Location = new Point(control.Width - XPOS_TAB1, LB_DATE_PP_YPOS);
            lb_pp_sum.Location = new Point(control.Width - XPOS_TAB1, LB_SUM_PP_YPOS);
            lb_pp_fee.Location = new Point(control.Width - XPOS_TAB1, LB_FEE_PP_YPOS);

            lb_fx_re_title.Location = new Point(control.Width - XPOS_LEFT, LB_TITLE_RE_YPOS);
            lb_fx_re_customer.Location = new Point(control.Width - XPOS_LEFT, LB_CUSTOMER_RE_YPOS);
            lb_fx_re_date.Location = new Point(control.Width - XPOS_LEFT, LB_DATE_RE_YPOS);
            lb_fx_re_sum.Location = new Point(control.Width - XPOS_LEFT, LB_SUM_RE_YPOS);

            lb_re_customer.Location = new Point(control.Width - XPOS_TAB1, LB_CUSTOMER_RE_YPOS);
            lb_re_date.Location = new Point(control.Width - XPOS_TAB1, LB_DATE_RE_YPOS);
            lb_re_sum.Location = new Point(control.Width - XPOS_TAB1, LB_SUM_RE_YPOS);

            lb_fx_account_title.Location = new Point(control.Width - XPOS_LEFT, LB_ACCOUNT_TITLE_YPOS);
            lb_fx_account.Location = new Point(control.Width - XPOS_LEFT, LB_ACCOUNT_YPOS);
            lb_fx_ggaccount.Location = new Point(control.Width - XPOS_LEFT, LB_GGACCOUNT_YPOS);
            tb_account.Location = new Point(control.Width - XPOS_TAB1, LB_ACCOUNT_YPOS);
            tb_ggaccount.Location = new Point(control.Width - XPOS_TAB1, LB_GGACCOUNT_YPOS);

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            myTable.Size = new Size(control.Width - 300, control.Height - 170);
            cb_invoice.Location = new Point(control.Width - XPOS_LEFT, CB_INVOICE_YPOS);
            btn_addinvoice.Location = new Point(control.Width - 55, CB_INVOICE_YPOS);
            lb_fx_invoice.Location = new Point(control.Width - XPOS_LEFT, LB_INVOICE_YPOS);
            lb_fx_pp_title.Location = new Point(control.Width - XPOS_LEFT, LB_TITLE_PP_YPOS);
            lb_fx_pp_customer.Location = new Point(control.Width - XPOS_LEFT, LB_CUSTOMER_PP_YPOS);
            lb_fx_pp_date.Location = new Point(control.Width - XPOS_LEFT, LB_DATE_PP_YPOS);
            lb_fx_pp_sum.Location = new Point(control.Width - XPOS_LEFT, LB_SUM_PP_YPOS);
            lb_fx_pp_fee.Location = new Point(control.Width - XPOS_LEFT, LB_FEE_PP_YPOS);

            lb_pp_customer.Location = new Point(control.Width - XPOS_TAB1, LB_CUSTOMER_PP_YPOS);
            lb_pp_date.Location = new Point(control.Width - XPOS_TAB1, LB_DATE_PP_YPOS);
            lb_pp_sum.Location = new Point(control.Width - XPOS_TAB1, LB_SUM_PP_YPOS);
            lb_pp_fee.Location = new Point(control.Width - XPOS_TAB1, LB_FEE_PP_YPOS);

            lb_fx_account_title.Location = new Point(control.Width - XPOS_LEFT, LB_ACCOUNT_TITLE_YPOS);
            tb_account.Location = new Point(control.Width - XPOS_TAB1, LB_ACCOUNT_YPOS);
            tb_ggaccount.Location = new Point(control.Width - XPOS_TAB1, LB_GGACCOUNT_YPOS);
            lb_fx_account.Location = new Point(control.Width - XPOS_LEFT, LB_ACCOUNT_YPOS);
            lb_fx_ggaccount.Location = new Point(control.Width - XPOS_LEFT, LB_GGACCOUNT_YPOS);

            lb_fx_re_title.Location = new Point(control.Width - XPOS_LEFT, LB_TITLE_RE_YPOS);
            lb_fx_re_customer.Location = new Point(control.Width - XPOS_LEFT, LB_CUSTOMER_RE_YPOS);
            lb_fx_re_date.Location = new Point(control.Width - XPOS_LEFT, LB_DATE_RE_YPOS);
            lb_fx_re_sum.Location = new Point(control.Width - XPOS_LEFT, LB_SUM_RE_YPOS);

            lb_re_customer.Location = new Point(control.Width - XPOS_TAB1, LB_CUSTOMER_RE_YPOS);
            lb_re_date.Location = new Point(control.Width - XPOS_TAB1, LB_DATE_RE_YPOS);
            lb_re_sum.Location = new Point(control.Width - XPOS_TAB1, LB_SUM_RE_YPOS);
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



        private void myTable_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            selectedRowNumber = view.CurrentCell.RowIndex;

            cb_invoice.ResetText();
            if (selectedRowNumber >= 0)
            {
                List<string> invoiceNumberList = datenSatz[selectedRowNumber].invoiceList.Select(trans => trans.invoiceNumber).ToList(); // MEMO:    if(invoiceList[i] is ebayPPTransaction
                cb_invoice.DataSource = invoiceNumberList;
                if (invoiceNumberList.Count > 0)
                {
                    cb_invoice.SelectedIndex = datenSatz[selectedRowNumber].invoiceIndex;
                    lb_re_customer.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].customerName;
                    lb_re_sum.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].sum.ToString() + " " + datenSatz[selectedRowNumber].currency;
                    lb_re_date.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].date.ToString("dd.MM.yyyy - HH:mm") + " Uhr";
                }
                else
                {
                    lb_re_customer.Text = "";
                    lb_re_sum.Text = "";
                    lb_re_date.Text = "";
                }

                lb_pp_customer.Text = datenSatz[selectedRowNumber].customerName;
                lb_pp_sum.Text = datenSatz[selectedRowNumber].sum.ToString() + " " + datenSatz[selectedRowNumber].currency;
                lb_pp_fee.Text = datenSatz[selectedRowNumber].fee.ToString() + " " + datenSatz[selectedRowNumber].currency;
                lb_pp_date.Text = datenSatz[selectedRowNumber].date.ToString("dd.MM.yyyy - HH:mm")+" Uhr";

                if (datenSatz[selectedRowNumber].invoiceIndex >= 0)
                {
                    }
            }
        }


        private void cb_invoice_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         }

        private void cb_invoice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            datenSatz[selectedRowNumber].invoiceIndex = cb_invoice.SelectedIndex;
            datenSatz[selectedRowNumber].invoiceNumber = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].invoiceNumber;
            refreshTable();

            lb_re_customer.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].customerName;
            lb_re_sum.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].sum.ToString() + " " + datenSatz[selectedRowNumber].currency;
            lb_re_date.Text = datenSatz[selectedRowNumber].invoiceList[datenSatz[selectedRowNumber].invoiceIndex].date.ToString("dd.MM.yyyy - HH:mm") + " Uhr";
        }

        private void addInvoiceNr_btn_Click(object sender, EventArgs e)
        {
            if(selectedRowNumber != -1)
            {
                AddInvoiceForm invoiceForm = new AddInvoiceForm(datenSatz[selectedRowNumber]);
                DialogResult dialogresult = invoiceForm.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    Console.WriteLine(invoiceForm.invoiceNr);
                    Transaction addTrans = new Transaction(datenSatz[selectedRowNumber].customerName, datenSatz[selectedRowNumber].sum.ToString());
                    addTrans.invoiceNumber = invoiceForm.invoiceNr;
                    datenSatz[selectedRowNumber].invoiceList.Add(addTrans);
                    datenSatz[selectedRowNumber].invoiceNumber = addTrans.invoiceNumber;
                    datenSatz[selectedRowNumber].invoiceIndex = datenSatz[selectedRowNumber].invoiceList.Count - 1;
                    refreshTable();
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                invoiceForm.Dispose();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr windowHandler = FindWindow(null, "Unbenannt - Editor");

            // Verify that Calculator is a running process.
            if (windowHandler == IntPtr.Zero)
            {
                MessageBox.Show("Editor läuft nicht");
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

                        DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
                        column8.Name = "accountNr";
                        column8.ReadOnly = true;
                        column8.HeaderText = tableTitles[7];
                        column8.DataPropertyName = "accountNr";
                        this.myTable.Columns.Add(column8);

                        DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
                        column9.Name = "ggAccountNr";
                        column9.ReadOnly = true;
                        column9.HeaderText = tableTitles[8];
                        column9.DataPropertyName = "ggAccountNr";
                        this.myTable.Columns.Add(column9);

                        DataGridViewImageColumn column10 = new DataGridViewImageColumn();
                        column10.Name = "invoiceNumberState";
                        column10.ReadOnly = true;
                        column10.HeaderText = " ";
                        column10.DataPropertyName = "hint_image";
                        this.myTable.Columns.Add(column10);
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
                            payPal.invoiceList.Add(ebay);
                            payPal.invoiceIndex = 0;
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
                    trans.invoiceList = new List<Transaction>(onlineShopList.Where(osTrans => trans.outputName.ToUpper().Contains(osTrans.customerName.ToUpper())));
                    if (trans.invoiceList.Count() > 0)
                    {
                        trans.invoiceIndex = 0;
                        //Filtern nach Betrag
                        var supportList = trans.invoiceList.Where(osTrans => trans.sum == osTrans.sum);
                        if (supportList.Count() == 1) // Eindeutige Zuordnung erfolgt
                        {
                            trans.invoiceNumber = supportList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.SAFE;
                            trans.invoiceList = supportList.ToList();
                        }
                        // TODO Filtern nach Datum
                        else if (supportList.Count() > 1) // Mehrere Möglichkeiten
                        {
                            trans.invoiceNumber = supportList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.MULTIPLE;
                            trans.invoiceList = supportList.ToList();
                        }
                        else // Keine passende Summe gefunden
                        {
                            trans.invoiceNumber = trans.invoiceList.First().invoiceNumber;
                            trans.invoiceNumberState = InvoiceState.UNSURE_SUM;
                        }
                    }
                    else // Kein Passender Name gefunden --> Nochmal suchen ob eine passende Summe existiert
                    {
                        trans.invoiceList = new List<Transaction>(onlineShopList.Where(osTrans2 => trans.sum == osTrans2.sum));
                        if (trans.invoiceList.Count > 0)
                        {
                            trans.invoiceIndex = 0;
                            trans.invoiceNumber = trans.invoiceList.First().invoiceNumber;
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
            selectedRowNumber = -1;
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
