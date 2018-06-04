namespace đồ_án_làm_lại
{
    partial class Form_remind
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
            this.txtRemind = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtRemind
            // 
            this.txtRemind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.txtRemind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemind.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemind.ForeColor = System.Drawing.Color.White;
            this.txtRemind.Location = new System.Drawing.Point(12, 12);
            this.txtRemind.Name = "txtRemind";
            this.txtRemind.ReadOnly = true;
            this.txtRemind.Size = new System.Drawing.Size(388, 507);
            this.txtRemind.TabIndex = 0;
            this.txtRemind.Text = "";
            this.txtRemind.ZoomFactor = 2F;
            this.txtRemind.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRemind_MouseDown);
            // 
            // Form_remind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(412, 530);
            this.Controls.Add(this.txtRemind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_remind";
            this.Text = "Nhắc từ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_remind_FormClosing);
            this.Load += new System.EventHandler(this.Form_remind_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRemind;
    }
}