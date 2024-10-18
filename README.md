# APE Tags for C#.NET
This is a library for C#.NET to manipulate (**CRUD**) APEv2 tags in various files.
The formats will only be restricted at your own discretion. 

This code writes all tags at once, rather than individually (unlike https://github.com/vrdriver/tag), so it will increase write speeds, 

This only has basic options of reading, writing, deleting, updating and creating of the APE tags.


You can **read** data it like this to get individual tags.

    
    
    string filename = "test.mp3";
    
    FileTag = new TAPETag();
    
    if (FileTag.ReadFromFile(fileName))
    {
        if (FileTag.Exists)
        {
            // Search for a field and get the returned string.
            Debug.WriteLine ( FileTag.SeekField("Title") );
            Debug.WriteLine ( FileTag.SeekField("Title") );
        }
    }
     
Or, if you need to go more crazy with fields that are not stored in ASCII charaters, such as with HEX values, you can do that too.

With this method, you can **read** all the tags at once too rather having to guess which tags are stored.



    List<KeyValuePair<string, byte[]>> fields = (FileTag.ReadAllFromFile(fileName));
                            
    foreach (var field in fields)
    {
        // Convert the byte array to a string using UTF-8 encoding
        string valueAsText = Encoding.UTF8.GetString(field.Value);
        Debug.WriteLine($"{field.Key}: {valueAsText}");                            
    }
	
You can can also **write** tags individually as well.



    FileTag.UpdateField("Title", Encoding.UTF8.GetBytes(TitleEdit.Text));
