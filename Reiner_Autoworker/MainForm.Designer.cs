namespace Reiner_Autoworker
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.myTable = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ebayButton = new System.Windows.Forms.Button();
            this.onlineShopButton = new System.Windows.Forms.Button();
            this.paypalButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cb_invoice = new System.Windows.Forms.ComboBox();
            this.btn_addinvoice = new System.Windows.Forms.Button();
            this.lb_fx_pp_title = new System.Windows.Forms.Label();
            this.lb_fx_pp_customer = new System.Windows.Forms.Label();
            this.lb_fx_pp_sum = new System.Windows.Forms.Label();
            this.lb_fx_pp_date = new System.Windows.Forms.Label();
            this.lb_fx_ggaccount = new System.Windows.Forms.Label();
            this.lb_fx_account = new System.Windows.Forms.Label();
            this.lb_fx_pp_fee = new System.Windows.Forms.Label();
            this.lb_fx_invoice = new System.Windows.Forms.Label();
            this.tb_account = new System.Windows.Forms.TextBox();
            this.tb_ggaccount = new System.Windows.Forms.TextBox();
            this.lb_pp_customer = new System.Windows.Forms.Label();
            this.lb_pp_fee = new System.Windows.Forms.Label();
            this.lb_pp_date = new System.Windows.Forms.Label();
            this.lb_pp_sum = new System.Windows.Forms.Label();
            this.lb_re_sum = new System.Windows.Forms.Label();
            this.lb_re_date = new System.Windows.Forms.Label();
            this.lb_re_customer = new System.Windows.Forms.Label();
            this.lb_fx_re_date = new System.Windows.Forms.Label();
            this.lb_fx_re_sum = new System.Windows.Forms.Label();
            this.lb_fx_re_customer = new System.Windows.Forms.Label();
            this.lb_fx_re_title = new System.Windows.Forms.Label();
            this.lb_fx_account_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTable
            // 
            this.myTable.AllowUserToAddRows = false;
            this.myTable.AllowUserToDeleteRows = false;
            this.myTable.AllowUserToResizeColumns = false;
            this.myTable.AllowUserToResizeRows = false;
            this.myTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.myTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myTable.Location = new System.Drawing.Point(13, 119);
            this.myTable.Margin = new System.Windows.Forms.Padding(4);
            this.myTable.MaximumSize = new System.Drawing.Size(2560, 1600);
            this.myTable.Name = "myTable";
            this.myTable.Size = new System.Drawing.Size(819, 404);
            this.myTable.TabIndex = 0;
            this.myTable.VirtualMode = true;
            this.myTable.SelectionChanged += new System.EventHandler(this.myTable_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(386, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 73);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ebayButton
            // 
            this.ebayButton.Image = ((System.Drawing.Image)(resources.GetObject("ebayButton.Image")));
            this.ebayButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ebayButton.Location = new System.Drawing.Point(122, 20);
            this.ebayButton.Name = "ebayButton";
            this.ebayButton.Size = new System.Drawing.Size(110, 74);
            this.ebayButton.TabIndex = 4;
            this.ebayButton.Text = "ebay";
            this.ebayButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ebayButton.UseVisualStyleBackColor = true;
            this.ebayButton.Click += new System.EventHandler(this.ebayButton_Click);
            // 
            // onlineShopButton
            // 
            this.onlineShopButton.Image = ((System.Drawing.Image)(resources.GetObject("onlineShopButton.Image")));
            this.onlineShopButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.onlineShopButton.Location = new System.Drawing.Point(238, 20);
            this.onlineShopButton.Name = "onlineShopButton";
            this.onlineShopButton.Size = new System.Drawing.Size(110, 74);
            this.onlineShopButton.TabIndex = 2;
            this.onlineShopButton.Text = "Onlineshop";
            this.onlineShopButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.onlineShopButton.UseVisualStyleBackColor = true;
            this.onlineShopButton.Click += new System.EventHandler(this.onlineShopButton_Click);
            // 
            // paypalButton
            // 
            this.paypalButton.Image = ((System.Drawing.Image)(resources.GetObject("paypalButton.Image")));
            this.paypalButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.paypalButton.Location = new System.Drawing.Point(6, 21);
            this.paypalButton.Name = "paypalButton";
            this.paypalButton.Size = new System.Drawing.Size(110, 73);
            this.paypalButton.TabIndex = 3;
            this.paypalButton.Text = "PayPal";
            this.paypalButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.paypalButton.UseVisualStyleBackColor = true;
            this.paypalButton.Click += new System.EventHandler(this.paypalButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onlineShopButton);
            this.groupBox1.Controls.Add(this.ebayButton);
            this.groupBox1.Controls.Add(this.paypalButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten Laden";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 680);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // cb_invoice
            // 
            this.cb_invoice.FormattingEnabled = true;
            this.cb_invoice.Location = new System.Drawing.Point(845, 421);
            this.cb_invoice.Name = "cb_invoice";
            this.cb_invoice.Size = new System.Drawing.Size(250, 24);
            this.cb_invoice.TabIndex = 8;
            this.cb_invoice.SelectedIndexChanged += new System.EventHandler(this.cb_invoice_SelectedIndexChanged_1);
            this.cb_invoice.SelectionChangeCommitted += new System.EventHandler(this.cb_invoice_SelectionChangeCommitted);
            // 
            // btn_addinvoice
            // 
            this.btn_addinvoice.Location = new System.Drawing.Point(1101, 421);
            this.btn_addinvoice.Name = "btn_addinvoice";
            this.btn_addinvoice.Size = new System.Drawing.Size(24, 24);
            this.btn_addinvoice.TabIndex = 9;
            this.btn_addinvoice.Text = "+";
            this.btn_addinvoice.UseVisualStyleBackColor = true;
            this.btn_addinvoice.Click += new System.EventHandler(this.addInvoiceNr_btn_Click);
            // 
            // lb_fx_pp_title
            // 
            this.lb_fx_pp_title.AutoSize = true;
            this.lb_fx_pp_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_pp_title.Location = new System.Drawing.Point(840, 119);
            this.lb_fx_pp_title.Name = "lb_fx_pp_title";
            this.lb_fx_pp_title.Size = new System.Drawing.Size(274, 25);
            this.lb_fx_pp_title.TabIndex = 10;
            this.lb_fx_pp_title.Text = "Transaktions Informationen";
            // 
            // lb_fx_pp_customer
            // 
            this.lb_fx_pp_customer.AutoSize = true;
            this.lb_fx_pp_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_pp_customer.Location = new System.Drawing.Point(842, 160);
            this.lb_fx_pp_customer.Name = "lb_fx_pp_customer";
            this.lb_fx_pp_customer.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_pp_customer.TabIndex = 11;
            this.lb_fx_pp_customer.Text = "Kunde:";
            // 
            // lb_fx_pp_sum
            // 
            this.lb_fx_pp_sum.AutoSize = true;
            this.lb_fx_pp_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_pp_sum.Location = new System.Drawing.Point(842, 190);
            this.lb_fx_pp_sum.Name = "lb_fx_pp_sum";
            this.lb_fx_pp_sum.Size = new System.Drawing.Size(61, 17);
            this.lb_fx_pp_sum.TabIndex = 12;
            this.lb_fx_pp_sum.Text = "Betrag:";
            // 
            // lb_fx_pp_date
            // 
            this.lb_fx_pp_date.AutoSize = true;
            this.lb_fx_pp_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_pp_date.Location = new System.Drawing.Point(842, 219);
            this.lb_fx_pp_date.Name = "lb_fx_pp_date";
            this.lb_fx_pp_date.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_pp_date.TabIndex = 13;
            this.lb_fx_pp_date.Text = "Datum:";
            // 
            // lb_fx_ggaccount
            // 
            this.lb_fx_ggaccount.AutoSize = true;
            this.lb_fx_ggaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_ggaccount.Location = new System.Drawing.Point(842, 357);
            this.lb_fx_ggaccount.Name = "lb_fx_ggaccount";
            this.lb_fx_ggaccount.Size = new System.Drawing.Size(74, 17);
            this.lb_fx_ggaccount.TabIndex = 14;
            this.lb_fx_ggaccount.Text = "Ggkonto:";
            // 
            // lb_fx_account
            // 
            this.lb_fx_account.AutoSize = true;
            this.lb_fx_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_account.Location = new System.Drawing.Point(842, 317);
            this.lb_fx_account.Name = "lb_fx_account";
            this.lb_fx_account.Size = new System.Drawing.Size(55, 17);
            this.lb_fx_account.TabIndex = 15;
            this.lb_fx_account.Text = "Konto:";
            // 
            // lb_fx_pp_fee
            // 
            this.lb_fx_pp_fee.AutoSize = true;
            this.lb_fx_pp_fee.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_pp_fee.Location = new System.Drawing.Point(842, 249);
            this.lb_fx_pp_fee.Name = "lb_fx_pp_fee";
            this.lb_fx_pp_fee.Size = new System.Drawing.Size(67, 17);
            this.lb_fx_pp_fee.TabIndex = 16;
            this.lb_fx_pp_fee.Text = "Gebühr:";
            // 
            // lb_fx_invoice
            // 
            this.lb_fx_invoice.AutoSize = true;
            this.lb_fx_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_invoice.Location = new System.Drawing.Point(842, 401);
            this.lb_fx_invoice.Name = "lb_fx_invoice";
            this.lb_fx_invoice.Size = new System.Drawing.Size(151, 17);
            this.lb_fx_invoice.TabIndex = 17;
            this.lb_fx_invoice.Text = "Rechnungsnummer:";
            // 
            // tb_account
            // 
            this.tb_account.Location = new System.Drawing.Point(928, 314);
            this.tb_account.Name = "tb_account";
            this.tb_account.Size = new System.Drawing.Size(100, 22);
            this.tb_account.TabIndex = 18;
            // 
            // tb_ggaccount
            // 
            this.tb_ggaccount.Location = new System.Drawing.Point(928, 354);
            this.tb_ggaccount.Name = "tb_ggaccount";
            this.tb_ggaccount.Size = new System.Drawing.Size(100, 22);
            this.tb_ggaccount.TabIndex = 19;
            // 
            // lb_pp_customer
            // 
            this.lb_pp_customer.AutoSize = true;
            this.lb_pp_customer.Location = new System.Drawing.Point(925, 160);
            this.lb_pp_customer.Name = "lb_pp_customer";
            this.lb_pp_customer.Size = new System.Drawing.Size(0, 17);
            this.lb_pp_customer.TabIndex = 20;
            // 
            // lb_pp_fee
            // 
            this.lb_pp_fee.AutoSize = true;
            this.lb_pp_fee.Location = new System.Drawing.Point(925, 249);
            this.lb_pp_fee.Name = "lb_pp_fee";
            this.lb_pp_fee.Size = new System.Drawing.Size(0, 17);
            this.lb_pp_fee.TabIndex = 21;
            // 
            // lb_pp_date
            // 
            this.lb_pp_date.AutoSize = true;
            this.lb_pp_date.Location = new System.Drawing.Point(925, 219);
            this.lb_pp_date.Name = "lb_pp_date";
            this.lb_pp_date.Size = new System.Drawing.Size(0, 17);
            this.lb_pp_date.TabIndex = 22;
            // 
            // lb_pp_sum
            // 
            this.lb_pp_sum.AutoSize = true;
            this.lb_pp_sum.Location = new System.Drawing.Point(925, 190);
            this.lb_pp_sum.Name = "lb_pp_sum";
            this.lb_pp_sum.Size = new System.Drawing.Size(0, 17);
            this.lb_pp_sum.TabIndex = 23;
            // 
            // lb_re_sum
            // 
            this.lb_re_sum.AutoSize = true;
            this.lb_re_sum.Location = new System.Drawing.Point(925, 557);
            this.lb_re_sum.Name = "lb_re_sum";
            this.lb_re_sum.Size = new System.Drawing.Size(0, 17);
            this.lb_re_sum.TabIndex = 30;
            // 
            // lb_re_date
            // 
            this.lb_re_date.AutoSize = true;
            this.lb_re_date.Location = new System.Drawing.Point(925, 586);
            this.lb_re_date.Name = "lb_re_date";
            this.lb_re_date.Size = new System.Drawing.Size(0, 17);
            this.lb_re_date.TabIndex = 29;
            // 
            // lb_re_customer
            // 
            this.lb_re_customer.AutoSize = true;
            this.lb_re_customer.Location = new System.Drawing.Point(925, 527);
            this.lb_re_customer.Name = "lb_re_customer";
            this.lb_re_customer.Size = new System.Drawing.Size(0, 17);
            this.lb_re_customer.TabIndex = 28;
            // 
            // lb_fx_re_date
            // 
            this.lb_fx_re_date.AutoSize = true;
            this.lb_fx_re_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_re_date.Location = new System.Drawing.Point(842, 586);
            this.lb_fx_re_date.Name = "lb_fx_re_date";
            this.lb_fx_re_date.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_re_date.TabIndex = 27;
            this.lb_fx_re_date.Text = "Datum:";
            // 
            // lb_fx_re_sum
            // 
            this.lb_fx_re_sum.AutoSize = true;
            this.lb_fx_re_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_re_sum.Location = new System.Drawing.Point(842, 557);
            this.lb_fx_re_sum.Name = "lb_fx_re_sum";
            this.lb_fx_re_sum.Size = new System.Drawing.Size(61, 17);
            this.lb_fx_re_sum.TabIndex = 26;
            this.lb_fx_re_sum.Text = "Betrag:";
            // 
            // lb_fx_re_customer
            // 
            this.lb_fx_re_customer.AutoSize = true;
            this.lb_fx_re_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_re_customer.Location = new System.Drawing.Point(842, 527);
            this.lb_fx_re_customer.Name = "lb_fx_re_customer";
            this.lb_fx_re_customer.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_re_customer.TabIndex = 25;
            this.lb_fx_re_customer.Text = "Kunde:";
            // 
            // lb_fx_re_title
            // 
            this.lb_fx_re_title.AutoSize = true;
            this.lb_fx_re_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_re_title.Location = new System.Drawing.Point(840, 486);
            this.lb_fx_re_title.Name = "lb_fx_re_title";
            this.lb_fx_re_title.Size = new System.Drawing.Size(250, 25);
            this.lb_fx_re_title.TabIndex = 24;
            this.lb_fx_re_title.Text = "Rechnungsinformationen";
            // 
            // lb_fx_account_title
            // 
            this.lb_fx_account_title.AutoSize = true;
            this.lb_fx_account_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_account_title.Location = new System.Drawing.Point(840, 286);
            this.lb_fx_account_title.Name = "lb_fx_account_title";
            this.lb_fx_account_title.Size = new System.Drawing.Size(81, 25);
            this.lb_fx_account_title.TabIndex = 31;
            this.lb_fx_account_title.Text = "Konten";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 680);
            this.Controls.Add(this.lb_fx_account_title);
            this.Controls.Add(this.lb_re_sum);
            this.Controls.Add(this.lb_re_date);
            this.Controls.Add(this.lb_re_customer);
            this.Controls.Add(this.lb_fx_re_date);
            this.Controls.Add(this.lb_fx_re_sum);
            this.Controls.Add(this.lb_fx_re_customer);
            this.Controls.Add(this.lb_fx_re_title);
            this.Controls.Add(this.lb_pp_sum);
            this.Controls.Add(this.lb_pp_date);
            this.Controls.Add(this.lb_pp_fee);
            this.Controls.Add(this.lb_pp_customer);
            this.Controls.Add(this.tb_ggaccount);
            this.Controls.Add(this.tb_account);
            this.Controls.Add(this.lb_fx_invoice);
            this.Controls.Add(this.lb_fx_pp_fee);
            this.Controls.Add(this.lb_fx_account);
            this.Controls.Add(this.lb_fx_ggaccount);
            this.Controls.Add(this.lb_fx_pp_date);
            this.Controls.Add(this.lb_fx_pp_sum);
            this.Controls.Add(this.lb_fx_pp_customer);
            this.Controls.Add(this.lb_fx_pp_title);
            this.Controls.Add(this.btn_addinvoice);
            this.Controls.Add(this.cb_invoice);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.myTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView myTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ebayButton;
        private System.Windows.Forms.Button paypalButton;
        private System.Windows.Forms.Button onlineShopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cb_invoice;
        private System.Windows.Forms.Button btn_addinvoice;
        private System.Windows.Forms.Label lb_fx_pp_title;
        private System.Windows.Forms.Label lb_fx_pp_customer;
        private System.Windows.Forms.Label lb_fx_pp_sum;
        private System.Windows.Forms.Label lb_fx_pp_date;
        private System.Windows.Forms.Label lb_fx_ggaccount;
        private System.Windows.Forms.Label lb_fx_account;
        private System.Windows.Forms.Label lb_fx_pp_fee;
        private System.Windows.Forms.Label lb_fx_invoice;
        private System.Windows.Forms.TextBox tb_account;
        private System.Windows.Forms.TextBox tb_ggaccount;
        private System.Windows.Forms.Label lb_pp_customer;
        private System.Windows.Forms.Label lb_pp_fee;
        private System.Windows.Forms.Label lb_pp_date;
        private System.Windows.Forms.Label lb_pp_sum;
        private System.Windows.Forms.Label lb_re_sum;
        private System.Windows.Forms.Label lb_re_date;
        private System.Windows.Forms.Label lb_re_customer;
        private System.Windows.Forms.Label lb_fx_re_date;
        private System.Windows.Forms.Label lb_fx_re_sum;
        private System.Windows.Forms.Label lb_fx_re_customer;
        private System.Windows.Forms.Label lb_fx_re_title;
        private System.Windows.Forms.Label lb_fx_account_title;
    }
}

