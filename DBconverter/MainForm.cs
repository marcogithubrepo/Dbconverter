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

namespace DBconverter
{
    public partial class MainForm : Form
    {
        ReadDb save;
        Xml xmldatabase;
        string dbname = "test.db";
        ImageList imageList;

        public MainForm()
        {
            xmldatabase = new Xml();
            save = new ReadDb();
            InitializeComponent();

            //listview setting
            this.listViewresult.View = View.Details;
            listViewresult.Columns.Add("databaseinfo", 200);
            listViewresult.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            imageList = new ImageList();
            imageList.ImageSize = new Size(20, 20);
            //add 3 images result
            imageList.Images.Add(Properties.Resources.nook);
            imageList.Images.Add(Properties.Resources.ok);         
            imageList.Images.Add(Properties.Resources.question);


            // tell your ListView to use the new image list
            listViewresult.SmallImageList = imageList;

        }

        public void Button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
            {

                //string dbname = readxml();
                addItemonlist(xmldatabase.databaseinfo[i].ElementAt<string>(0));
                //set question mark
                setItemlistimage(2, i);
                Thread.Sleep(500);
                listViewresult.Refresh();
            }

            Thread.Sleep(500);

            for (int i = 0; i < xmldatabase.databaseinfo.Count(); i++)
            {

                int risultato = itemoperation(i);
                setItemlistimage(risultato, i);
                Thread.Sleep(500);
            }


        }


        public bool addItemonlist(string name)
        {

            //add item and set image to question mark 
            listViewresult.Items.Add(name, 0);
            return true;
        }

        public int itemoperation(int listindex)
        {
            int risultato = 0;

            if (save.OpenConnection(xmldatabase.databaseinfo[listindex].ElementAt<string>(0), xmldatabase.databaseinfo[listindex].ElementAt<string>(1)))
                if (save.ReadFile())
                    if (save.CloseConnection())
                        risultato = 1;
                    else
                        risultato = 0;
                else
                    risultato = 0;
            else
                risultato = 0;
       
            return risultato;
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


    }
}
