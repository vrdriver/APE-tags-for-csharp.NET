# APE Tags for C#.NET
This is a library for C#.NET to manipulate (**CRUD**) [APEv2 Metadata tags](https://wiki.hydrogenaud.io/index.php?title=APEv2_specification) in various files.
It was translated from the _LGPLv2 licenced_ [Audio Tools Library](http://mac.sourceforge.net/atl/ "Audio Tools Library"), and therefore I have continued the licence. Prior to this, I hadn't found any **_standalone_** C#.NET libraries that were working with APE tags specifically. Please note, things may or may not be the same as the original code with the same functionality though, or follow the same library methods.

The big question is why do this when [TagLib-Sharp](https://github.com/mono/taglib-sharp), [NAudio](https://github.com/naudio/NAudio), [JAudioTags](https://www.the-roberts-family.net/metadata/index.html), [atldotnet](https://github.com/Zeugma440/atldotnet) can do similar?
These projects cater for so many different formats, and they do what they do well, but when it comes to the APE tagging, they have limited **file** support, lack of custom fields, and metadata **type** support which seems to be self imposed, when in fact they generally don't need to be. I needed to be able to write HEX data to values, and I found the other libraries couldn't do this to my liking.
In short, as APEv2 tags append to the end of the files, this library _should_ allow you to read and write any field name (not just standard audio tag names), to basically any file and it's very small and has zero dependancies. Please note, you can break file formats of files in doing this too, so you have been warned. Having said that, you don't need to read the frame data of an MP3 file to see the APE metadata, the same with a Vorbis file, or a wma, wave, opus, ogg etc... this code purely looks at the tag information at the end of the file.

As mentioned, there is no restriction to the media file formats you can write and read to, if you choose to break a file, that's on you. This is only restricted at your own discretion (and yes, I have even tried adding and reading and writing to a plain text file of which it worked). 

USING THIS CODE YOU AGREE TO USE AT YOUR OWN RISK AND THAT YOU TAKE FULL RESPONSIBILITY WHICH STEMS FROM ANYTHING THAT COMES FROM USING IT.

Here is the sample application.

![Screenshot 2024-10-30 at 19 26 19](https://github.com/user-attachments/assets/83c7dbbd-7226-4763-88c1-72dad323c7c0)


This code process is fast and writes all tags at once, rather than individual read and write commands for each tag - unlike [tag](https://github.com/vrdriver/tag).


This library code only has basic options of reading, writing, deleting, updating and creating of the APE tags.

To **create** a tag you can use the following:


    AddTag("TITLE", "My Cool Song", fileName);


------------


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


------------


You can can also **update** tags individually as well.



    FileTag.UpdateField("Title", Encoding.UTF8.GetBytes(TitleEdit.Text));


------------


To **delete** a single tag:


    RemoveTag("TITLE", fileName);
To **delete all** of the tags


     RemoveAllTags(fileName);




------------



COPYRIGHT NOTICE

 Audio Tools Library
 Class TAPEtag - for manipulating with APE tags

 http://mac.sourceforge.net/atl/
 e-mail: macteam@users.sourceforge.net
 
 Copyright (c) 2000-2002 by Jurgen Faul
 Copyright (c) 2003-2005 by The MAC Team

 Version 2.10 (October 2024) by Stephen Monro
 - translated to C#.NET in version 7.3 style
 
 
 Version 2.1 (April 2005) by Gambit
 - updated to unicode file access
 
Version 2.0 (30 May 2003) by Jean-Marie Prat
- Writing support for APE 2.0 tags
- Removed UTF8 decoding since calling application is supposed to provide
or handle UTF8 strings.
- Removed direct tag infos. All fields are now stored into an array. A specific field can be requested using SeekField function.
- Introduced procedures to add/remove/order fields.
 
Version 1.0 (21 April 2002)
- Reading & writing support for APE 1.0 tags
- Reading support for APE 2.0 tags (UTF-8 decoding)
- Tag info: title, artist, album, track, year, genre, comment, copyright

This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the [GNU Lesser General Public License](https://www.gnu.org/licenses/old-licenses/lgpl-2.1.en.html "GNU Lesser General Public License") for more details.
 
You should have received a copy of the GNU Lesser General Public License along with this library; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
