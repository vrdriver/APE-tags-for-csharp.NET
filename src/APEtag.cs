// ***************************************************************************
// 
// Audio Tools Library
// Class TAPEtag - for manipulating with APE tags
//
// http://mac.sourceforge.net/atl/
// e-mail: macteam@users.sourceforge.net
// 
// Copyright (c) 2000-2002 by Jurgen Faul
// Copyright (c) 2003-2005 by The MAC Team
//
// Version 2.10 (October 2024) by Stephen Monro
// - translated to C#.NET in version 7.3 style
// 
// 
// Version 2.1 (April 2005) by Gambit
// - updated to unicode file access
// 
// Version 2.0 (30 May 2003) by Jean-Marie Prat
// - Writing support for APE 2.0 tags
// - Removed UTF8 decoding since calling application is supposed to provide
// or handle UTF8 strings.
// - Removed direct tag infos. All fields are now stored into an array. A
// specific field can be requested using SeekField function.
// - Introduced procedures to add/remove/order fields.
// 
// Version 1.0 (21 April 2002)
// - Reading & writing support for APE 1.0 tags
// - Reading support for APE 2.0 tags (UTF-8 decoding)
// - Tag info: title, artist, album, track, year, genre, comment, copyright
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ***************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APETag
{
    public struct RTagHeader
    {
        public string ID; // Changed to string for easier comparison
        public int Version;
        public int Size;
        public int Fields;
        public int Flags;
        public byte DataShift;
        public int FileSize;
    }
    
    public class RField
    {
        public string Name { get; set; }
        public byte[] Value { get; set; }  // Store raw bytes here
    }

    public class TAPETag
    {
        //private RField[] pField = Array.Empty<RField>();
        private RField[] pField = new RField[0]; // Alternative to Array.Empty<RField>()

        private bool pExists = false;
        private int pVersion = 0;
        private int pSize = 0;

        public bool Exists => pExists;
        public int Version => pVersion;
        public RField[] Fields => pField;
        public int Size => pSize;

        public TAPETag() => ResetData();

        public void ResetData()
        {
            pField = new RField[0]; // Initialize as an empty array
            pExists = false;
            pVersion = 0;
            pSize = 0;
        }

        private bool ReadFooter(string sFile, ref RTagHeader footer)
        {
            try
            {
                using (var sourceFile = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    footer.FileSize = (int)sourceFile.Length;

                    // Check for ID3v1 tag
                    if (footer.FileSize >= 128)
                    {
                        sourceFile.Seek(-128, SeekOrigin.End);
                        byte[] tagBytes = new byte[3];
                        sourceFile.Read(tagBytes, 0, 3);
                        if (Encoding.ASCII.GetString(tagBytes) == "TAG")
                        {
                            footer.DataShift = 128;
                        }
                    }

                    // Read APE footer
                    if (footer.FileSize >= footer.DataShift + 32)
                    {
                        sourceFile.Seek(-(footer.DataShift + 32), SeekOrigin.End);
                        byte[] footerBytes = new byte[32];
                        sourceFile.Read(footerBytes, 0, 32);

                        footer.ID = Encoding.ASCII.GetString(footerBytes, 0, 8);
                        footer.Version = BitConverter.ToInt32(footerBytes, 8);
                        footer.Size = BitConverter.ToInt32(footerBytes, 12);
                        footer.Fields = BitConverter.ToInt32(footerBytes, 16);
                        footer.Flags = BitConverter.ToInt32(footerBytes, 20);
                    }

                    return footer.ID == "APETAGEX";
                }
            }
            catch
            {
                return false;
            }
        }

        private void ReadFields(string sFile, RTagHeader footer)
        {
            try
            {
                using (var sourceFile = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // Position the stream to the start of the tag fields
                    sourceFile.Seek(footer.FileSize - footer.DataShift - footer.Size, SeekOrigin.Begin);
                    pField = new RField[footer.Fields];

                    for (int i = 0; i < footer.Fields; i++)
                    {
                        // Read the value size (4 bytes)
                        byte[] sizeBytes = new byte[4];
                        sourceFile.Read(sizeBytes, 0, 4);
                        int valueSize = BitConverter.ToInt32(sizeBytes, 0);

                        // Read the flags (4 bytes, not currently used)
                        byte[] flagsBytes = new byte[4];
                        sourceFile.Read(flagsBytes, 0, 4);

                        // Read the field name (null-terminated string)
                        StringBuilder fieldName = new StringBuilder();
                        char nextChar;
                        while ((nextChar = (char)sourceFile.ReadByte()) != 0)
                        {
                            fieldName.Append(nextChar);
                        }

                        // Read the field value
                        byte[] valueBytes = new byte[valueSize];
                        sourceFile.Read(valueBytes, 0, valueSize);

                        // Store the field data
                        pField[i] = new RField
                        {
                            Name = fieldName.ToString(),
                            Value = valueBytes // Store raw bytes for flexibility
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions gracefully (optional: log the error)
                Debug.WriteLine($"Error reading fields: {ex.Message}");
            }
        }

        public bool ReadFromFile(string sFile)
        {
            RTagHeader footer = new RTagHeader();
            ResetData();

            if (ReadFooter(sFile, ref footer))
            {
                pExists = true;
                pVersion = footer.Version;
                pSize = footer.Size;
                ReadFields(sFile, footer);
                return true;
            }

            return false;
        } 

        public List<KeyValuePair<string, byte[]>> ReadAllFields(string sFile, RTagHeader footer)
        {            
            List<KeyValuePair<string, byte[]>> fieldsList = new List<KeyValuePair<string, byte[]>>();

            try
            {
                using (var sourceFile = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    sourceFile.Seek(footer.FileSize - footer.DataShift - footer.Size, SeekOrigin.Begin);

                    for (int i = 0; i < footer.Fields; i++)
                    {
                        byte[] sizeBytes = new byte[4];
                        sourceFile.Read(sizeBytes, 0, 4);
                        int valueSize = BitConverter.ToInt32(sizeBytes, 0);

                        byte[] flagsBytes = new byte[4];
                        sourceFile.Read(flagsBytes, 0, 4);

                        StringBuilder fieldName = new StringBuilder();
                        char nextChar;
                        while ((nextChar = (char)sourceFile.ReadByte()) != 0)
                        {
                            fieldName.Append(nextChar);
                        }

                        byte[] valueBytes = new byte[valueSize];
                        sourceFile.Read(valueBytes, 0, valueSize);
                      //  string value = Encoding.UTF8.GetString(valueBytes).TrimEnd('\0');

                        //fieldsList.Add(new KeyValuePair<string, string>(fieldName.ToString(), value));
                        fieldsList.Add(new KeyValuePair<string, byte[]>(fieldName.ToString(), valueBytes));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading APE tag fields: {ex.Message}");
            }

            return fieldsList;
        }

        public List<KeyValuePair<string, byte[]>> ReadAllFromFile(string sFile)
        {
            RTagHeader footer = new RTagHeader();
            ResetData();

            if (ReadFooter(sFile, ref footer))
            {
                pExists = true;
                pVersion = footer.Version;
                pSize = footer.Size;
                return ReadAllFields(sFile, footer);
            }
            return null;
        }



        public bool RemoveTagFromFile(string sFile)
        {
            try
            {
                RTagHeader footer = new RTagHeader();
                if (ReadFooter(sFile, ref footer))
                {
                    using (var sourceFile = new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                    {
                        if (footer.DataShift == 128)
                        {
                            byte[] id3Bytes = new byte[128];
                            sourceFile.Seek(-128, SeekOrigin.End);
                            sourceFile.Read(id3Bytes, 0, 128);
                        }

                        if ((footer.Flags & (1 << 31)) != 0)
                        {
                            footer.Size += 32; // Adjust for header size
                        }

                        sourceFile.SetLength(footer.FileSize - footer.Size - footer.DataShift);
                    }
                    return true;
                }
            }
            catch
            {
                // Handle errors if necessary
            }

            return false;
        }
               


        public class APETagUnit
        {
            // Tag Identifiers
            public const string ID3V1_ID = "TAG";           // ID3v1 tag identifier
            public const string APE_ID = "APETAGEX";        // APEv2 tag identifier

            // Size Constants
            public const int ID3V1_TAG_SIZE = 128;          // ID3v1 tag size
            public const int APE_TAG_FOOTER_SIZE = 32;      // APEv2 footer size
            public const int APE_TAG_HEADER_SIZE = 32;      // APEv2 header size

            // APEv2 Version
            public const int APE_VERSION_1_0 = 1000;        // APEv1 version
            public const int APE_VERSION_2_0 = 2000;        // APEv2 version
        }
          
        public bool WriteTagInFile(string sFile)
        {
            try
            {
                byte[] ID3 = null; // ID3v1 tag, if present.
                int tagSize = APETagUnit.APE_TAG_FOOTER_SIZE;
                int flags = 0; // Default field flags.

                using (MemoryStream tagData = new MemoryStream())
                {
                    // Read the existing APEv2 footer if present.
                    RTagHeader refFooter = new RTagHeader();
                    bool footerExists = ReadFooter(sFile, ref refFooter);

                    if (footerExists && Encoding.ASCII.GetBytes(refFooter.ID)
                            .SequenceEqual(Encoding.ASCII.GetBytes(APETagUnit.APE_ID)))
                    {
                        using (FileStream sourceFile = new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite))
                        {
                            // Check for ID3v1 tag at the end of the file.
                            if (refFooter.DataShift == APETagUnit.ID3V1_TAG_SIZE)
                            {
                                ID3 = new byte[APETagUnit.ID3V1_TAG_SIZE];
                                sourceFile.Seek(-APETagUnit.ID3V1_TAG_SIZE, SeekOrigin.End);
                                sourceFile.Read(ID3, 0, ID3.Length);
                            }

                            if ((refFooter.Flags & (1 << 31)) != 0)
                            {
                                refFooter.Size += APETagUnit.APE_TAG_HEADER_SIZE;
                            }

                            sourceFile.SetLength(refFooter.FileSize - refFooter.Size - refFooter.DataShift);
                        }
                    }

                    // Calculate total tag size including all fields.
                    foreach (var field in Fields ?? Enumerable.Empty<RField>())
                    {
                        // Validate the field name and value
                        string sanitizedFieldName = SanitizeFieldName(field.Name);
                        byte[] sanitizedValue = SanitizeFieldValue(field.Value);

                        // Recalculate field size based on sanitized data
                        int fieldSize = 8 + sanitizedFieldName.Length + 1 + sanitizedValue.Length; // +1 for null terminator
                        tagSize += fieldSize;
                    }

                    // Write APEv2 header
                    WriteHeaderOrFooter(tagData, tagSize, Fields?.Count() ?? 0, isHeader: true);

                    // Write all tag fields to the stream
                    foreach (var field in Fields ?? Enumerable.Empty<RField>())
                    {
                        string sanitizedFieldName = SanitizeFieldName(field.Name);
                        byte[] sanitizedValue = SanitizeFieldValue(field.Value);

                        byte[] nameBytes = Encoding.UTF8.GetBytes(sanitizedFieldName + '\0'); // Null-terminate field name

                        tagData.Write(BitConverter.GetBytes(sanitizedValue.Length), 0, 4); // Write value size (little-endian)
                        tagData.Write(BitConverter.GetBytes(flags), 0, 4); // Write field flags
                        tagData.Write(nameBytes, 0, nameBytes.Length); // Write field name
                        tagData.Write(sanitizedValue, 0, sanitizedValue.Length); // Write field value
                    }

                    // Write APEv2 footer
                    WriteHeaderOrFooter(tagData, tagSize, Fields?.Count() ?? 0, isHeader: false);

                    // Append ID3v1 tag if present
                    if (ID3 != null)
                    {
                        tagData.Write(ID3, 0, ID3.Length);
                    }

                    // Write the tag data to the file
                    using (FileStream sourceFile = new FileStream(sFile, FileMode.Append, FileAccess.Write))
                    {
                        tagData.Seek(0, SeekOrigin.Begin);
                        tagData.CopyTo(sourceFile);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing tag to file: {ex.Message}");
                return false;
            }
        }

        // These are just in case a null value is entered inside a field name or value.
        private string SanitizeFieldName(string fieldName)
        {
            if (fieldName.Contains('\0'))
            {
                //Debug.WriteLine($"Field name '{fieldName}' contains null bytes and will be sanitized.");
                fieldName = fieldName.Replace("\0", string.Empty); // Remove null bytes
            }
            return fieldName.Trim(); // Trim unnecessary whitespace
        }

        private byte[] SanitizeFieldValue(byte[] value)
        {
            // Replace null bytes with a default value or remove them
            if (value.Contains((byte)0))
            {
                //Debug.WriteLine("Field value contains null bytes and will be sanitized.");
                value = value.Where(b => b != 0).ToArray();
            }
            return value;
        }


        private void WriteHeaderOrFooter(MemoryStream stream, int size, int fieldCount, bool isHeader)
        {
            byte[] header = new byte[APETagUnit.APE_TAG_HEADER_SIZE];

            // Write "APETAGEX" (8 bytes)
            Array.Copy(Encoding.ASCII.GetBytes(APETagUnit.APE_ID), header, 8);

            // Write version 2000 (4 bytes, little-endian)
            BitConverter.GetBytes(APETagUnit.APE_VERSION_2_0).CopyTo(header, 8);

            // Write tag size (including both header and footer if present)
            BitConverter.GetBytes(size).CopyTo(header, 12);

            // Write field count (number of fields in the tag)
            BitConverter.GetBytes(fieldCount).CopyTo(header, 16);

            // Set flags (header or footer flags)
            int flags = isHeader ? (1 << 29) | (1 << 31) : (1 << 31);  // Header includes header-present flag.
            BitConverter.GetBytes(flags).CopyTo(header, 20);

            // Reserved space (12 bytes set to 0)
            Array.Clear(header, 24, 8);

            // Write header/footer to the stream
            stream.Write(header, 0, header.Length);
        }
         

        // Insert field so that it has position pos
        // ----------------------------------------------------------------------------
        public void RemoveField(int pos)
        {
            int i;
            if (pos > pField.Length)
            {
                return;
            }
            for (i = pos + 1; i <= pField.GetUpperBound(0); i++)
            {
                Fields[i - 1] = Fields[i];
            }
            pField = new RField[pField.Length - 1];
        }

        // ----------------------------------------------------------------------------
         

        public void AppendField(string name, byte[] value)
        {
            Array.Resize(ref pField, pField.Length + 1);
            pField[pField.Length - 1] = new RField { Name = name, Value = value };
        }         

        public void UpdateField(string name, byte[] value)
        {
            bool fieldExists = false;

            // Check if the field exists and update it if found
            for (int i = 0; i < pField.Length; i++)
            {
                if (pField[i].Name == name)
                {
                    pField[i].Value = value;
                    fieldExists = true;
                    break;
                }
            }

            // If not found, append it
            if (!fieldExists)
            {
                AppendField(name, value);
            }
        }

         
        public string SeekField(string fieldName)
        {
            if (Fields == null || Fields.Length == 0)
            {
                return null;  // Return null if Fields is not initialized or empty.
            }

            for (int i = 0; i < Fields.Length; i++)
            {
                if (string.Equals(fieldName, Fields[i].Name, StringComparison.OrdinalIgnoreCase))
                {
                    var value = Fields[i].Value;

                    // Check if value contains non-ASCII data.
                    if (IsBinaryData(value))
                    {
                        return BitConverter.ToString(value).Replace("-", " "); // Return hex string.
                    }
                    else
                    {
                        return Encoding.UTF8.GetString(value);  // Return as string if valid UTF-8.
                    }
                }
            }

            return null;  // Return null if the field is not found.
        }

        // Helper function to determine if the byte array contains non-ASCII characters.
        private bool IsBinaryData(byte[] data)
        {
            foreach (byte b in data)
            {
                if (b < 32 || b > 126) // ASCII printable range (32-126)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
