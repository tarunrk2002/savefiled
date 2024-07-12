
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Xceed.Words.NET;
using System.Diagnostics;

namespace rep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox1.Text;
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "Excel files|*.xls|pdf|*.pdf|html|*.html|textfile|*.txt|word|*.docx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export report";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {

                if (saveDlg.FileName.EndsWith(".pdf"))
                {

                    Document document = new Document();
                    iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(saveDlg.FileName, FileMode.Create));

                    document.Open();

                    document.Add(new Paragraph(richTextBox1.Text.ToString()));
                    document.Close();
                }


                if (saveDlg.FileName.EndsWith(".docx"))
                {
                    var doc = DocX.Create(saveDlg.FileName);
                    doc.InsertParagraph(richTextBox1.Text.ToString());
                    
                    OpenFileDialog openDlg = new OpenFileDialog();
                    openDlg.Title = "select the image";
                    if (openDlg.ShowDialog() == DialogResult.OK)
                    {
                        doc.AddImage(openDlg.FileName.ToString());
                    }
                    
                    doc.Save();
                    //Process.Start("WINWORD.EXE", saveDlg.FileName);

                }

                textBox1.Text = saveDlg.FileName;






            }

        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 exporter = new Class1();
            richTextBox2.Text = richTextBox1.Text;
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "Excel files|*.xls|pdf|*.pdf|html|*.html|textfile|*.txt|word|*.docx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export report";
            if (saveDlg.ShowDialog() == DialogResult.OK) 
            {
                exporter.writeline(saveDlg.FileName,richTextBox2.Text);                    
            }
        }
    }
}