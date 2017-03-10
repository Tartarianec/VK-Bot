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
            string s = Convert.ToString(GetCountPages());

            MessageBox.Show(s);
            MessageBox.Show(GetNames(0));
            MessageBox.Show("try: \r\n http://sibtime.ru/bitrix/admin/iblock_element_edit.php?IBLOCK_ID=3&type=1c_catalog&ID=252772&lang=ru&find_section_section=57&WF=Y \r\n для S0808180 \r\n Итем отсутсыытвует \r\n Google любит тебя!");

        }

        private string GetNames(int Num)
        {
            string names = "";

            try
            {
                using (var Request = new HttpRequest())
                {
                    string SourcePage;


                    string[] raw;


                    SourcePage = Request.Get("http://sibtime.ru/catalog/ruchki_pishushchie_instrumenty/?COD=ruchki_pishushchie_instrumenty&PAGEN_2=" + Num).ToString();

                    raw = SourcePage.Substrings("\"name\">", "</div>", 0);

                    for (int i = 0; i < raw.Length; i++)
                    {

                        names += raw[i] + "\r\n";

                    }

                }
            }
            catch { }
            return names;
        }


        private int GetCountPages()
        {
            int countPages = 0;
            try
            {
                using (var Request = new HttpRequest())
                {
                    string SourcePage;

                    SourcePage = Request.Get("http://sibtime.ru/catalog/ruchki_pishushchie_instrumenty/").ToString();
                    countPages = Convert.ToInt32(SourcePage.Substrings("/catalog/ruchki_pishushchie_instrumenty/?COD=ruchki_pishushchie_instrumenty&amp;PAGEN_2=", "\">", 0)[4]);

                }
            }
            catch {}

            return countPages;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Thread.ReportProgress(0, GetNames(1));

                int countPages = GetCountPages();

                for (int i = 1; i <= countPages; i++)
                {
                    Thread.ReportProgress(0, GetNames(i));
                }
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
