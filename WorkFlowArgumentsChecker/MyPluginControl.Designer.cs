using System.Drawing;
using System.Windows.Forms;
namespace WorkFlowArgumentsChecker
{
    partial class MyPluginControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControlRight;
        private System.Windows.Forms.TabPage tabPageGrid;
        private System.Windows.Forms.TabPage tabPageDebug;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.topPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Environment = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabControlRight = new System.Windows.Forms.TabControl();
            this.tabPageGrid = new System.Windows.Forms.TabPage();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.richTextBox_debugBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Environment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlRight.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1469, 31);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(111, 28);
            this.toolStripButton1.Text = "Load Solutions";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(105, 28);
            this.toolStripButton2.Text = "Load Lookups";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(138, 28);
            this.toolStripButton3.Text = "Generate FetchXml";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButtonGenerateFetch_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(113, 28);
            this.toolStripButton4.Text = "Check In Target";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButtonCheckTarget_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(13, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(300, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Solution";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1090, 748);
            this.dataGridView1.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Controls.Add(this.Environment);
            this.topPanel.Controls.Add(this.linkLabel2);
            this.topPanel.Controls.Add(this.linkLabel1);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.comboBox1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 31);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(1469, 126);
            this.topPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(660, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FetchXml Settings";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(98, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Missing Only";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Selcted Only";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Environment
            // 
            this.Environment.Controls.Add(this.label4);
            this.Environment.Controls.Add(this.label3);
            this.Environment.Controls.Add(this.label2);
            this.Environment.Controls.Add(this.button1);
            this.Environment.Location = new System.Drawing.Point(366, 10);
            this.Environment.Name = "Environment";
            this.Environment.Size = new System.Drawing.Size(277, 100);
            this.Environment.TabIndex = 5;
            this.Environment.TabStop = false;
            this.Environment.Text = "Environment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(119, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unselected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(119, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Select Target";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(66, 101);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 15);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Unchek All";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(3, 101);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabel1.Size = new System.Drawing.Size(57, 15);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Check All";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 157);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.checkedListBox1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlRight);
            this.splitContainerMain.Size = new System.Drawing.Size(1469, 783);
            this.splitContainerMain.SplitterDistance = 361;
            this.splitContainerMain.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(361, 783);
            this.checkedListBox1.TabIndex = 0;
            // 
            // tabControlRight
            // 
            this.tabControlRight.Controls.Add(this.tabPageGrid);
            this.tabControlRight.Controls.Add(this.tabPageDebug);
            this.tabControlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlRight.Location = new System.Drawing.Point(0, 0);
            this.tabControlRight.Name = "tabControlRight";
            this.tabControlRight.SelectedIndex = 0;
            this.tabControlRight.Size = new System.Drawing.Size(1104, 783);
            this.tabControlRight.TabIndex = 0;
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Controls.Add(this.dataGridView1);
            this.tabPageGrid.Location = new System.Drawing.Point(4, 25);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrid.Size = new System.Drawing.Size(1096, 754);
            this.tabPageGrid.TabIndex = 0;
            this.tabPageGrid.Text = "Entity References";
            this.tabPageGrid.UseVisualStyleBackColor = true;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.richTextBox_debugBox);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 25);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebug.Size = new System.Drawing.Size(1096, 754);
            this.tabPageDebug.TabIndex = 1;
            this.tabPageDebug.Text = "Result";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // richTextBox_debugBox
            // 
            this.richTextBox_debugBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_debugBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.richTextBox_debugBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_debugBox.Name = "richTextBox_debugBox";
            this.richTextBox_debugBox.ReadOnly = true;
            this.richTextBox_debugBox.Size = new System.Drawing.Size(1090, 748);
            this.richTextBox_debugBox.TabIndex = 0;
            this.richTextBox_debugBox.Text = "";
            this.richTextBox_debugBox.WordWrap = false;
            // 
            // MyPluginControl
            // 
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1469, 940);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Environment.ResumeLayout(false);
            this.Environment.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlRight.ResumeLayout(false);
            this.tabPageGrid.ResumeLayout(false);
            this.tabPageDebug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CheckedListBox checkedListBox1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private ToolStripButton toolStripButton3;
        private GroupBox Environment;
        private Button button1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RichTextBox richTextBox_debugBox;
        private ToolStripButton toolStripButton4;
    }
}


//namespace WorkFlowArgumentsChecker
//{
//    partial class MyPluginControl
//    {
//        /// <summary> 
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        /// <summary> 
//        /// Required method for Designer support - do not modify 
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
//            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
//            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
//            this.comboBox1 = new System.Windows.Forms.ComboBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.textBox_debugBox = new System.Windows.Forms.TextBox();
//            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
//            this.dataGridView1 = new System.Windows.Forms.DataGridView();
//            this.toolStrip1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // toolStrip1
//            // 
//            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.toolStripButton1,
//            this.toolStripButton2});
//            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
//            this.toolStrip1.Name = "toolStrip1";
//            this.toolStrip1.Size = new System.Drawing.Size(1469, 27);
//            this.toolStrip1.TabIndex = 0;
//            this.toolStrip1.Text = "toolStrip1";
//            // 
//            // toolStripButton1
//            // 
//            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
//            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton1.Name = "toolStripButton1";
//            this.toolStripButton1.Size = new System.Drawing.Size(111, 24);
//            this.toolStripButton1.Text = "Load Solutions";
//            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
//            // 
//            // toolStripButton2
//            // 
//            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
//            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButton2.Name = "toolStripButton2";
//            this.toolStripButton2.Size = new System.Drawing.Size(105, 24);
//            this.toolStripButton2.Text = "Load Lookups";
//            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
//            // 
//            // comboBox1
//            // 
//            this.comboBox1.FormattingEnabled = true;
//            this.comboBox1.Location = new System.Drawing.Point(21, 73);
//            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
//            this.comboBox1.Name = "comboBox1";
//            this.comboBox1.Size = new System.Drawing.Size(330, 24);
//            this.comboBox1.TabIndex = 1;
//            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(17, 53);
//            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(96, 16);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Select Solution";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(17, 110);
//            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(69, 16);
//            this.label2.TabIndex = 4;
//            this.label2.Text = "Workflows";
//            // 
//            // textBox_debugBox
//            // 
//            this.textBox_debugBox.Location = new System.Drawing.Point(1302, 291);
//            this.textBox_debugBox.Margin = new System.Windows.Forms.Padding(4);
//            this.textBox_debugBox.Multiline = true;
//            this.textBox_debugBox.Name = "textBox_debugBox";
//            this.textBox_debugBox.Size = new System.Drawing.Size(299, 623);
//            this.textBox_debugBox.TabIndex = 5;
//            // 
//            // contextMenuStrip1
//            // 
//            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.contextMenuStrip1.Name = "contextMenuStrip1";
//            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
//            // 
//            // checkedListBox1
//            // 
//            this.checkedListBox1.FormattingEnabled = true;
//            this.checkedListBox1.Location = new System.Drawing.Point(21, 140);
//            this.checkedListBox1.Name = "checkedListBox1";
//            this.checkedListBox1.Size = new System.Drawing.Size(330, 769);
//            this.checkedListBox1.TabIndex = 6;
//            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
//            // 
//            // dataGridView1
//            // 
//            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dataGridView1.Location = new System.Drawing.Point(374, 140);
//            this.dataGridView1.Name = "dataGridView1";
//            this.dataGridView1.RowHeadersWidth = 51;
//            this.dataGridView1.RowTemplate.Height = 24;
//            this.dataGridView1.Size = new System.Drawing.Size(827, 469);
//            this.dataGridView1.TabIndex = 7;
//            // 
//            // MyPluginControl
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.dataGridView1);
//            this.Controls.Add(this.checkedListBox1);
//            this.Controls.Add(this.textBox_debugBox);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.comboBox1);
//            this.Controls.Add(this.toolStrip1);
//            this.Margin = new System.Windows.Forms.Padding(4);
//            this.Name = "MyPluginControl";
//            this.Size = new System.Drawing.Size(1469, 940);
//            this.Load += new System.EventHandler(this.MyPluginControl_Load);
//            this.toolStrip1.ResumeLayout(false);
//            this.toolStrip1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.ToolStrip toolStrip1;
//        private System.Windows.Forms.ToolStripButton toolStripButton1;
//        private System.Windows.Forms.ComboBox comboBox1;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox textBox_debugBox;
//        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
//        private System.Windows.Forms.CheckedListBox checkedListBox1;
//        private System.Windows.Forms.ToolStripButton toolStripButton2;
//        private System.Windows.Forms.DataGridView dataGridView1;
//    }
//}
