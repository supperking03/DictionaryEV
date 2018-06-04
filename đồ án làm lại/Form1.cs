using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace đồ_án_làm_lại
{
    
    public partial class Form1 : Form
    {
        
        Idict newDic = new DictEV();

        // thêm từ mới
        public void addNewWOrd(string KEY,string VALUE)
        {
            newDic.add(KEY, VALUE);
            txtSearch.AutoCompleteCustomSource.Add(KEY);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("WordAdded.txt", true))
            {
                file.Write(KEY.ToLower().TrimEnd() + "/" + VALUE.TrimEnd() + "@");
            }         
            
        }
        
        //save từ
        public void saveWord(string a)
        {          
            newDic.save(a);
        }
        //khởi tạo form

        private System.Windows.Forms.Timer timer;

        public int _mode;
        public Form1(int mode)
        {        
            InitializeComponent();            
            newDic.load();
            // add từ vào thư viện auto complete text
            var arrayOfAllKeys = newDic.Dic.Keys.ToArray();
            var source = new AutoCompleteStringCollection();
            source.AddRange(arrayOfAllKeys);
            txtSearch.AutoCompleteCustomSource = source;
            //foreach (string key in arrayOfAllKeys)
            //{
            //    txtSearch.AutoCompleteCustomSource.Add(key);
            //}
            _mode = mode;



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

        // tìm ảnh từ internet
        static string findImage(string a)
        {
            // đọc url và tải source html về biến result
            string url = "https://www.bing.com/images/search?q=" + a.Replace(" ", string.Empty);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string result = sr.ReadToEnd();



            // xử lý chuỗi tách ra link hình
            int indexOfF = result.IndexOf("https://tse3.mm.bing.net/th?id=OIP.");
            string result2 = result.Substring(indexOfF);
            string result3 = result2.Substring(0, result2.IndexOf(";"));
            return result3;
        }

        // tải ảnh về và hiển thị
        private void downloadImage(object obj)
        {
           
            try
            {
                var request = WebRequest.Create(findImage(txtSearch.Text.ToString()));

                using (var response = request.GetResponse()) // dùng using để giải phóng bộ nhớ khi ra khoải dấu ngoặc
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);

                }
            }
            catch
            {
                pictureBox1.Image = Properties.Resources.no;
            }
           

        }

        // load image khi offline
        private void LoadImage ( string name )
        {
            try
            {
                pictureBox1.Image = Image.FromFile(@"images\" + name + ".jpg");
            }
            catch 
            {
                pictureBox1.Image = Properties.Resources.no;
            }
            
        }

        //search từ
        private void btnSearch_Click(object sender, EventArgs e)
        {           
            if (txtSearch.Text != "")
            {
                string RESULT = txtSearch.Text.ToString().ToLower();
                if (newDic.search(RESULT) != "Không tìm thấy từ này !")
                {
                    Thread thr = new Thread(downloadImage);
                    if ( _mode == 0 ) // chế độ online
                    {
                        thr.Start();
                    }
                    else
                    {

                        LoadImage ( RESULT );
                    }
                    Form_Information fi = new Form_Information(RESULT,newDic.search(RESULT));
                    fi.Show();
                }
                else
                {
                    Form_Ask fa = new Form_Ask();
                    fa.Show();
                }
                    
                

             
                // load hình từ url ra form
                
                
            }
            else MessageBox.Show("Please enter text !");
            
        }

        // nhấn enter thay vì nhấn button search
        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        // mở rộng form
        private void cbExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExpand.Checked == true)
            {
                this.Size = new Size(295, 277);
            }
            else
            {
                this.Size = new Size(295, 95);
            }
        }




        // khởi động cùng win
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (cbStartUp.Checked)
                rk.SetValue("dictionary", Application.ExecutablePath.ToString());
            else
                rk.DeleteValue("dictionary", false);            

        }
        // luôn hiện form
        private void cbAppear_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAppear.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // đọc từ
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(txtSearch.Text);
            }
            else
                MessageBox.Show("PLEASE ENTER TEXT !");
        } 

         // phím tắt tra câu
        KeyboardHook hook2 = new KeyboardHook();
        string strClip2 = "";

        void hook2_KeyPressed(object sender, KeyPressedEventArgs e)
        {


            //Form_ImageDetect fi = new Form_ImageDetect();
            //fi.Show();
            //SendKeys.SendWait("^(c)");
            Thread.Sleep(10);
            SendKeys.Send("^(c)");

            strClip2 = Clipboard.GetText().Trim().ToLower();
            Clipboard.Clear();

            if (strClip2 != "")
            {
                Form_PopTranslate pt = new Form_PopTranslate(strClip2);
                pt.Show();
            }
            else
            {
                MessageBox.Show("SCAN NO TEXT !\n Try again!");
            }

        }




        // phím tắt tra từ
        KeyboardHook hook = new KeyboardHook();
        string strClip = "";

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Thread.Sleep(10);
            SendKeys.Send("^(c)");
            //SendKeys.SendWait("^(c)");

            

            strClip = Clipboard.GetText().Trim().ToLower();
            Clipboard.Clear();

            if (strClip != "")
            {
                if (newDic.search(strClip) != "Không tìm thấy từ này !")
                {                  
                    Form_Information fi = new Form_Information(strClip,newDic.search(strClip));
                    fi.Show();
                }
                else
                {
                    Form_Ask fa = new Form_Ask();
                    fa.Show();
                }

            }
            else
            {
                MessageBox.Show("SCAN NO TEXT !\n Try again!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if ( _mode == 1 )
            {
                button4.Enabled = false;
                button3.Enabled = false;
            }
            
            cbExpand.Checked = false;
            cbStartUp.Checked = true;
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register hot key.
            hook.RegisterHotKey(đồ_án_làm_lại.ModifierKeys.Control, Keys.C | Keys.S);

            //hook2
            if (_mode == 0)
            {
                hook2.KeyPressed +=
                    new EventHandler<KeyPressedEventArgs>(hook2_KeyPressed);
                // register hot key.
                hook2.RegisterHotKey(đồ_án_làm_lại.ModifierKeys.Control, Keys.T);
            }
            //hook2.RegisterHotKey(đồ_án_làm_lại.ModifierKeys.Control, Keys.B);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //thay đổi từ điển
        private void btnSwap_Click(object sender, EventArgs e)
        {

            if(newDic is DictEV)
            {
                newDic = new DictVE();
                newDic.load();
                var arrayOfAllKeys = newDic.Dic.Keys.ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(arrayOfAllKeys);
                txtSearch.AutoCompleteCustomSource = source;


                btnSwap.Text = "V-E";

                // add từ vào thư viện auto complete text
                return;
            }
            
            if(newDic is DictVE)
            {

                newDic = new DictEV();
                newDic.load();
                var arrayOfAllKeys = newDic.Dic.Keys.ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(arrayOfAllKeys);
                txtSearch.AutoCompleteCustomSource = source;

                btnSwap.Text = "E-V";
                
                return;
            }
        }

        private void btnNhacBai_Click(object sender, EventArgs e)
        {
            Form_remind rm = new Form_remind(newDic);
            rm.Show();
        }

        private void btnOnTu_Click(object sender, EventArgs e)
        {
            Form_GameWord gw = new Form_GameWord(newDic);
            gw.Show();
        }

        // xử lý tập phát âm
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_PhatAm pa = new Form_PhatAm(newDic);
            pa.Show();
        }

        private void lưuTrữToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Form_History h = new Form_History(newDic);
            h.Show();
        }

        private void cbStartUp_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            
            if(cbDisturb.Checked == true)
            {
                try
                {
                    this.Opacity = 0.1;
                }
                catch
                {

                }
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Connect fc = new Form_Connect();
            fc.Show();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            return;
        }

        private void cbDisturb_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbDisturb.Checked == true )
            {
                if (cbAppear.Checked == false)
                {
                    cbAppear.Checked = true;
                }
            }
            else
            {
                cbAppear.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_googleTranslate gt = new Form_googleTranslate();
            gt.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        // mờ form


    }
}
