using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class addForm : Form
    {
        

        public addForm()
        {
            InitializeComponent();
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if((txtAddkey.Text != "")&&(txtAddValue.Text != ""))
            {
                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).addNewWOrd(txtAddkey.Text.ToString(), txtAddValue.Text.ToString());
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter any text !");
            }
            // gọi 1 hàm từ 1 form khác

        }

        private void addForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
