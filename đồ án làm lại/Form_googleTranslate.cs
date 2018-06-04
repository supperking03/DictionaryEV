using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace đồ_án_làm_lại
{
    public partial class Form_googleTranslate : Form
    {

        public Form_googleTranslate()
        {
            InitializeComponent();
           
        }

        private void convertSentense(string a)
        {

        }
        private void btnTranslate_Click(object sender, EventArgs e)
        {

            //đọc url và tải source html về biến result
            if (txtTarget.Text != "")
            {
                string url = "https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20170322T121646Z.547f9b757cf1e75e.1bc910cdd2391946c3c417486c51071c70ec0b08&text=" + txtTarget.Text.ToString() + "&lang=en-vi&[format=plain]&[options=lang]";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();
                result = result.Replace("/", "");
                result = result.Replace("<text>", "~");
                result = result.Split('~')[1];
                txtDes.Text = result;
            }
            else
                MessageBox.Show("Please Enter text !");

        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {

        }

        // đọc từ
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (txtTarget.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(txtTarget.Text);
            }
            else
                MessageBox.Show("PLEASE ENTER TEXT !");
        }

        private void Form_googleTranslate_Load(object sender, EventArgs e)
        {

        }
    }
}
