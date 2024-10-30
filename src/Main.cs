using System;
using System.Windows.Forms;
using System.IO;
using APETag;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
 

namespace Main
{
    public partial class MainForm : Form
    {
        // Private declarations
        public TAPETag FileTag = null;             

        public MainForm()
        {
            InitializeComponent();
            textBoxOpenFile.DragEnter += new DragEventHandler(textBoxOpenFile_DragEnter);
            textBoxOpenFile.DragDrop += new DragEventHandler(textBoxOpenFile_DragDrop);
        }

        private void textBoxOpenFile_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Show a copy cursor
            else
                e.Effect = DragDropEffects.None; // No valid data
        }

        private void textBoxOpenFile_DragDrop(object sender, DragEventArgs e)
        {
            // Get the file paths from the drag-and-drop operation
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Check if at least one file was dropped
            if (files.Length > 0)
            {
                // Set the textbox to the first file path only
                textBoxOpenFile.Text = files[0];
            }
        }

        private void ClearAll()
        {
            // Clear all captions
            TagExistsValue.Text = "";
            VersionValue.Text = "";
            SizeValue.Text = "";
            TitleEdit.Text = "";
            ArtistEdit.Text = "";
            AlbumEdit.Text = "";
            TrackEdit.Text = "";
            YearEdit.Text = "";
            GenreEdit.Text = "";
            CommentEdit.Text = "";
            CopyrightEdit.Text = "";
        }

        


        private void SaveButton_Click(object sender, EventArgs e)
        { 
            SaveTags(); 
        }

        public void SaveTags()
        {
            string fileName = textBoxOpenFile.Text;


            if (!FileTag.ReadFromFile(fileName))
            {
                // Save tag data
                if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
                {
                    // Saving empty tags so we can do the write.             
                }
            }


            FileTag = new TAPETag();
            // Load tag data
            if (FileTag.ReadFromFile(fileName))
            {
                

                // Read existing tag fields from the file
                List<KeyValuePair<string, byte[]>> existingFields = FileTag.ReadAllFromFile(fileName);

                // Loop through the existing fields and re-add them using AppendField
                foreach (var field in existingFields)
                {
                    // This does work, but not for binary weird data.
                    // Gotta work on this.
                    FileTag.AppendField(field.Key.ToString(), field.Value);
                }

                // Now you can add new or updated fields based on UI input
                // Only append if the field already exists (or handle logic accordingly)
                if (!string.IsNullOrEmpty(TitleEdit.Text))
                {
                    FileTag.UpdateField("Title", Encoding.UTF8.GetBytes(TitleEdit.Text));
                }

                if (!string.IsNullOrEmpty(ArtistEdit.Text))
                {
                    FileTag.UpdateField("Artist", Encoding.UTF8.GetBytes(ArtistEdit.Text));
                }

                if (!string.IsNullOrEmpty(AlbumEdit.Text))
                {
                    FileTag.UpdateField("Album", Encoding.UTF8.GetBytes(AlbumEdit.Text));
                }

                if (!string.IsNullOrEmpty(TrackEdit.Text))
                {
                    FileTag.UpdateField("Track", Encoding.UTF8.GetBytes(TrackEdit.Text));
                }

                if (!string.IsNullOrEmpty(YearEdit.Text))
                {
                    FileTag.UpdateField("Year", Encoding.UTF8.GetBytes(YearEdit.Text));
                }

                if (!string.IsNullOrEmpty(GenreEdit.Text))
                {
                    FileTag.UpdateField("Genre", Encoding.UTF8.GetBytes(GenreEdit.Text));
                }

                if (!string.IsNullOrEmpty(CommentEdit.Text))
                {
                    FileTag.UpdateField("Comment", Encoding.UTF8.GetBytes(CommentEdit.Text));
                }

                if (!string.IsNullOrEmpty(CopyrightEdit.Text))
                {
                    FileTag.UpdateField("Copyright", Encoding.UTF8.GetBytes(CopyrightEdit.Text));
                }
            } 


            // Save tag data
            if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
            {
                MessageBox.Show($"Cannot save tag to the file: {fileName}");
            }
        }


        public void GridSaveTags()
        {
            string fileName = textBoxOpenFile.Text;

            if (!FileTag.ReadFromFile(fileName))
            {
                // Save tag data
                if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
                {
                    // Saving empty tags so we can do the write.             
                }
            }

            FileTag = new TAPETag();

            // Load tag data
            if (FileTag.ReadFromFile(fileName))
            {
                // Read existing tag fields from the file
                List<KeyValuePair<string, byte[]>> existingFields = FileTag.ReadAllFromFile(fileName);

                // Loop through the existing fields and re-add them using AppendField
                foreach (var field in existingFields)
                {
                    FileTag.AppendField(field.Key, field.Value);
                }

                // Add or update fields from DataGridView
                foreach (DataGridViewRow row in dataGridViewData.Rows)
                {
                    if (row.Cells["ColumnField"].Value != null && row.Cells["ColumnValue"].Value != null)
                    {
                        string fieldKey = row.Cells["ColumnField"].Value.ToString();
                        string fieldValue = row.Cells["ColumnValue"].Value.ToString();

                        // Convert the field value to bytes using UTF-8 encoding
                        byte[] fieldValueBytes = Encoding.UTF8.GetBytes(fieldValue);

                        // Update or add the field in the FileTag
                        FileTag.UpdateField(fieldKey, fieldValueBytes);
                    }
                }
            }

            // Save tag data
            if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
            {
                MessageBox.Show($"Cannot save tag to the file: {fileName}");
            }
        }




        public void RemoveTag(string tagName, string fileName)
        {
            // Read existing tag fields from the file
            List<KeyValuePair<string, byte[]>> existingFields = FileTag.ReadAllFromFile(fileName);

            // Loop through existing fields and conditionally append them to the tag
            foreach (var field in existingFields)
            {
                // Only append the field if it's not the one we want to remove
                if (!string.Equals(field.Key, tagName, StringComparison.OrdinalIgnoreCase))
                {
                    // Append the field back to the tag
                    FileTag.AppendField(field.Key.ToString(), field.Value);
                }
            }

            // Save tag data
            if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
            {
                MessageBox.Show($"Canndot save tag to the file: {fileName}");
            }

        }


        public void RemoveAllTags(string fileName)
        {
            // Read existing tag fields from the file
            List<KeyValuePair<string, byte[]>> existingFields = FileTag.ReadAllFromFile(fileName);

            // Clear all fields from the tag (do not re-add any)
            foreach (var field in existingFields)
            {
                // You can log or debug to see which fields are being removed if necessary
                Debug.WriteLine($"Removing tag: {field.Key}");

                textBoxLog.AppendText($"Removing tag: {field.Key}\n\r\n\r");
            }
                        
            // Save tag data (this will effectively remove all tags)
            if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
            {
                MessageBox.Show($"Cannot save tag to the file: {fileName}");
            }
        }

        public void AddTag(string tagName, byte[] tagValue, string fileName)
        {

            // Create a new tag.

            if (!FileTag.ReadFromFile(fileName))
            {
                // Save tag data
                if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
                {
                    // Saving empty tags so we can do the write.             
                }
            }


            FileTag = new TAPETag();
            // Load tag data
            if (FileTag.ReadFromFile(fileName))
            {


                // Read existing tag fields from the file
                List<KeyValuePair<string, byte[]>> existingFields = FileTag.ReadAllFromFile(fileName);

                // Loop through the existing fields and re-add them using AppendField
                foreach (var field in existingFields)
                {
                    // This does work, but not for binary weird data.
                    // Gotta work on this.
                    FileTag.AppendField(field.Key.ToString(), field.Value);
                }

            }
             

            // Append the new tag to the list of fields
            FileTag.AppendField(tagName, tagValue);








            // Save the updated tag data to the file
            if (!File.Exists(fileName) || !FileTag.WriteTagInFile(fileName))
            {
                MessageBox.Show($"Cannot save tag to the file: {fileName}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile(textBoxOpenFile.Text); 
        }

        private RTagHeader GetFooter()
        {
            // Placeholder: Initialize and return your footer object here.
            return new RTagHeader();
        }


        private void ReadFile(string fileName) 
        {

            // Clear captions
            ClearAll();  

            if (textBoxOpenFile.Text == "") // Update this based on actual control type
            {
                return;
            }
                        
            if (File.Exists(fileName))
            {

                // Make sure FileTag is properly initialized
                //TAPETag fileTag = new FileTag(); // Example of initialization
                //FileTag fileTag = new FileTag(); // Example of initialization
                                                 
                FileTag = new TAPETag();
                // Load tag data
                if (FileTag.ReadFromFile(fileName))
                {
                    if (FileTag.Exists)
                    {
                        // Fill captions
                        TagExistsValue.Text = "Yes";
                        VersionValue.Text = FileTag.Version.ToString("N0"); // Formats the version with commas
                        SizeValue.Text = $"{FileTag.Size} bytes";

                        TitleEdit.Text = FileTag.SeekField("Title");
                        ArtistEdit.Text = FileTag.SeekField("Artist");
                        AlbumEdit.Text = FileTag.SeekField("Album");
                        TrackEdit.Text = FileTag.SeekField("Track");

                        YearEdit.Text = FileTag.SeekField("Year");
                        GenreEdit.Text = FileTag.SeekField("Genre");
                        CommentEdit.Text = FileTag.SeekField("Comment");
                        CopyrightEdit.Text = FileTag.SeekField("Copyright");

                        textBoxLog.AppendText("\n\r");
                        textBoxLog.AppendText("**********************************\n\r\n\r");
                        textBoxLog.AppendText("Filename: " +fileName.ToString() + "\n\r");

                        List<KeyValuePair<string, byte[]>> fields = (FileTag.ReadAllFromFile(fileName));


                        dataGridViewData.Rows.Clear(); 

                        foreach (var field in fields)
                        {
                            // Convert the byte array to a string using UTF-8 encoding
                            string valueAsText = Encoding.UTF8.GetString(field.Value);
                            Debug.WriteLine($"{field.Key}: {valueAsText}");
                            textBoxLog.AppendText($"{field.Key}: {valueAsText}" + "\n\r");
                            textBoxLog.AppendText("\n\r");


                            // Add each field to the DataGridView
                            dataGridViewData.Rows.Add(field.Key, valueAsText);


                        }

                    }
                    else
                    {
                        // Tag not found
                        TagExistsValue.Text = "No";
                    } 

                }
                else
                {
                    // Read error
                    MessageBox.Show($"Cannot read any tags from the file: {fileName}");
                }                 

            }
            else
            {
                // File does not exist
                MessageBox.Show($"The file does not exist: {fileName}");
            }

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonRemoveAllTags_Click(object sender, EventArgs e)
        {

            string fileName = textBoxOpenFile.Text;
            RemoveAllTags(fileName);

        }

        private void buttonRemoveTitleTag_Click(object sender, EventArgs e)
        {

            string fileName = textBoxOpenFile.Text;

            RemoveTag("TITLE", fileName);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            AddTag(textBoxNewFieldName.Text, Encoding.UTF8.GetBytes(textBoxNewFieldValue.Text), textBoxOpenFile.Text);

            textBoxNewFieldName.Text = "";
            textBoxNewFieldValue.Text = "";

            SaveTags();

            ReadFile(textBoxOpenFile.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GridSaveTags();
        }
    } // end TMainForm

    public class MainUnit
    {
        public static MainForm MainForm = null;
    }
    // end Main



    static class Program
    {
        // Main method, the entry point of the application
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run the main form
            Application.Run(new MainForm());
        }
    } 
}

