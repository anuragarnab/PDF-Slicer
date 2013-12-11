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
using System.Printing;


//using System.IO;

namespace Merge
{
    public partial class Form1 : Form
    {
     
        const string MESSAGE = "Drag files into the box above or use the \"add\" button on the toolbar";

        ArrayList inputFiles = new ArrayList();
        ArrayList inputFileObjects = new ArrayList();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            writeText(MESSAGE);

            if (!dontUpdate)
            {
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

                    textStart.TextChanged -= textStart_TextChanged;
                    textEnd.TextChanged -= textEnd_TextChanged;
                    textStart.Text = "" + ((InputFile)inputFileObjects[listBox1.SelectedIndex]).Start;
                    textEnd.Text = "" + ((InputFile)inputFileObjects[listBox1.SelectedIndex]).End;
                    textStart.TextChanged += textStart_TextChanged;
                    textEnd.TextChanged += textEnd_TextChanged;

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

                    using (File mainFile = new File(file))
                    {
                        inputFileObjects.Add(new InputFile(file, mainFile.Document.Pages.Count));
                    }
                }
            }
            refreshList();

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

            if (target == null || target.Equals(""))
            {
               // writeText("No output given");
                return;
            }

            if (inputFiles.Count > 1)
            {
                writeText("Working");

                label.Visible = false;
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

                    // Last three parameters are "title", "subject" and "keyword"
                    Serialize(mainFile, target, null, getTitle(target), "subject", "PDF Slicer");
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


        private string Serialize(File file, string fileName, SerializationModeEnum? serializationMode, string title, string subject, string keywords)
        {
            ApplyDocumentSettings(file.Document, title, subject, keywords);


            // Standard serialisation
            serializationMode = (SerializationModeEnum)0;


            string outputFilePath = fileName + ".pdf";

            // Save the file!
            try
            { 
                file.Save(outputFilePath, serializationMode.Value);
                writeText("Complete");
                Process.Start(outputFilePath);

                label.Visible = true;
                progressBar1.Visible = false;
            }
            catch (Exception e)
            {

                writeWarningText("File writing failed");
            }

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

        private void writeText(string text)
        {

            label.ForeColor = System.Drawing.Color.Black;
            label.Text = text;
 
        }

        private void writeWarningText(string text)
        {
            label.ForeColor = System.Drawing.Color.Crimson;
            label.Text = text;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textStart_TextChanged(object sender, EventArgs e)
        {
            setRange(textStart, 0);            
        }

        /// <summary> 
        /// Performs input validation on the numbers entered into the slicing text boxes
        /// </summary>
        // option = 0 is start text box
        // option = 1 is end text box
        private void setRange(TextBox textBox, int option)
        {
            try
            {
                int number = Convert.ToInt32(textBox.Text);

                if (listBox1.SelectedIndex >= 0)
                {
                        // pdf numbering starts at 1!
                        if (number > ((InputFile)inputFileObjects[listBox1.SelectedIndex]).Length || number < 1)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            if (option == 0)
                            {
                                ((InputFile)inputFileObjects[listBox1.SelectedIndex]).Start = number;
                            }
                            else
                            {
                                ((InputFile)inputFileObjects[listBox1.SelectedIndex]).End = number;
                            }
                        }
                        writeText("");
                }
            }
            catch (Exception exception)
            {
                writeWarningText("Invalid input");
                if (option == 0)
                {
                    ((InputFile)inputFileObjects[listBox1.SelectedIndex]).Start = 1;
                }
                else
                {
                    ((InputFile)inputFileObjects[listBox1.SelectedIndex]).End = ((InputFile)inputFileObjects[listBox1.SelectedIndex]).Length;
                }
            }
        }

        private void textEnd_TextChanged(object sender, EventArgs e)
        {
            setRange(textEnd, 1);      
        }

        private void addPages(string target)
        {
            File file = new File();

            label.Visible = false;
            progressBar1.Step = 100 / inputFiles.Count;
            progressBar1.Visible = true;

            int targetPageIndex = 0; // Where in the pdf to add to

            for (int i = inputFileObjects.Count - 1; i >= 0; --i)
            {
                using (File sourceFile = new File(((InputFile)inputFileObjects[i]).Path))
                {
                    Pages sourcePages = sourceFile.Document.Pages;

                    if (((InputFile)inputFileObjects[i]).Start <= ((InputFile)inputFileObjects[i]).End)
                    {
                        new PageManager(file.Document).Add(
                        targetPageIndex,
                        sourcePages.GetSlice(
                        ((InputFile)inputFileObjects[i]).Start - 1,
                        ((InputFile)inputFileObjects[i]).End
                      )

                    );
                    }
                    else
                    {
                        writeWarningText("End page precedes start page in " + ((InputFile)inputFileObjects[i]).Path );
                    }

                    progressBar1.PerformStep();
                }
            }

            Serialize(file, target, null, getTitle(target), "subject", "PDF Slicer");
        }

        private void buttonSlice_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = null;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == null || saveFileDialog1.Equals(""))
            {
                writeText("Valid output file name required");
            }
            addPages(saveFileDialog1.FileName);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void b_Add_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
            dontUpdate = true;

            openFileDialog1.Filter = "PDF files |*.pdf|All files|*.*";
            openFileDialog1.ShowDialog();

            String[] files = openFileDialog1.FileNames;

            foreach (String name in files)
            {
                inputFiles.Add(name);

                using (File mainFile = new File(name))
                {
                    inputFileObjects.Add(new InputFile(name, mainFile.Document.Pages.Count));
                }
            }

            refreshList();

            //           textBox1.ReadOnly = false;
            //           textBox1.Text = list;
            //           textBox1.ReadOnly = true;

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            dontUpdate = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void b_Up_Click(object sender, EventArgs e)
        {
            swap(listBox1.SelectedIndex, listBox1.SelectedIndex - 1, inputFiles);
            swap(listBox1.SelectedIndex, listBox1.SelectedIndex - 1, inputFileObjects);
        }

        private void b_Down_Click(object sender, EventArgs e)
        {
            if (swap(listBox1.SelectedIndex, listBox1.SelectedIndex + 1, inputFiles))
            {
                swap(listBox1.SelectedIndex, listBox1.SelectedIndex + 1, inputFileObjects);
                listBox1.SelectedIndex += 1;
            }
        }

        private void b_Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                inputFiles.RemoveAt(listBox1.SelectedIndex);
                refreshList();
            }
        }

        private void b_Merge_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = null;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.AddExtension = false;
            merge(saveFileDialog1.FileName);
        }

        private void b_Slice_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = null;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == null || saveFileDialog1.FileName.Equals(""))
            {
                ;//writeText("Valid output file name required");
            }
            else
            {
                addPages(saveFileDialog1.FileName);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private string getTitle(string path)
        {
            int startIndex = 0;

            if (path.LastIndexOf("\\") > 0)
            {
                startIndex = path.LastIndexOf("\\") + 1;
            }

            string subject = path.Substring(startIndex);
            return subject.Replace(".pdf", "");
         
        }
    }
}


