using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class Form_GameWord : Form
    {

        Idict dic = new DictEV();
        public Form_GameWord(Idict a)
        {
            InitializeComponent();
            dic = a;
            
        }

        string a;
        string b;
        private bool _isClosing = false;
        private async void button1_Click(object sender, EventArgs e)
        {

            this.TopMost = true;
            txtString2.Focus();

            FileStream fs = new FileStream("saveEV.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string a = sr.ReadToEnd();
            fs.Close();
            string[] g = new string[10];
            g = a.Split('\n');
            string[] q = g.Distinct().ToArray();
            for (int i = 0; i < q.Length - 1; i++)
            {
                if (_isClosing == true)
                {
                    break;
                }
                string ggg = q[i].TrimEnd();
                progressBar1.Value = 100;
                txtString2.Text = "";
                txtString1.Text = dic.search(ggg).Split('-')[1];
                if (txtString1.Text != "")
                {
                    btnStart.Enabled = false;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (_isClosing == true)
                    {
                        break;
                    }
                    a = ggg;
                    b = txtString2.Text.ToString();
                    if (String.Compare(a, b) == 0)
                    {
                        // str1 equals str2
                        label1.Text = "good";
                        MessageBox.Show("Hay lắm anh Kiên của em !");
                        break;
                    }
                    else
                    {
                        // str11 is greater than str2, and String.Compare returned a value greater than 0
                        label1.Text = "No";
                    }
                    progressBar1.Increment(-1);
                    if (progressBar1.Value == 0)
                    {
                        MessageBox.Show("NGU, THUA CMNR !");
                        break;
                    }
                    await Task.Delay(20);
                }
                btnStart.Enabled = true;
            }
            
                

            
           
        }

        private void txtString2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                button1_Click(this, new EventArgs());
            }
        }

        private void Form_GameWord_Load(object sender, EventArgs e)
        {

            
        }

        private void txtString2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_GameWord_Activated(object sender, EventArgs e)
        {
            txtString2.Focus();
        }

        private void Form_GameWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true;
        }
    }
}
