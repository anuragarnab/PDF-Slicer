using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using org.pdfclown.documents;
using org.pdfclown.files;
using org.pdfclown.objects;
using org.pdfclown.tools;

using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;


// for outputting to debug window

using System.Diagnostics;
using System.Collections;
using org.pdfclown.documents.interaction.viewer;
using org.pdfclown.documents.interchange.metadata;

namespace Merge
{
    public partial class Form1 : Form
    {

        ArrayList inputFiles = new ArrayList();
        ArrayList start = new ArrayList();
        ArrayList end = new ArrayList();

        bool dontUpdate = false;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;

            listBox1.DragEnter += new DragEventHandler(DragEnter);
            listBox1.DragDrop += new DragEventHandler(DragDrop);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

            //         listBox1.DataSource = inputFiles;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Don't want selected item handler to trigger now
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
            dontUpdate = true;

            openFileDialog1.ShowDialog();

            String[] files = openFileDialog1.FileNames;

            String list = "";

            foreach (String name in files)
            {
                list = list + name + " ";
                inputFiles.Add(name);
            }

            refreshList();

            //           textBox1.ReadOnly = false;
            //           textBox1.Text = list;
            //           textBox1.ReadOnly = true;

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            dontUpdate = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!dontUpdate)
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "" + listBox1.SelectedIndex;
                textBox1.ReadOnly = true;

                int startIndex = 0;

                if (listBox1.SelectedIndex >= 0)
                {
                    if (((string)inputFiles[listBox1.SelectedIndex]).LastIndexOf("\\") > 0)
                    {
                        startIndex = ((string)inputFiles[listBox1.SelectedIndex]).LastIndexOf("\\") + 1;
                    }

                    using (File mainFile = new File((string) inputFiles[listBox1.SelectedIndex]) )
                    {

                        label1.Text = ((string)inputFiles[listBox1.SelectedIndex]).Substring(startIndex) + "("+mainFile.Document.Pages.Count+")";
                    }
                }

            }
        }


        //Event handlers for drag and drop into the ListBox          

        void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.EndsWith(".pdf"))
                {
                    inputFiles.Add(file);
                }
            }
            refreshList();

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            swap(listBox1.SelectedIndex, listBox1.SelectedIndex - 1, inputFiles);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (swap(listBox1.SelectedIndex, listBox1.SelectedIndex + 1, inputFiles))
            {
                listBox1.SelectedIndex += 1;
            }
        }

        private bool swap(int index1, int index2, ArrayList array)
        {
            if (index1 >= 0 && index2 >= 0 && index1 < array.Count && index2 < array.Count)
            {
                Object temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
                refreshList();
                return true;
            }
            return false;

        }

        private void refreshList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = inputFiles;
        }

        private void merge(string target)
        {
            if (inputFiles.Count > 1)
            {
                writeText("Working");
                progressBar1.Visible = true;
                progressBar1.Step = 100 / inputFiles.Count;
                using (File mainFile = new File((string)inputFiles[0]))
                {
                    Document doc = mainFile.Document;
                    Pages pages = doc.Pages;

                    for (int i = 1; i < inputFiles.Count; ++i)
                    {
                        using (File sourceFile = new File((string)inputFiles[i]))
                        {
                            new PageManager(doc).Add(sourceFile.Document);
                            progressBar1.PerformStep();
                        }
                    }

                    Serialize(mainFile, target, null, "title", "subject", "keywords");
                }
            }
            else
            {
                writeWarningText("Require at least two files to merge");
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            merge(saveFileDialog1.FileName);
        }

        private string Serialize(File file, string fileName, SerializationModeEnum? serializationMode, string title, string subject, string keywords)
        {
            ApplyDocumentSettings(file.Document, title, subject, keywords);


            // Standard serialisation
            serializationMode = (SerializationModeEnum)0;


            string outputFilePath = fileName + ".pdf";

            // Save the file!
            /*
              NOTE: You can also save to a generic target stream (see Save() method overloads).
            */
            try
            { 
                file.Save(outputFilePath, serializationMode.Value);
                writeText("Complete");
                Process.Start(outputFilePath);
                progressBar1.Visible = false;
            }
            catch (Exception e)
            {

                writeWarningText("File writing failed");
                //Console.WriteLine("File writing failed: " + e.Message);
                //Console.WriteLine(e.StackTrace);
            }
            // Console.WriteLine("\nOutput: " + outputFilePath);

            return outputFilePath;
        }

        private void ApplyDocumentSettings(Document document, string title, string subject, string keywords
  )
        {
            if (title == null)
                return;

            // Viewer preferences.
            ViewerPreferences view = new ViewerPreferences(document); // Instantiates viewer preferences inside the document context.
            document.ViewerPreferences = view; // Assigns the viewer preferences object to the viewer preferences function.
            view.DisplayDocTitle = true;

            // Document metadata.
            Information info = document.Information;
            info.Clear();
            info.Author = "author";
            info.CreationDate = DateTime.Now;
            info.Creator = GetType().FullName;
            info.Title = title;
            info.Subject = subject;
            info.Keywords = keywords;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                inputFiles.RemoveAt(listBox1.SelectedIndex);
                refreshList();
            }
        }

        private void writeText(string text)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.ReadOnly = false;
            textBox1.Text = text;
            textBox1.ReadOnly = true;
        }

        private void writeWarningText(string text)
        {
            textBox1.ForeColor = System.Drawing.Color.Crimson;
            textBox1.ReadOnly = false;
            textBox1.Text = text;
            //textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.ReadOnly = true;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textStart_TextChanged(object sender, EventArgs e)
        {
            setRange(textStart, start);            
        }

        private void setRange(TextBox textBox, ArrayList array)
        {
            try
            {
                int number = Convert.ToInt32(textBox.Text);

                if (listBox1.SelectedIndex >= 0)
                {
                    using (File mainFile = new File((string)inputFiles[listBox1.SelectedIndex]))
                    {
                        // pdf numbering starts at 1!
                        if (number > mainFile.Document.Pages.Count || number < 1)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            array[listBox1.SelectedIndex] = number;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                writeWarningText("Invalid input");
            }
        }

        private void textEnd_TextChanged(object sender, EventArgs e)
        {
            setRange(textEnd, end);      
        }
        
    }
}


