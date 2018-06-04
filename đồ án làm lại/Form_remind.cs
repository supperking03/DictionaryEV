using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    
    public partial class Form_remind : Form
    {
        Idict dic = new DictEV();
        public Form_remind(Idict a)
        {
            InitializeComponent();
            dic = a;

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
        private bool _isClosing = false;
        private async void Form_remind_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            SpeechSynthesizer reader = new SpeechSynthesizer();
            FileStream fs = new FileStream("saveEV.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string a = sr.ReadToEnd();
            fs.Close();
            string[] g = new string[10];
            g = a.Split('\n');
            string[] q = g.Distinct().ToArray();
            for (int i = 0; i < q.Length-1; i++)
            {

                if(_isClosing == true)
                {
                    break;
                }
                string ggg = q[i].TrimEnd();
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(q[i]);
                txtRemind.Text = dic.search(ggg);
                await Task.Delay(5000);
            }
        }

        private void Form_remind_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true;
        }

        private void txtRemind_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
