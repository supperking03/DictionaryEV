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
    public partial class Form_History : Form
    {
        string[] o;
        Idict dic = new DictEV();
        public Form_History(Idict d)
        {
            InitializeComponent();
            dic = d;
            this.TopMost = true;
            FileStream fs = new FileStream("saveEV.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string a = sr.ReadToEnd();
            fs.Close();
            string[] g = new string[10];
            g = a.Split('\n');
            string[] q = g.Distinct().ToArray();
            o = q;
            o = o.Where(str => str != "").ToArray(); // xoa khoang trang o cuoi
            foreach(string ga in o)
            {
                listBoxHistory.Items.Add(ga);
            }
            //listBoxHistory.Items.AddRange(q);
        }

        private void Form_History_Load(object sender, EventArgs e)
        {

        }

        private void listBoxHistory_DoubleClick(object sender, EventArgs e)
        {
            Form_Information fi = new Form_Information(listBoxHistory.Text.ToString().TrimEnd(), dic.search(listBoxHistory.Text.ToString().TrimEnd()));
            fi.Show();
        }

        // xoa  từ trong file txt
        private void button2_Click(object sender, EventArgs e)
        {
            o = o.Where(w => w != listBoxHistory.Text.ToString()).ToArray(); // delete a string in array
            System.IO.File.WriteAllText("saveEV.txt", string.Empty); // xóa all text
            listBoxHistory.Items.Remove(listBoxHistory.Text.ToString());
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("saveEV.txt", true))
            {               
                foreach(string a in o)
                {
                    file.WriteLine(a.TrimEnd());
                }
            }         
        }
    }
}
