namespace Merge
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textEnd = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.b_Add = new System.Windows.Forms.ToolStripButton();
            this.b_Up = new System.Windows.Forms.ToolStripButton();
            this.b_Down = new System.Windows.Forms.ToolStripButton();
            this.b_Delete = new System.Windows.Forms.ToolStripButton();
            this.b_Merge = new System.Windows.Forms.ToolStripButton();
            this.b_Slice = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF files |*.pdf|All files|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 379);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b_Add,
            this.b_Up,
            this.b_Down,
            this.b_Delete,
            this.toolStripSeparator1,
            this.b_Merge,
            this.b_Slice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(373, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(367, 271);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textStart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 23);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // textStart
            // 
            this.textStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.textStart.Location = new System.Drawing.Point(235, 0);
            this.textStart.Name = "textStart";
            this.textStart.Size = new System.Drawing.Size(60, 20);
            this.textStart.TabIndex = 7;
            this.textStart.TextChanged += new System.EventHandler(this.textStart_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(295, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "to";
            // 
            // textEnd
            // 
            this.textEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.textEnd.Location = new System.Drawing.Point(311, 0);
            this.textEnd.Name = "textEnd";
            this.textEnd.Size = new System.Drawing.Size(56, 20);
            this.textEnd.TabIndex = 8;
            this.textEnd.TextChanged += new System.EventHandler(this.textEnd_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 332);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(324, 13);
            this.label.TabIndex = 10;
            this.label.Text = "Drag files into the box above or use the \"add\" button on the toolbar";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 356);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(367, 20);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // b_Add
            // 
            this.b_Add.Image = global::Merge.Properties.Resources.add;
            this.b_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Add.Name = "b_Add";
            this.b_Add.Size = new System.Drawing.Size(82, 22);
            this.b_Add.Text = "Add File ...";
            this.b_Add.Click += new System.EventHandler(this.b_Add_Click);
            // 
            // b_Up
            // 
            this.b_Up.Image = global::Merge.Properties.Resources.up;
            this.b_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Up.Name = "b_Up";
            this.b_Up.Size = new System.Drawing.Size(42, 22);
            this.b_Up.Text = "Up";
            this.b_Up.Click += new System.EventHandler(this.b_Up_Click);
            // 
            // b_Down
            // 
            this.b_Down.Image = global::Merge.Properties.Resources.down;
            this.b_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Down.Name = "b_Down";
            this.b_Down.Size = new System.Drawing.Size(58, 22);
            this.b_Down.Text = "Down";
            this.b_Down.Click += new System.EventHandler(this.b_Down_Click);
            // 
            // b_Delete
            // 
            this.b_Delete.Image = global::Merge.Properties.Resources.close;
            this.b_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Delete.Name = "b_Delete";
            this.b_Delete.Size = new System.Drawing.Size(60, 22);
            this.b_Delete.Text = "Delete";
            this.b_Delete.Click += new System.EventHandler(this.b_Delete_Click);
            // 
            // b_Merge
            // 
            this.b_Merge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.b_Merge.Image = ((System.Drawing.Image)(resources.GetObject("b_Merge.Image")));
            this.b_Merge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Merge.Name = "b_Merge";
            this.b_Merge.Size = new System.Drawing.Size(45, 22);
            this.b_Merge.Text = "Merge";
            this.b_Merge.ToolTipText = "Merge: Concatenate all the selected pdf files";
            this.b_Merge.Click += new System.EventHandler(this.b_Merge_Click);
            // 
            // b_Slice
            // 
            this.b_Slice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.b_Slice.Image = ((System.Drawing.Image)(resources.GetObject("b_Slice.Image")));
            this.b_Slice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Slice.Name = "b_Slice";
            this.b_Slice.Size = new System.Drawing.Size(35, 22);
            this.b_Slice.Text = "Slice";
            this.b_Slice.ToolTipText = "Slice: Concatenate only the specified parts of the pdf files";
            this.b_Slice.Click += new System.EventHandler(this.b_Slice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(389, 414);
            this.Name = "Form1";
            this.Text = "PDF Slicer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton b_Add;
        private System.Windows.Forms.ToolStripButton b_Up;
        private System.Windows.Forms.ToolStripButton b_Down;
        private System.Windows.Forms.ToolStripButton b_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton b_Merge;
        private System.Windows.Forms.ToolStripButton b_Slice;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEnd;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

