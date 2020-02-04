namespace Reiner_Autoworker.WorkerClasses
{
    partial class AddInvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cncl = new System.Windows.Forms.Button();
            this.lb_fx_customer = new System.Windows.Forms.Label();
            this.lb_fx_date = new System.Windows.Forms.Label();
            this.lb_fx_sum = new System.Windows.Forms.Label();
            this.lb_customer = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_sum = new System.Windows.Forms.Label();
            this.lb_header = new System.Windows.Forms.Label();
            this.txtBx_invoiceNr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_add.Location = new System.Drawing.Point(281, 119);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(108, 29);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Hinzufügen";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_cncl
            // 
            this.btn_cncl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cncl.Location = new System.Drawing.Point(281, 154);
            this.btn_cncl.Name = "btn_cncl";
            this.btn_cncl.Size = new System.Drawing.Size(108, 29);
            this.btn_cncl.TabIndex = 1;
            this.btn_cncl.Text = "Abbrechen";
            this.btn_cncl.UseVisualStyleBackColor = true;
            // 
            // lb_fx_customer
            // 
            this.lb_fx_customer.AutoSize = true;
            this.lb_fx_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_customer.Location = new System.Drawing.Point(27, 47);
            this.lb_fx_customer.Name = "lb_fx_customer";
            this.lb_fx_customer.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_customer.TabIndex = 2;
            this.lb_fx_customer.Text = "Kunde:";
            // 
            // lb_fx_date
            // 
            this.lb_fx_date.AutoSize = true;
            this.lb_fx_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_date.Location = new System.Drawing.Point(27, 64);
            this.lb_fx_date.Name = "lb_fx_date";
            this.lb_fx_date.Size = new System.Drawing.Size(59, 17);
            this.lb_fx_date.TabIndex = 3;
            this.lb_fx_date.Text = "Datum:";
            // 
            // lb_fx_sum
            // 
            this.lb_fx_sum.AutoSize = true;
            this.lb_fx_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fx_sum.Location = new System.Drawing.Point(27, 81);
            this.lb_fx_sum.Name = "lb_fx_sum";
            this.lb_fx_sum.Size = new System.Drawing.Size(61, 17);
            this.lb_fx_sum.TabIndex = 4;
            this.lb_fx_sum.Text = "Betrag:";
            // 
            // lb_customer
            // 
            this.lb_customer.AutoSize = true;
            this.lb_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_customer.Location = new System.Drawing.Point(92, 47);
            this.lb_customer.Name = "lb_customer";
            this.lb_customer.Size = new System.Drawing.Size(49, 17);
            this.lb_customer.TabIndex = 5;
            this.lb_customer.Text = "Kunde";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date.Location = new System.Drawing.Point(92, 64);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(49, 17);
            this.lb_date.TabIndex = 6;
            this.lb_date.Text = "Datum";
            // 
            // lb_sum
            // 
            this.lb_sum.AutoSize = true;
            this.lb_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sum.Location = new System.Drawing.Point(92, 81);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(50, 17);
            this.lb_sum.TabIndex = 7;
            this.lb_sum.Text = "Betrag";
            // 
            // lb_header
            // 
            this.lb_header.AutoSize = true;
            this.lb_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_header.Location = new System.Drawing.Point(26, 18);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(315, 20);
            this.lb_header.TabIndex = 8;
            this.lb_header.Text = "Neue Rechnungsnummer hinzufügen";
            // 
            // txtBx_invoiceNr
            // 
            this.txtBx_invoiceNr.Location = new System.Drawing.Point(30, 122);
            this.txtBx_invoiceNr.Name = "txtBx_invoiceNr";
            this.txtBx_invoiceNr.Size = new System.Drawing.Size(245, 22);
            this.txtBx_invoiceNr.TabIndex = 9;
            // 
            // AddInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 200);
            this.Controls.Add(this.txtBx_invoiceNr);
            this.Controls.Add(this.lb_header);
            this.Controls.Add(this.lb_sum);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.lb_customer);
            this.Controls.Add(this.lb_fx_sum);
            this.Controls.Add(this.lb_fx_date);
            this.Controls.Add(this.lb_fx_customer);
            this.Controls.Add(this.btn_cncl);
            this.Controls.Add(this.btn_add);
            this.Name = "AddInvoiceForm";
            this.Text = "AddInvoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cncl;
        private System.Windows.Forms.Label lb_fx_customer;
        private System.Windows.Forms.Label lb_fx_date;
        private System.Windows.Forms.Label lb_fx_sum;
        private System.Windows.Forms.Label lb_customer;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_sum;
        private System.Windows.Forms.Label lb_header;
        private System.Windows.Forms.TextBox txtBx_invoiceNr;
    }
}