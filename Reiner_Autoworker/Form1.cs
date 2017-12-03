﻿using System;
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

namespace Reiner_Autoworker
{
    public partial class Form1 : Form
    {
        private string[,] dataPacket;
        public Form1()
        {
            InitializeComponent();
            parsData();
        }

        private void parsData()
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\nikol\Desktop\Reiner_Testdaten\ebay.csv"))
            {
                DataTable dataTable = new DataTable();

                Transaktion trans = new Transaktion();

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
    }


}