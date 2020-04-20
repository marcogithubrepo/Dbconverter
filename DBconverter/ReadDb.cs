using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace DBconverter
{
    public class ReadDb
    {
        private SQLiteConnection con = null;
        private Csvwriter Csvwriter = new Csvwriter();

        private string _dbmonth;
        private string _dbyear;
        private string _dbpath;
        private int _fieldtoread;


        public string dbmonth
        {
            get { return _dbmonth; }
            set { _dbmonth = value; }
        }

        public string dbyear
        {
            get { return _dbyear; }
            set { _dbyear = value; }
        }

        public string dbpath
        {
            get { return _dbpath; }
            set { _dbpath = value; }
        }

        public int fieldtoread
        {
            get { return _fieldtoread; }
            set { _fieldtoread = value; }
        }


        public ReadDb(Csvwriter csv)
        {
            Csvwriter = csv;
        }

        ~ReadDb()
        {
                CloseConnection();
        }

        public bool OpenConnection(string dbname, string csname)
        {
           
            Csvwriter.Opencsv(csname); // to set on mainframe

            string cs = @"URI=file:" + dbpath + dbmonth + " " + dbyear + @"\" + dbname;

            try
            {
                con = new SQLiteConnection(cs);

                if (!File.Exists(dbpath + dbmonth + " " + dbyear + @"\" + dbname))
                {
                    //LOG db file non trovato
                    return false;
                }


                if (con.State != ConnectionState.Open)
                    con.Open();
                else
                {
                    //LOG db file already open
                    return false;
                }

            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                Console.WriteLine(e);

                //LOG error opening db file
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
                else {

                    //Log SQLiteConnection in null before closing
                    return false;
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

            //Get all tables name
            List<string> tables = new List<string>();
            DataTable dt = con.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }


            //select tables #2
            string stm = "SELECT * FROM " + tables[1] ;
            var cmd = new SQLiteCommand(stm, con);

            SQLiteDataReader rdr = cmd.ExecuteReader();

            int fieldtocount = this.fieldtoread;
            if (rdr.FieldCount < fieldtocount)
                fieldtocount = rdr.FieldCount;

            string leggititolo = null;


            //Read title try/catch
            try
            {
               
            //Read all field in a row
            for (int i = 0; i < fieldtocount; i++)
            {
                if (i == fieldtocount)
                    leggititolo += rdr.GetName(i);
                else
                    leggititolo += rdr.GetName(i) + ",";

            }

            Csvwriter.Writecsv(leggititolo);
            }
            catch (InvalidOperationException e)
            {
                //LOG
                Console.WriteLine(e);
                return false;  
            }

            string leggi = null;
            int countline = 0;//to remove

            //set number of field to count



            //Read lines try/catch
            try
            {
                leggi = null;
                while (rdr.Read() /*&& countline < 5000*/)
                {
                    countline++;


                    //Read all field in a row
                    for (int i = 0; i < fieldtocount; i++)
                    {
                        if (i == fieldtocount - 1)
                            leggi += rdr.GetString(i) + " \n";
                        else
                            leggi += rdr.GetString(i) + ",";

                    }

                    var howManyBytes = leggi.Length * sizeof(Char);
                    if (howManyBytes > 5000000)
                    {
                        if (!Csvwriter.Writecsv(leggi))
                            return false;
                        leggi = null;
                    }


                }
                
                if (!Csvwriter.Writecsv(leggi))
                    return false;
            }
            catch (InvalidOperationException e)
            {          
                //LOG
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

    }


}
