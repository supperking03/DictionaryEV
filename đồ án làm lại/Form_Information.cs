using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class Form_Information : Form
    {
        public string Sound;
        public Form_Information(string key, string result)
        {
            InitializeComponent();
            txtResultInfo.Text = result;
            Sound = key;
        }

        private void Form_Information_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
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



        // nhấn ok tắt form info
        private void txtResultInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(this, new EventArgs());
            }
        }


        //đọc từ
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void btnReadSound_Click(object sender, EventArgs e)
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            
            reader.SpeakAsync(Sound);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).saveWord(Sound);
            }
            btnSave.Enabled = false;
        }

        private void txtResultInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
