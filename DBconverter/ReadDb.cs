using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Text;

namespace DBconverter
{
    public class ReadDb
    {
        SQLiteConnection con = null;
        Csvwriter Csvwriter = new Csvwriter();

        public ReadDb()
        {
           
        }

        ~ReadDb()
        {
           // if (con.State == ConnectionState.Open)
                CloseConnection();
        }

        public bool OpenConnection(string dbpath, string csvpath)
        {
            Csvwriter.opencsv(csvpath);

            string cs = @"URI=file:C:\Users\Marco\source\repos\DBconverter\DBconverter\" + dbpath;

            try
            {
                con = new SQLiteConnection(cs);
                con.Open();

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
            

            return true;

        }

        public bool CloseConnection()
        {

            try
            {
                //check connection status
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;


        }

        public bool ReadFile()
        {
            //Read all db file
           
            string stm = "SELECT * FROM sql_94255_LocMATING_10W";
            var cmd = new SQLiteCommand(stm, con);

            SQLiteDataReader rdr = cmd.ExecuteReader();

            string leggititolo = null;

            //Read all field in a row
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                if (i == rdr.FieldCount)
                    leggititolo += rdr.GetName(i);
                else
                    leggititolo += rdr.GetName(i) + ",";

            }

            Csvwriter.Write(leggititolo);

            string leggi = null;

            int countline = 0;

            
            while (rdr.Read() && countline<20)
            {
                countline++;

                try
                {
                    leggi = null;

                    //Read all field in a row
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (i == rdr.FieldCount)
                            leggi += rdr.GetString(i);
                        else
                            leggi += rdr.GetString(i) + ",";

                    }

                    if (!Csvwriter.Write(leggi))
                        return false;

                }
                catch (InvalidOperationException e)
                {
                    return false;

                    Console.WriteLine(e);
                }
            


            }
            return true;
        }

       
    }
}
