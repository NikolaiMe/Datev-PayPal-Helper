namespace Reiner_Autoworker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.myTable = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ebayButton = new System.Windows.Forms.Button();
            this.onlineShopButton = new System.Windows.Forms.Button();
            this.paypalButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.myTable.Size = new System.Drawing.Size(834, 404);
            this.myTable.TabIndex = 0;
            this.myTable.VirtualMode = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Eintragen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ebayButton
            // 
            this.ebayButton.Image = ((System.Drawing.Image)(resources.GetObject("ebayButton.Image")));
            this.ebayButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ebayButton.Location = new System.Drawing.Point(122, 20);
            this.ebayButton.Name = "ebayButton";
            this.ebayButton.Size = new System.Drawing.Size(110, 63);
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
            this.onlineShopButton.Size = new System.Drawing.Size(110, 63);
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
            this.paypalButton.Size = new System.Drawing.Size(110, 62);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.myTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView myTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ebayButton;
        private System.Windows.Forms.Button paypalButton;
        private System.Windows.Forms.Button onlineShopButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

