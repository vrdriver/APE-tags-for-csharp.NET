
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace Main
{

    
    public partial class MainForm : Form // Class should inherit from Form
    {
        public Label TagExistsLabel;
        public Label VersionLabel;
        public Label SizeLabel;
        public Label TitleLabel;
        public Label ArtistLabel;
        public Label AlbumLabel;
        public Label TrackLabel;
        public Label YearLabel;
        public Label GenreLabel;
        public Label CommentLabel;
        public Label CopyrightLabel;
        public Button CloseButton;
        public TextBox TagExistsValue;
        public TextBox VersionValue;
        public TextBox SizeValue;
        public TextBox TitleEdit;
        public TextBox ArtistEdit;
        public TextBox AlbumEdit;
        public TextBox TrackEdit;
        public TextBox YearEdit;
        public TextBox GenreEdit;
        public TextBox CommentEdit;
        public Button SaveButton;
        public TextBox CopyrightEdit;
        private ToolTip toolTip1 = null;


        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose(); // Use null conditional operator for brevity
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TagExistsLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.TrackLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TagExistsValue = new System.Windows.Forms.TextBox();
            this.VersionValue = new System.Windows.Forms.TextBox();
            this.SizeValue = new System.Windows.Forms.TextBox();
            this.TitleEdit = new System.Windows.Forms.TextBox();
            this.ArtistEdit = new System.Windows.Forms.TextBox();
            this.AlbumEdit = new System.Windows.Forms.TextBox();
            this.TrackEdit = new System.Windows.Forms.TextBox();
            this.YearEdit = new System.Windows.Forms.TextBox();
            this.GenreEdit = new System.Windows.Forms.TextBox();
            this.CommentEdit = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CopyrightEdit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOpenFile = new System.Windows.Forms.TextBox();
            this.buttonRemoveAllTags = new System.Windows.Forms.Button();
            this.buttonRemoveTitleTag = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewFieldName = new System.Windows.Forms.TextBox();
            this.textBoxNewFieldValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.ColumnField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // TagExistsLabel
            // 
            this.TagExistsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TagExistsLabel.Location = new System.Drawing.Point(483, 18);
            this.TagExistsLabel.Name = "TagExistsLabel";
            this.TagExistsLabel.Size = new System.Drawing.Size(100, 23);
            this.TagExistsLabel.TabIndex = 2;
            this.TagExistsLabel.Text = "Tag Exists";
            // 
            // VersionLabel
            // 
            this.VersionLabel.BackColor = System.Drawing.SystemColors.Control;
            this.VersionLabel.Location = new System.Drawing.Point(242, 41);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(100, 23);
            this.VersionLabel.TabIndex = 3;
            this.VersionLabel.Text = "Version";
            // 
            // SizeLabel
            // 
            this.SizeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SizeLabel.Location = new System.Drawing.Point(242, 87);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(100, 23);
            this.SizeLabel.TabIndex = 4;
            this.SizeLabel.Text = "Size";
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabel.Location = new System.Drawing.Point(13, 18);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(100, 23);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Title";
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ArtistLabel.Location = new System.Drawing.Point(13, 41);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(100, 23);
            this.ArtistLabel.TabIndex = 6;
            this.ArtistLabel.Text = "Artist";
            // 
            // AlbumLabel
            // 
            this.AlbumLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AlbumLabel.Location = new System.Drawing.Point(16, 64);
            this.AlbumLabel.Name = "AlbumLabel";
            this.AlbumLabel.Size = new System.Drawing.Size(100, 23);
            this.AlbumLabel.TabIndex = 7;
            this.AlbumLabel.Text = "Album";
            // 
            // TrackLabel
            // 
            this.TrackLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TrackLabel.Location = new System.Drawing.Point(242, 64);
            this.TrackLabel.Name = "TrackLabel";
            this.TrackLabel.Size = new System.Drawing.Size(100, 23);
            this.TrackLabel.TabIndex = 8;
            this.TrackLabel.Text = "Track";
            // 
            // YearLabel
            // 
            this.YearLabel.BackColor = System.Drawing.SystemColors.Control;
            this.YearLabel.Location = new System.Drawing.Point(483, 41);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(100, 23);
            this.YearLabel.TabIndex = 9;
            this.YearLabel.Text = "Year";
            // 
            // GenreLabel
            // 
            this.GenreLabel.BackColor = System.Drawing.SystemColors.Control;
            this.GenreLabel.Location = new System.Drawing.Point(17, 87);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(100, 23);
            this.GenreLabel.TabIndex = 10;
            this.GenreLabel.Text = "Genre";
            // 
            // CommentLabel
            // 
            this.CommentLabel.BackColor = System.Drawing.SystemColors.Control;
            this.CommentLabel.Location = new System.Drawing.Point(242, 18);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(100, 23);
            this.CommentLabel.TabIndex = 11;
            this.CommentLabel.Text = "Comment";
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.BackColor = System.Drawing.SystemColors.Control;
            this.CopyrightLabel.Location = new System.Drawing.Point(483, 64);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(100, 23);
            this.CopyrightLabel.TabIndex = 12;
            this.CopyrightLabel.Text = "Copyright";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(531, 197);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(154, 25);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "Close Program";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TagExistsValue
            // 
            this.TagExistsValue.BackColor = System.Drawing.Color.White;
            this.TagExistsValue.Location = new System.Drawing.Point(589, 15);
            this.TagExistsValue.Name = "TagExistsValue";
            this.TagExistsValue.Size = new System.Drawing.Size(100, 20);
            this.TagExistsValue.TabIndex = 17;
            // 
            // VersionValue
            // 
            this.VersionValue.BackColor = System.Drawing.Color.White;
            this.VersionValue.Location = new System.Drawing.Point(347, 38);
            this.VersionValue.Name = "VersionValue";
            this.VersionValue.Size = new System.Drawing.Size(100, 20);
            this.VersionValue.TabIndex = 18;
            // 
            // SizeValue
            // 
            this.SizeValue.BackColor = System.Drawing.Color.White;
            this.SizeValue.Location = new System.Drawing.Point(348, 84);
            this.SizeValue.Name = "SizeValue";
            this.SizeValue.Size = new System.Drawing.Size(100, 20);
            this.SizeValue.TabIndex = 19;
            // 
            // TitleEdit
            // 
            this.TitleEdit.BackColor = System.Drawing.Color.White;
            this.TitleEdit.Location = new System.Drawing.Point(119, 15);
            this.TitleEdit.Name = "TitleEdit";
            this.TitleEdit.Size = new System.Drawing.Size(100, 20);
            this.TitleEdit.TabIndex = 20;
            // 
            // ArtistEdit
            // 
            this.ArtistEdit.BackColor = System.Drawing.Color.White;
            this.ArtistEdit.Location = new System.Drawing.Point(119, 38);
            this.ArtistEdit.Name = "ArtistEdit";
            this.ArtistEdit.Size = new System.Drawing.Size(100, 20);
            this.ArtistEdit.TabIndex = 21;
            // 
            // AlbumEdit
            // 
            this.AlbumEdit.BackColor = System.Drawing.Color.White;
            this.AlbumEdit.Location = new System.Drawing.Point(119, 61);
            this.AlbumEdit.Name = "AlbumEdit";
            this.AlbumEdit.Size = new System.Drawing.Size(100, 20);
            this.AlbumEdit.TabIndex = 22;
            // 
            // TrackEdit
            // 
            this.TrackEdit.BackColor = System.Drawing.Color.White;
            this.TrackEdit.Location = new System.Drawing.Point(348, 61);
            this.TrackEdit.Name = "TrackEdit";
            this.TrackEdit.Size = new System.Drawing.Size(100, 20);
            this.TrackEdit.TabIndex = 23;
            // 
            // YearEdit
            // 
            this.YearEdit.BackColor = System.Drawing.Color.White;
            this.YearEdit.Location = new System.Drawing.Point(589, 38);
            this.YearEdit.Name = "YearEdit";
            this.YearEdit.Size = new System.Drawing.Size(100, 20);
            this.YearEdit.TabIndex = 24;
            // 
            // GenreEdit
            // 
            this.GenreEdit.BackColor = System.Drawing.Color.White;
            this.GenreEdit.Location = new System.Drawing.Point(119, 84);
            this.GenreEdit.Name = "GenreEdit";
            this.GenreEdit.Size = new System.Drawing.Size(100, 20);
            this.GenreEdit.TabIndex = 25;
            // 
            // CommentEdit
            // 
            this.CommentEdit.BackColor = System.Drawing.Color.White;
            this.CommentEdit.Location = new System.Drawing.Point(347, 15);
            this.CommentEdit.Name = "CommentEdit";
            this.CommentEdit.Size = new System.Drawing.Size(100, 20);
            this.CommentEdit.TabIndex = 26;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(535, 90);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(154, 23);
            this.SaveButton.TabIndex = 28;
            this.SaveButton.Text = "Save Text Fields";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CopyrightEdit
            // 
            this.CopyrightEdit.BackColor = System.Drawing.Color.White;
            this.CopyrightEdit.Location = new System.Drawing.Point(589, 61);
            this.CopyrightEdit.Name = "CopyrightEdit";
            this.CopyrightEdit.Size = new System.Drawing.Size(100, 20);
            this.CopyrightEdit.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Open File/Read Tags";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxOpenFile
            // 
            this.textBoxOpenFile.AllowDrop = true;
            this.textBoxOpenFile.Location = new System.Drawing.Point(188, 276);
            this.textBoxOpenFile.Name = "textBoxOpenFile";
            this.textBoxOpenFile.Size = new System.Drawing.Size(497, 20);
            this.textBoxOpenFile.TabIndex = 32;
            this.textBoxOpenFile.Text = "C:\\temp\\test.mp3";
            // 
            // buttonRemoveAllTags
            // 
            this.buttonRemoveAllTags.Location = new System.Drawing.Point(294, 199);
            this.buttonRemoveAllTags.Name = "buttonRemoveAllTags";
            this.buttonRemoveAllTags.Size = new System.Drawing.Size(154, 23);
            this.buttonRemoveAllTags.TabIndex = 33;
            this.buttonRemoveAllTags.Text = "Remove All Tags";
            this.buttonRemoveAllTags.UseVisualStyleBackColor = true;
            this.buttonRemoveAllTags.Click += new System.EventHandler(this.buttonRemoveAllTags_Click);
            // 
            // buttonRemoveTitleTag
            // 
            this.buttonRemoveTitleTag.Location = new System.Drawing.Point(12, 199);
            this.buttonRemoveTitleTag.Name = "buttonRemoveTitleTag";
            this.buttonRemoveTitleTag.Size = new System.Drawing.Size(162, 23);
            this.buttonRemoveTitleTag.TabIndex = 34;
            this.buttonRemoveTitleTag.Text = "Remove \'Title\' Tag";
            this.buttonRemoveTitleTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTitleTag.Click += new System.EventHandler(this.buttonRemoveTitleTag_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 530);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(673, 178);
            this.textBoxLog.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.Location = new System.Drawing.Point(185, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "CHANGE THIS FILENAME - DRAG AND DROP TO IT AS WELL";
            // 
            // textBoxNewFieldName
            // 
            this.textBoxNewFieldName.Location = new System.Drawing.Point(119, 135);
            this.textBoxNewFieldName.Name = "textBoxNewFieldName";
            this.textBoxNewFieldName.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewFieldName.TabIndex = 37;
            // 
            // textBoxNewFieldValue
            // 
            this.textBoxNewFieldValue.Location = new System.Drawing.Point(284, 135);
            this.textBoxNewFieldValue.Name = "textBoxNewFieldValue";
            this.textBoxNewFieldValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewFieldValue.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(242, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(17, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 40;
            this.label3.Text = "New Field Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Create New Field and Load Tags";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnField,
            this.ColumnValue});
            this.dataGridViewData.Location = new System.Drawing.Point(191, 347);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(496, 150);
            this.dataGridViewData.TabIndex = 42;
            // 
            // ColumnField
            // 
            this.ColumnField.HeaderText = "Field";
            this.ColumnField.Name = "ColumnField";
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 43;
            this.button3.Text = "Save Grid Changes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(13, 511);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(25, 13);
            this.labelLog.TabIndex = 44;
            this.labelLog.Text = "Log";
            // 
            // MainForm
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(711, 720);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewFieldValue);
            this.Controls.Add(this.textBoxNewFieldName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonRemoveTitleTag);
            this.Controls.Add(this.buttonRemoveAllTags);
            this.Controls.Add(this.textBoxOpenFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TagExistsLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.ArtistLabel);
            this.Controls.Add(this.AlbumLabel);
            this.Controls.Add(this.TrackLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.GenreLabel);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TagExistsValue);
            this.Controls.Add(this.VersionValue);
            this.Controls.Add(this.SizeValue);
            this.Controls.Add(this.TitleEdit);
            this.Controls.Add(this.ArtistEdit);
            this.Controls.Add(this.AlbumEdit);
            this.Controls.Add(this.TrackEdit);
            this.Controls.Add(this.YearEdit);
            this.Controls.Add(this.GenreEdit);
            this.Controls.Add(this.CommentEdit);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CopyrightEdit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "APEtag Test";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private IContainer components;
        private Button button1;
        private TextBox textBoxOpenFile;
        public Button buttonRemoveAllTags;
        public Button buttonRemoveTitleTag;
        private TextBox textBoxLog;
        private Label label1;
        private TextBox textBoxNewFieldName;
        private TextBox textBoxNewFieldValue;
        public Label label2;
        public Label label3;
        private Button button2;
        private DataGridView dataGridViewData;
        private DataGridViewTextBoxColumn ColumnField;
        private DataGridViewTextBoxColumn ColumnValue;
        private Button button3;
        private Label labelLog;
        /*
private void FormCreate(object sender, EventArgs e)
{
// Initialization logic when the form loads
}

private void CloseButtonClick(object sender, EventArgs e)
{
this.Close(); // Logic for closing the form
}
*/
    }
}







/*
using System.Windows.Forms;

namespace Main
{
  partial class TMainForm
    {
        public System.Windows.Forms.Control InfoBevel;
        public System.Windows.Forms.PictureBox IconImage;
        public System.Windows.Forms.Label TagExistsLabel;
        public System.Windows.Forms.Label VersionLabel;
        public System.Windows.Forms.Label SizeLabel;
        public System.Windows.Forms.Label TitleLabel;
        public System.Windows.Forms.Label ArtistLabel;
        public System.Windows.Forms.Label AlbumLabel;
        public System.Windows.Forms.Label TrackLabel;
        public System.Windows.Forms.Label YearLabel;
        public System.Windows.Forms.Label GenreLabel;
        public System.Windows.Forms.Label CommentLabel;
        public System.Windows.Forms.Label CopyrightLabel;
        //public TDriveComboBox DriveList;
        //public TDirectoryListBox FolderList;
        //public TFileListBox FileList;
        public System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.TextBox TagExistsValue;
        public System.Windows.Forms.TextBox VersionValue;
        public System.Windows.Forms.TextBox SizeValue;
        public System.Windows.Forms.TextBox TitleEdit;
        public System.Windows.Forms.TextBox ArtistEdit;
        public System.Windows.Forms.TextBox AlbumEdit;
        public System.Windows.Forms.TextBox TrackEdit;
        public System.Windows.Forms.TextBox YearEdit;
        public System.Windows.Forms.TextBox GenreEdit;
        public System.Windows.Forms.TextBox CommentEdit;
        public System.Windows.Forms.Button RemoveButton;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.TextBox CopyrightEdit;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.InfoBevel = new System.Windows.Forms.Control();
            this.IconImage = new System.Windows.Forms.PictureBox();
            this.TagExistsLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.TrackLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            //this.DriveList = new TDriveComboBox();
            //this.FolderList = new TDirectoryListBox();
            //this.FileList = new TFileListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TagExistsValue = new System.Windows.Forms.TextBox();
            this.VersionValue = new System.Windows.Forms.TextBox();
            this.SizeValue = new System.Windows.Forms.TextBox();
            this.TitleEdit = new System.Windows.Forms.TextBox();
            this.ArtistEdit = new System.Windows.Forms.TextBox();
            this.AlbumEdit = new System.Windows.Forms.TextBox();
            this.TrackEdit = new System.Windows.Forms.TextBox();
            this.YearEdit = new System.Windows.Forms.TextBox();
            this.GenreEdit = new System.Windows.Forms.TextBox();
            this.CommentEdit = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CopyrightEdit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(293, 141);
            this.ClientSize  = new System.Drawing.Size(625, 409);
            this.Font  = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.ActiveControl = CloseButton;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            //this.StartPosition = poDefault;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScroll = true;
            this.Text = "APEtag Test";
            this.Closed += new System.EventHandler(this.FormClose);
            this.Name = "MainForm";
            this.InfoBevel.Size  = new System.Drawing.Size(497, 201);
            this.InfoBevel.Location  = new System.Drawing.Point(16, 192);
            this.InfoBevel.Name = "InfoBevel";
            this.InfoBevel.Enabled = true;
            ((System.ComponentModel.ISupportInitialize)(this.IconImage)).BeginInit();
            this.IconImage.Size  = new System.Drawing.Size(32, 32);
            this.IconImage.Location  = new System.Drawing.Point(552, 136);
            this.IconImage.AutoSize = true;
            this.IconImage.Name = "IconImage";
            this.IconImage.Enabled = true;
            this.TagExistsLabel.Size  = new System.Drawing.Size(65, 17);
            this.TagExistsLabel.Location  = new System.Drawing.Point(32, 208);
            this.TagExistsLabel.AutoSize = false;
            this.TagExistsLabel.Name = "TagExistsLabel";
            //this.TagExistsLabel.TextAlign = ContentAlignment.Center;;
            this.TagExistsLabel.Text = "Tag exists:";
            this.TagExistsLabel.Enabled = true;
            this.VersionLabel.Size  = new System.Drawing.Size(49, 17);
            this.VersionLabel.Location  = new System.Drawing.Point(176, 208);
            this.VersionLabel.AutoSize = false;
            this.VersionLabel.Name = "VersionLabel";
            //this.VersionLabel.TextAlign = HorizontalAlignment.Center;;
            this.VersionLabel.Text = "Version:";
            this.VersionLabel.Enabled = true;
            this.SizeLabel.Size  = new System.Drawing.Size(57, 17);
            this.SizeLabel.Location  = new System.Drawing.Point(304, 208);
            this.SizeLabel.AutoSize = false;
            this.SizeLabel.Name = "SizeLabel";
            //this.SizeLabel.TextAlign = HorizontalAlignment.Center;;
            this.SizeLabel.Text = "Size:";
            this.SizeLabel.Enabled = true;
            this.TitleLabel.Size  = new System.Drawing.Size(65, 17);
            this.TitleLabel.Location  = new System.Drawing.Point(32, 232);
            this.TitleLabel.AutoSize = false;
            this.TitleLabel.Name = "TitleLabel";
            //this.TitleLabel.TextAlign = HorizontalAlignment.Center;;
            this.TitleLabel.Text = "Title:";
            this.TitleLabel.Enabled = true;
            this.ArtistLabel.Size  = new System.Drawing.Size(65, 17);
            this.ArtistLabel.Location  = new System.Drawing.Point(32, 256);
            this.ArtistLabel.AutoSize = false;
            this.ArtistLabel.Name = "ArtistLabel";
            //this.ArtistLabel.TextAlign = HorizontalAlignment.Center;
            this.ArtistLabel.Text = "Artist:";
            this.ArtistLabel.Enabled = true;
            this.AlbumLabel.Size  = new System.Drawing.Size(65, 17);
            this.AlbumLabel.Location  = new System.Drawing.Point(32, 280);
            this.AlbumLabel.AutoSize = false;
            this.AlbumLabel.Name = "AlbumLabel";
            //this.AlbumLabel.TextAlign = HorizontalAlignment.Center;;
            this.AlbumLabel.Text = "Album:";
            this.AlbumLabel.Enabled = true;
            this.TrackLabel.Size  = new System.Drawing.Size(65, 17);
            this.TrackLabel.Location  = new System.Drawing.Point(32, 304);
            this.TrackLabel.AutoSize = false;
            this.TrackLabel.Name = "TrackLabel";
            //this.TrackLabel.TextAlign = HorizontalAlignment.Center;;
            this.TrackLabel.Text = "Track:";
            this.TrackLabel.Enabled = true;
            this.YearLabel.Size  = new System.Drawing.Size(49, 17);
            this.YearLabel.Location  = new System.Drawing.Point(176, 304);
            this.YearLabel.AutoSize = false;
            this.YearLabel.Name = "YearLabel";
            //this.YearLabel.TextAlign = HorizontalAlignment.Center;;
            this.YearLabel.Text = "Year:";
            this.YearLabel.Enabled = true;
            this.GenreLabel.Size  = new System.Drawing.Size(57, 17);
            this.GenreLabel.Location  = new System.Drawing.Point(304, 304);
            this.GenreLabel.AutoSize = false;
            this.GenreLabel.Name = "GenreLabel";
            //this.GenreLabel.TextAlign = HorizontalAlignment.Center;;
            this.GenreLabel.Text = "Genre:";
            this.GenreLabel.Enabled = true;
            this.CommentLabel.Size  = new System.Drawing.Size(65, 17);
            this.CommentLabel.Location  = new System.Drawing.Point(32, 328);
            this.CommentLabel.AutoSize = false;
            this.CommentLabel.Name = "CommentLabel";
            //this.CommentLabel.TextAlign = HorizontalAlignment.Center;;
            this.CommentLabel.Text = "Comment:";
            this.CommentLabel.Enabled = true;
            this.CopyrightLabel.Size  = new System.Drawing.Size(65, 17);
            this.CopyrightLabel.Location  = new System.Drawing.Point(32, 352);
            this.CopyrightLabel.AutoSize = false;
            this.CopyrightLabel.Name = "CopyrightLabel";
            //this.CopyrightLabel.TextAlign = HorizontalAlignment.Center;;
            this.CopyrightLabel.Text = "Copyright:";
            this.CopyrightLabel.Enabled = true;
            this.CloseButton.Size  = new System.Drawing.Size(83, 25);
            this.CloseButton.Location  = new System.Drawing.Point(528, 368);
            this.CloseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            this.CloseButton.Text = "Close";
            this.CloseButton.Enabled = true;
            this.CloseButton.TabIndex = 16;
            this.TagExistsValue.Size  = new System.Drawing.Size(49, 19);
            this.TagExistsValue.Location  = new System.Drawing.Point(104, 208);
            this.TagExistsValue.TabIndex = 3;
            this.TagExistsValue.Name = "TagExistsValue";
            this.TagExistsValue.ReadOnly = true;
            this.TagExistsValue.Enabled = true;
            this.TagExistsValue.TabStop = false;
            this.VersionValue.Size  = new System.Drawing.Size(49, 19);
            this.VersionValue.Location  = new System.Drawing.Point(232, 208);
            this.VersionValue.TabIndex = 4;
            this.VersionValue.Name = "VersionValue";
            this.VersionValue.ReadOnly = true;
            this.VersionValue.Enabled = true;
            this.VersionValue.TabStop = false;
            this.SizeValue.Size  = new System.Drawing.Size(129, 19);
            this.SizeValue.Location  = new System.Drawing.Point(368, 208);
            this.SizeValue.TabIndex = 5;
            this.SizeValue.Name = "SizeValue";
            this.SizeValue.ReadOnly = true;
            this.SizeValue.Enabled = true;
            this.SizeValue.TabStop = false;
            this.TitleEdit.Size  = new System.Drawing.Size(393, 21);
            this.TitleEdit.Location  = new System.Drawing.Point(104, 232);
            this.TitleEdit.MaxLength = 250;
            this.TitleEdit.Name = "TitleEdit";
            this.TitleEdit.Enabled = true;
            this.TitleEdit.TabIndex = 6;
            this.ArtistEdit.Size  = new System.Drawing.Size(393, 21);
            this.ArtistEdit.Location  = new System.Drawing.Point(104, 256);
            this.ArtistEdit.MaxLength = 250;
            this.ArtistEdit.Name = "ArtistEdit";
            this.ArtistEdit.Enabled = true;
            this.ArtistEdit.TabIndex = 7;
            this.AlbumEdit.Size  = new System.Drawing.Size(393, 21);
            this.AlbumEdit.Location  = new System.Drawing.Point(104, 280);
            this.AlbumEdit.MaxLength = 250;
            this.AlbumEdit.Name = "AlbumEdit";
            this.AlbumEdit.Enabled = true;
            this.AlbumEdit.TabIndex = 8;
            this.TrackEdit.Size  = new System.Drawing.Size(49, 21);
            this.TrackEdit.Location  = new System.Drawing.Point(104, 304);
            this.TrackEdit.MaxLength = 250;
            this.TrackEdit.Name = "TrackEdit";
            this.TrackEdit.Enabled = true;
            this.TrackEdit.TabIndex = 9;
            this.YearEdit.Size  = new System.Drawing.Size(49, 21);
            this.YearEdit.Location  = new System.Drawing.Point(232, 304);
            this.YearEdit.MaxLength = 250;
            this.YearEdit.Name = "YearEdit";
            this.YearEdit.Enabled = true;
            this.YearEdit.TabIndex = 10;
            this.GenreEdit.Size  = new System.Drawing.Size(129, 21);
            this.GenreEdit.Location  = new System.Drawing.Point(368, 304);
            this.GenreEdit.MaxLength = 250;
            this.GenreEdit.Name = "GenreEdit";
            this.GenreEdit.Enabled = true;
            this.GenreEdit.TabIndex = 11;
            this.CommentEdit.Size  = new System.Drawing.Size(393, 21);
            this.CommentEdit.Location  = new System.Drawing.Point(104, 328);
            this.CommentEdit.MaxLength = 250;
            this.CommentEdit.Name = "CommentEdit";
            this.CommentEdit.Enabled = true;
            this.CommentEdit.TabIndex = 12;
            this.RemoveButton.Size  = new System.Drawing.Size(81, 25);
            this.RemoveButton.Location  = new System.Drawing.Point(528, 328);
            this.RemoveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.Enabled = true;
            this.RemoveButton.TabIndex = 15;
            this.SaveButton.Size  = new System.Drawing.Size(81, 25);
            this.SaveButton.Location  = new System.Drawing.Point(528, 288);
            this.SaveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            this.SaveButton.Text = "Save";
            this.SaveButton.Enabled = true;
            this.SaveButton.TabIndex = 14;
            this.CopyrightEdit.Size  = new System.Drawing.Size(393, 21);
            this.CopyrightEdit.Location  = new System.Drawing.Point(104, 352);
            this.CopyrightEdit.MaxLength = 250;
            this.CopyrightEdit.Name = "CopyrightEdit";
            this.CopyrightEdit.Enabled = true;
            this.CopyrightEdit.TabIndex = 13;
            this.Controls.Add(InfoBevel);
            this.Controls.Add(IconImage);
            this.Controls.Add(TagExistsLabel);
            this.Controls.Add(VersionLabel);
            this.Controls.Add(SizeLabel);
            this.Controls.Add(TitleLabel);
            this.Controls.Add(ArtistLabel);
            this.Controls.Add(AlbumLabel);
            this.Controls.Add(TrackLabel);
            this.Controls.Add(YearLabel);
            this.Controls.Add(GenreLabel);
            this.Controls.Add(CommentLabel);
            this.Controls.Add(CopyrightLabel);
            this.Controls.Add(CloseButton);
            this.Controls.Add(TagExistsValue);
            this.Controls.Add(VersionValue);
            this.Controls.Add(SizeValue);
            this.Controls.Add(TitleEdit);
            this.Controls.Add(ArtistEdit);
            this.Controls.Add(AlbumEdit);
            this.Controls.Add(TrackEdit);
            this.Controls.Add(YearEdit);
            this.Controls.Add(GenreEdit);
            this.Controls.Add(CommentEdit);
            this.Controls.Add(RemoveButton);
            this.Controls.Add(SaveButton);
            this.Controls.Add(CopyrightEdit);
            ((System.ComponentModel.ISupportInitialize)(this.IconImage)).EndInit();
            this.ResumeLayout(false);
        }
#endregion

    }
}



*/