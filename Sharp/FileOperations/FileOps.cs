using System;
using System.Text;
using System.Collections.Generic;
using Crestron.SimplSharp; // For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronIO; // For working with files
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Crestron.SimplSharp.CrestronXml;
using Crestron.SimplSharp.CrestronXml.Serialization;
using Crestron.SimplSharp.CrestronXmlLinq;
using System.Reflection;

namespace FileOperations
{
    public class FileOps
    {
        public FileOps() // default constructor
        {
        }

        // check if file is present and is okay to open. If so, read the file contents.
        #region

        private bool FileExists(string _folderLocation, string _fileName)
        {
            bool _folderExists = Directory.Exists(_folderLocation);

            if (_folderExists)
            {
                string[] _fileList = Directory.GetFiles(_folderLocation); // this returns the full path for the file
                for (int i = 0; i < _fileList.Length; i++)
                {
                    if (_fileList[i] == (_folderLocation + _fileName)) // OR _fileList[i].Equals(_folderLocation+_fileName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string readAFile(string folderLocation, string FileName)
        {
            bool okayToRead = FileExists(folderLocation, FileName); // check to see if file exists first
            string fullFilePath = folderLocation + FileName;
            string fileContents = "";

            if (okayToRead)
            {
                FileStream myStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read);
                byte[] fileBuffer = new byte[(int)myStream.Length];
                myStream.Read(fileBuffer, 0, (int)myStream.Length);
                fileContents = Encoding.ASCII.GetString(fileBuffer, 0, fileBuffer.Length);
                myStream.Close();
            }
            else
            {
                fileContents = "File not okay to read. Check path and name.";
            }
            return fileContents;
        }

        #endregion
        /*
        public class RootObject
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string ip_address { get; set; }
        }

        public string hiJason(string sourceLocation, string sourceName)
        {
            string fileContents = "";
            fileContents = readAFile(sourceLocation, sourceName);

            CrestronConsole.PrintLine("contents of file = {0}", fileContents);

            //int numBytes = Encoding.ASCII.GetByteCount(fileContents);
            //CrestronConsole.PrintLine("number of bytes found = {0}", numBytes);

            try
            {

                RootObject result = JsonConvert.DeserializeObject<RootObject>(fileContents);

                CrestronConsole.PrintLine("example item is = {0}", result.first_name);

                // print what you found after Deserialization
                
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Exception thrown = {0}",e);
                throw;
            }

            return "done.";
        }
*/
        /*
        public class Toyota
        {
            public string year { get; set; }
            public string model { get; set; }
        }

        public class Ford
        {
            public string year { get; set; }
            public string model { get; set; }
        }

        public class Subaru
        {
            public string year { get; set; }
            public string model { get; set; }
        }

        public class Cars
        {
            public Toyota toyota { get; set; }
            public Ford ford { get; set; }
            public Subaru subaru { get; set; }
        }
        */

        // Classes representing the Deserialization hierarchy of the JSON file.
        // provided through http://json2csharp.com/



        public class item
        {
            public string brand { get; set; }
            public string year { get; set; }
            public string model { get; set; }
        }

        public class cars
        {
            public List<item> theseItems { get; set; }
        }

        public class RootObject
        {
            public cars theseCars { get; set; }
        }

        public string hiJason(string sourceLocation, string sourceName)
        {
            string fileContents = "";
            fileContents = readAFile(sourceLocation, sourceName);

            CrestronConsole.PrintLine("contents of file = {0}", fileContents);

            int numBytes = Encoding.ASCII.GetByteCount(fileContents);
            CrestronConsole.PrintLine("number of bytes found = {0}", numBytes);

            try
            {

                RootObject result = JsonConvert.DeserializeObject<RootObject>(fileContents);

                CrestronConsole.PrintLine("example item is = {0}", result.theseCars.theseItems.ToString());

                // print what you found after Deserialization
                foreach (var thing in result.theseCars.theseItems)
                {
                    CrestronConsole.PrintLine("result = {0}, {1}, {2}", thing.brand, thing.model, thing.year);
                }

            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Exception thrown = {0}, {1}, {2}", e, e.InnerException, e.Message);
                throw;
            }

            return "done.";
        }


        // XML serialization region
        #region


        public string hiXML(string sourceLocation, string sourceName)
        {
            //string fileContents = "";
            //fileContents = readAFile(sourceLocation, sourceName);

            FileStream myStream;
            XmlReader myReader;

            try
            {
                myStream = new FileStream(sourceLocation + sourceName, FileMode.Open);
                myReader = new XmlReader(myStream);

                #region // Basic Method

                /*
                while (myReader.Read())
                {
                    switch (myReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (myReader.Name == "item")
                                CrestronConsole.PrintLine("found = {0}, {1}", myReader.Name, myReader.ReadInnerXml());
                            //if (myReader.Name == "item")
                            //    CrestronConsole.PrintLine("found = {0}, {1}", myReader.Name, myReader.ReadInnerXml());
                            //if (myReader.Name == "item")
                            //    CrestronConsole.PrintLine("found = {0}, {1}", myReader.Name, myReader.ReadInnerXml());
                            break;

                        case XmlNodeType.EndElement:                    //Display the end of the element.
                            break;

                        case XmlNodeType.XmlDeclaration:                //Version(?)
                            break;
                        default:
                            break;
                    }
                }

                #endregion
                #region // Method to access Descendant Elements using new instance of XmlReader

                */


                /*
                while (myReader.Read())
                {
                    switch (myReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (myReader.Name == "breakfast_menu")
                            {
                                XmlReader inner = myReader.ReadSubtree();
                                inner.ReadToDescendant("price");
                                CrestronConsole.PrintLine("price found = {0}, {1}", inner.Name, inner.ReadInnerXml());
                            }
                            break;
                    }
                }
                 * 
                 * */

                #endregion

                #region // XML Deserialization
                // not working due to <item xmlns="> was not expected.

                XDocument doc = XDocument.Parse(fileContents);
                XElement foodItems = doc.Element("food");
                IEnumerable<XElement> foodItemsElements = foodItems.Elements();

                foreach (XElement E in foodItemsElements)
                {
                    switch (E.Name)
                    {
                        case ("name"):
                            {
                                CrestronConsole.PrintLine("print the value here = {0}", E.Value);
                                break;
                            }
                        default:
                            break;
                        //Case for each element you could get.
                    }
                }
            }

                #endregion



            catch (Exception e)
            {
                CrestronConsole.PrintLine("Exception thrown = {0}", e);
                throw;
            }
            return "done.";

        #endregion
        }
    }
}
