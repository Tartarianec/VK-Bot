using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace VK_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string client_id; // адрес аккаунта, с которым мы работаем
        string access_token; // ключ доступа к аккаунту
        string url; // для отправки GET-запроса серверу и получения ответа сервера
        string response; // для записи ответа сервера
        WebClient client; // объект, который отправляет и принимает запросы из url

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebClient();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate(String.Format("http://vk.com"));
            //"https://oauth.vk.com/authorize?client_id=1234567" + "&redirect_uri" = "https://oauth.vk.com/blank.html" + "&scope=1024" +

            //"&display=page" + "&response_type=token";
        }
    }
}
