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

namespace Reiner_Autoworker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            parsData();
        }

        private void parsData()
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\nikol\Desktop\Download.csv"))
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
                        Object[] row = { fields[0] };
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
    }


}
