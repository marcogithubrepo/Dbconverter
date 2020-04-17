using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace DBconverter
{
    public class Csvwriter
    {
        
        private string _csvmonth;
        private string _csvyear;
        private string _csvpath;

        public string csvmonth
        {
            get { return _csvmonth; }
            set { _csvmonth = value; }
        }

        public string csvyear
        {
            get { return _csvyear; }
            set { _csvyear = value; }
        }

        public string csvpath
        {
            get { return _csvpath; }
            set { _csvpath = value; }
        }

        private string path;
        private StringBuilder csv;

        public Csvwriter()
        {

        }

         ~Csvwriter()
        {
            //csv.Clear();
        }

        public bool Opencsv(string csvname)
        {

            path =  csvpath + csvyear + @"\" + csvname;

            try
            {
                csv = new StringBuilder();
            }          
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
               
             return true;

        }

        public bool Writecsv(string leggi)
        {

            try
            {
                csv.AppendLine(leggi);
                File.WriteAllText(path, csv.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }  
        
    }

}
