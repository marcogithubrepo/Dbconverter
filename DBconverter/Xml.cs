using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DBconverter
{
    class Xml
    {
        public XmlReader reader = null;

        public List<List<String>> databaseinfo = new List<List<String>>(); //Creates new nested List
        public string dbpath = null;
        public string csvpath = null;
        private int databasecounter = 0;

        public Xml()
        {

            readxml();


        }

        public bool readxml()
        { 

            try
            {
                //check connection status
                reader = XmlReader.Create(@"xml.xml");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    //return only when you have START tag  
                    switch (reader.Name.ToString())
                    {
                        case "Dbpath":
                            dbpath = reader.ReadString();
                            break;
                        case "Csvpath":
                            csvpath = reader.ReadString();
                            break;
                        case "Dbname":
                            databaseinfo.Add(new List<String>());
                            databaseinfo[databasecounter].Add(reader.ReadString());
                            break;
                        case "Csv":
                            databaseinfo[databasecounter].Add(reader.ReadString());
                            databasecounter++;
                            break;
                    }
                }


            }


            return true;

        }
    }
}










    

