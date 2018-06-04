namespace đồ_án_làm_lại
{
    partial class Form_Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Information));
            this.txtResultInfo = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReadSound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResultInfo
            // 
            this.txtResultInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.txtResultInfo.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultInfo.ForeColor = System.Drawing.Color.White;
            this.txtResultInfo.Location = new System.Drawing.Point(12, 12);
            this.txtResultInfo.Name = "txtResultInfo";
            this.txtResultInfo.ReadOnly = true;
            this.txtResultInfo.Size = new System.Drawing.Size(260, 215);
            this.txtResultInfo.TabIndex = 0;
            this.txtResultInfo.Text = "";
            this.txtResultInfo.TextChanged += new System.EventHandler(this.txtResultInfo_TextChanged);
            this.txtResultInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResultInfo_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnOk.Location = new System.Drawing.Point(197, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(13, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Ghi nhớ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReadSound
            // 
            this.btnReadSound.BackColor = System.Drawing.SystemColors.Menu;
            this.btnReadSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReadSound.BackgroundImage")));
            this.btnReadSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReadSound.FlatAppearance.BorderSize = 0;
            this.btnReadSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadSound.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadSound.Location = new System.Drawing.Point(117, 232);
            this.btnReadSound.Name = "btnReadSound";
            this.btnReadSound.Size = new System.Drawing.Size(46, 24);
            this.btnReadSound.TabIndex = 3;
            this.btnReadSound.UseVisualStyleBackColor = false;
            this.btnReadSound.Click += new System.EventHandler(this.btnReadSound_Click);
            // 
            // Form_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnReadSound);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtResultInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Information";
            this.Load += new System.EventHandler(this.Form_Information_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtResultInfo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReadSound;
    }
}