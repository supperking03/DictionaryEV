using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class Form_Connect : Form
    {
        Dictionary<string, string> listUser = new Dictionary<string, string>();

        public Form_Connect()
        {
            InitializeComponent();
 
        }

        // form di chuyen dc
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void Form_Connect_Load(object sender, EventArgs e)
        {

        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            listUser.Clear();
            listBox1.Items.Clear();
            // đọc url và tải source html về biến result
            string url = "http://kienuit.esy.es/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string result = sr.ReadToEnd();
            string[] user = new string[3];
            user = result.Split('-');
            for (int i = 0; i < user.Length; i++)
            {
                try
                {
                    listUser.Add(user[i].Split('@')[0], user[i].Split('@')[1]);
                    listBox1.Items.Add(user[i].Split('@')[0]);
                }
                catch
                {

                }

            }



        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(listUser[listBox1.Text.ToString()]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if((txtName.Text != "") && (TxtFacebook.Text != ""))
            {
                string url = "http://kienuit.esy.es/add.php?name=" + txtName.Text.ToString() + "&fb=" + TxtFacebook.Text.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                txtName.Enabled = false;
                TxtFacebook.Enabled = false;
                btnStart.Enabled = false;
                btnFresh_Click(this, new EventArgs());
                MessageBox.Show("SUCCESS !");
            }
            else
            {
                MessageBox.Show("Empty error !");
            }

        }

        private void Form_Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtName.Enabled == false)
            {
                string url = "http://kienuit.esy.es/delete.php?name=" + txtName.Text.ToString() + "&fb=" + TxtFacebook.Text.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                MessageBox.Show("Logged out !");
            }
        }
    }
}
