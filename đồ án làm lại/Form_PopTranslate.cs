using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class Form_PopTranslate : Form
    {
        string sent;
        public Form_PopTranslate(string a)
        {
            InitializeComponent();
            sent = a;
        }

        private void Form_PopTranslate_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            try
            {
                string url = "https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20170322T121646Z.547f9b757cf1e75e.1bc910cdd2391946c3c417486c51071c70ec0b08&text=" + sent + "&lang=en-vi&[format=plain]&[options=lang]";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();
                result = result.Replace("/", "");
                result = result.Replace("<text>", "~");
                result = result.Split('~')[1];
                txtResult.Text = result;
            }
            catch
            {
                MessageBox.Show("Kiểm tra kết nối mạng !");
            }


        }


    }
}
