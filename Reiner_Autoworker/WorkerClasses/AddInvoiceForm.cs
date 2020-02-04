using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reiner_Autoworker.DataStructures;

namespace Reiner_Autoworker.WorkerClasses
{
    public partial class AddInvoiceForm : Form
    {
        public String invoiceNr { get; set; }
        public AddInvoiceForm(payPalTransaction transaction)
        {
            InitializeComponent();
            lb_customer.Text = transaction.customerName;
            lb_sum.Text = transaction.sum.ToString();
            lb_date.Text = transaction.date.ToLongDateString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            this.invoiceNr = txtBx_invoiceNr.Text;
        }

    }
}
