using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace DBconverter
{
    public class Csvwriter
    {
        
        public string csvmonth;
        public string csvyear;
        public string csvpath;

        private StringBuilder csv;
        private string path;

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
