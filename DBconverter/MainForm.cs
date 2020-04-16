using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;




namespace DBconverter
{
    public partial class MainForm : Form
    {
        ReadDb save;
        Xml xmldatabase;
        Csvwriter Csvwriter;

        ImageList imageList;
        private int dbreadresult;

        //public delegate void SafeCallDelegate();

        public MainForm()
        {
            xmldatabase = new Xml();      
            Csvwriter = new Csvwriter();
            save = new ReadDb(Csvwriter);
            InitializeComponent();

            //comboboxitem
            comboBoxmonth.Items.Add("January");
            comboBoxmonth.Items.Add("February");
            comboBoxmonth.Items.Add("March");
            comboBoxmonth.Items.Add("April");
            comboBoxmonth.Items.Add("May");
            comboBoxmonth.Items.Add("June");
            comboBoxmonth.Items.Add("July");
            comboBoxmonth.Items.Add("August");
            comboBoxmonth.Items.Add("September");
            comboBoxmonth.Items.Add("October");
            comboBoxmonth.Items.Add("November");
            comboBoxmonth.Items.Add("December");

            comboBoxYear.Items.Add("2020");
            comboBoxYear.Items.Add("2021");
      
            //listview setting
            this.listViewresult.View = View.Details;
            listViewresult.Columns.Add("database", 200);
            //listViewresult.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewresult.Columns.Add("info", 200);
           // listViewresult.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            imageList = new ImageList();
            imageList.ImageSize = new Size(20, 20);
            //add 3 images result
            imageList.Images.Add(Properties.Resources.nook);
            imageList.Images.Add(Properties.Resources.ok);         
            imageList.Images.Add(Properties.Resources.question);


            // tell your ListView to use the new image list
            listViewresult.SmallImageList = imageList;

            textBoxdbpath.Text = xmldatabase.dbpath;
            textBoxcsvpath.Text = xmldatabase.csvpath;

            //set db and csv path object 
            save.dbpath = xmldatabase.dbpath;
            Csvwriter.csvpath = xmldatabase.csvpath;

            //popolate list
            this.createlist();

        }

        public bool createlist()
        {

            for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
            {

                try
                {

                //string dbname = readxml();
                addItemonlist(xmldatabase.databaseinfo[i].ElementAt<string>(0));
                //set question mark
                setItemlistimage(2, i);
                Thread.Sleep(500);
                listViewresult.Refresh();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e);
                    return false;
                }

            }
            return true;
        }

        public bool refreshlist()
        {

            try
            {
                //Set all icon to question mark at start
                for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
                {
                    setItemlistimage(2, i);
                    listViewresult.Refresh();
                    Thread.Sleep(500);
                }
            }                
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public void Button1_Click(object sender, EventArgs e)
        {

            //get year and month
            save.dbmonth = comboBoxmonth.SelectedItem.ToString();
            save.dbyear = comboBoxYear.SelectedItem.ToString();
            
            Csvwriter.csvmonth = comboBoxmonth.SelectedItem.ToString();
            Csvwriter.csvyear = comboBoxYear.SelectedItem.ToString();


            if(!this.refreshlist())
            {
                //LOG error refresh
                return;
            }



            //test thread
            //Thread thread = new Thread(threadreaddbfile);
            //thread.Start();
            // thread.Join();
            // ...



     

            for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
            {

                int risultato = itemoperation(i);
                setItemlistimage(risultato, i);
                listViewresult.Refresh();
                Thread.Sleep(500);
               
            }


            MessageBox.Show("Completed!");

        }

        public bool addItemonlist(string name)
        {

            //add item and set image to question mark 
            listViewresult.Items.Add(" " + name, 0);
            //aggiungi colonna info
            listViewresult.Items[listViewresult.Items.Count-1].SubItems.Add("");

            return true;
        }

        public int itemoperation(int listindex)
        {
            dbreadresult = 0;
            ListViewItem item = this.listViewresult.Items[listindex];

            Stopwatch sw = new Stopwatch();

            sw.Start();

            if (save.OpenConnection(xmldatabase.databaseinfo[listindex].ElementAt<string>(0), xmldatabase.databaseinfo[listindex].ElementAt<string>(1)))          
            {
                if (save.ReadFile())
                {
                    if (save.CloseConnection())
                    {
                        dbreadresult = 1;
                        sw.Stop();
                        item.SubItems[1].Text = "Elapsed=" + sw.Elapsed.Minutes + ":" + sw.Elapsed.Seconds + ":" + sw.Elapsed.Milliseconds;
                    }
                    else
                    {
                        sw.Stop();
                        item.SubItems[1].Text = "ERROR closing db file";
                        dbreadresult = 0;
                    }

                }
                else
                {
                    sw.Stop();
                    item.SubItems[1].Text = "ERROR reading db file";
                    dbreadresult = 0;
                }


            }
            else
            {
                sw.Stop();
                item.SubItems[1].Text = "ERROR opening db file";
                dbreadresult = 0;
            }

            return dbreadresult;
        }

        public bool setItemlistimage(int result, int listitem)
        {
            ListViewItem item = this.listViewresult.Items[listitem];
            if (result == 1)
                item.ImageIndex = 1; //ok image
            else if (result == 2)
                item.ImageIndex = 2;//question mark image
            else 
                item.ImageIndex = 0;//bad image
            return true;
        }

        //public void threadreaddbfile()
        //{
        //    if (InvokeRequired)
        //    {
        //        var d = new SafeCallDelegate(threadreaddbfile);
        //        this.Invoke(d, new object[] {  });
        //    }
        //    else
        //    {
        //        for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
        //        {

        //            int risultato = itemoperation(i);
        //            setItemlistimage(risultato, i);
        //            Thread.Sleep(500);
        //        }
        //    }



        //}



    }
}
