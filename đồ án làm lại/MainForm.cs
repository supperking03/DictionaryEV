using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void nhắcTừToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxMode.Items.AddRange ( new []{"Online","Offline"} );
            comboBoxMode.SelectedIndex = 1;
        }

        // kiểm tra kết nối internet
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( comboBoxMode.SelectedIndex == 0 )
            {
                if (CheckForInternetConnection (  ) == true)
                {
                    MessageBox.Show ( "Internet Connection is OK !" );
                }
                else
                {
                    MessageBox.Show ( "Check your internet connection and try again !" );
                    comboBoxMode.SelectedIndex = 1;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1 ( comboBoxMode.SelectedIndex );
            f1.Show();
        }
    }
}
