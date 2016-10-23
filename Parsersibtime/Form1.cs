using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Parsersibtime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string s = Convert.ToString(GetCountPages());

            //MessageBox.Show(s);
           // MessageBox.Show(GetNames(0));

        }

        //private string GetNames(int Num)
        //{
        //    string names = "";

        //    try
        //    {
        //        using(var Request = new HttpRequest())
        //        {
        //            string SourcePage;                    


        //            string[] raw;


        //            SourcePage = Request.Get("http://sibtime.ru/catalog/zazhigalki/?COD=zazhigalki&PAGEN_2="+ Num).ToString();

        //            raw = SourcePage.Substrings("\"name\">", "</div>", 0);

        //            for (int i=0; i<(raw.Length-1); i++)
        //            {

        //                names += raw[i] + "\r\n";

        //            }

        //        }
        //    }
        //    catch {}
        //    return names;
        //}

        private string GetMenu(int Num)
        {
            string menu = "";

            try
            {
                using (var Request = new HttpRequest())
                {
                    string SourcePage;


                    string[] raw;


                    SourcePage = Request.Get("http://zippoclub.ru/catalog/raritets/?p=" + Num + "&pp=8&q=&cs=1&o=0&sc=&cv=&").ToString();

                    raw = SourcePage.Substrings("data-parent-id=\"29\" href=\"", "\" class=\"", 0);

                    for (int i = 0; i < (raw.Length - 1); i++)
                    {

                        menu += raw[i] + "\r\n";

                    }

                }
            }
            catch { }
            return menu;
        }
        private int GetCountPages()
        {
            int countPages = 0;
            try
            {
                using (var Request = new HttpRequest())
                {
                    string SourcePage;

                    SourcePage = Request.Get("http://sibtime.ru/catalog/zazhigalki/#null").ToString();
                    countPages = Convert.ToInt32(SourcePage.Substrings("/catalog/zazhigalki/?COD=zazhigalki&amp;PAGEN_2=", "\">", 0)[4]);

                }
            }
            catch {}

            return countPages;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Thread.ReportProgress(0, GetMenu(1));

                int countPages = GetCountPages();

                //for (int i = 1; i <= countPages; i++)
                //{
                //    Thread.ReportProgress(0, GetMenu(i));
                //}
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            

        }
        // This event handler updates the progress bar.
        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text += Convert.ToString(e.UserState);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.RunWorkerAsync();
        }
    }
}
