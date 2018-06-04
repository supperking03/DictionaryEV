namespace đồ_án_làm_lại
{
    partial class Form_PhatAm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWord = new System.Windows.Forms.RichTextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnDoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWord
            // 
            this.txtWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.txtWord.ForeColor = System.Drawing.Color.White;
            this.txtWord.Location = new System.Drawing.Point(18, 12);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(100, 96);
            this.txtWord.TabIndex = 0;
            this.txtWord.Text = "";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(52, 111);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 15);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "label1";
            this.lblState.TextChanged += new System.EventHandler(this.lblState_TextChanged);
            this.lblState.Click += new System.EventHandler(this.lblState_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.BackColor = System.Drawing.SystemColors.Menu;
            this.btnDoc.FlatAppearance.BorderSize = 0;
            this.btnDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoc.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnDoc.Location = new System.Drawing.Point(125, 12);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(45, 96);
            this.btnDoc.TabIndex = 2;
            this.btnDoc.Text = "TẬP ĐỌC";
            this.btnDoc.UseVisualStyleBackColor = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // Form_PhatAm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(182, 137);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_PhatAm";
            this.Text = "Form_PhatAm";
            this.Load += new System.EventHandler(this.Form_PhatAm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtWord;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnDoc;
    }
}