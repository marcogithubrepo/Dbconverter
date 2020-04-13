using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text;

namespace DBconverter
{
    public class Csvwriter
    {
        StringBuilder csv;
        string path;

        public bool opencsv(string csvname)
        {

                path = @"C:\Users\Marco\source\repos\DBconverter\DBconverter\" + csvname;
                csv = new StringBuilder();
               


            return true;

        }


        public bool Write(string leggi)
        {
            // This text is added only once to the file.
            if (File.Exists(path))
            {
                csv.AppendLine(leggi);

                //after your loop
                File.WriteAllText(path, csv.ToString());
            }
            else
            {
                return false;
            }

            return true;

        }                                                               

    }



}
