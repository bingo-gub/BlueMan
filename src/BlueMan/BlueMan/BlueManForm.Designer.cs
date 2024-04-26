namespace BlueMan
{
    partial class BlueManForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueManForm));
            this.BlueManPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BlueManPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BlueManPictureBox
            // 
            this.BlueManPictureBox.Image = global::BlueMan.Properties.Resources.nipple_man;
            this.BlueManPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BlueManPictureBox.Name = "BlueManPictureBox";
            this.BlueManPictureBox.Size = new System.Drawing.Size(242, 249);
            this.BlueManPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlueManPictureBox.TabIndex = 0;
            this.BlueManPictureBox.TabStop = false;
            this.BlueManPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlueManPictureBox_MouseDown);
            // 
            // BlueManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 248);
            this.Controls.Add(this.BlueManPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BlueManForm";
            this.Text = "ʖꖎ⚍ᒷ ᒲᔑリ";
            this.Load += new System.EventHandler(this.BlueManForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlueManPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BlueManPictureBox;
    }
}