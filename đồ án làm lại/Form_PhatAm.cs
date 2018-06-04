using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_làm_lại
{
    public partial class Form_PhatAm : Form
    {
        Idict dic;
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        public Form_PhatAm(Idict a)
        {
            InitializeComponent();
            dic = a;
        }


        private void Form_PhatAm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
           
        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string a = e.Result.Text.ToString();

            if (a == txtWord.Text.ToString())
            {
                lblState.Text = "GOOD";
            }
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            if(btnDoc.Text == "TẬP ĐỌC")
            {
                btnDoc.Text = "STOP";
                Choices sList = new Choices();
                sList.Add(txtWord.Text.ToString());
                Grammar gr = new Grammar(new GrammarBuilder(sList));
                try
                {
                    sRecognize.RequestRecognizerUpdate();
                    sRecognize.LoadGrammar(gr);
                    sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                    sRecognize.SetInputToDefaultAudioDevice();
                    sRecognize.RecognizeAsync(RecognizeMode.Multiple);

                }
                catch
                {
                    return;
                }
                return;
            }
            if(btnDoc.Text == "STOP")
            {
                btnDoc.Text = "TẬP ĐỌC";
                txtWord.Text = "";
                txtWord.Focus();
                lblState.Text = "";
                return;
            }
           
        }

        private void lblState_Click(object sender, EventArgs e)
        {

        }

        private async void lblState_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            btnDoc.Text = "TẬP ĐỌC";
            txtWord.Text = "";
            txtWord.Focus();
            lblState.Text = "";
        }
    }
}
