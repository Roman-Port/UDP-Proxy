namespace UdpProxyUi
{
    partial class InfoPopup
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
            this.openinhexedit = new System.Windows.Forms.Button();
            this.packetfromlabel = new System.Windows.Forms.Label();
            this.ascii = new System.Windows.Forms.RichTextBox();
            this.hex = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // openinhexedit
            // 
            this.openinhexedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openinhexedit.Location = new System.Drawing.Point(526, 264);
            this.openinhexedit.Name = "openinhexedit";
            this.openinhexedit.Size = new System.Drawing.Size(118, 39);
            this.openinhexedit.TabIndex = 0;
            this.openinhexedit.Text = "Open in Hexed.it";
            this.openinhexedit.UseVisualStyleBackColor = true;
            this.openinhexedit.Click += new System.EventHandler(this.openinhexedit_Click);
            // 
            // packetfromlabel
            // 
            this.packetfromlabel.AutoSize = true;
            this.packetfromlabel.Location = new System.Drawing.Point(12, 9);
            this.packetfromlabel.Name = "packetfromlabel";
            this.packetfromlabel.Size = new System.Drawing.Size(35, 13);
            this.packetfromlabel.TabIndex = 1;
            this.packetfromlabel.Text = "label1";
            // 
            // ascii
            // 
            this.ascii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ascii.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ascii.DetectUrls = false;
            this.ascii.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ascii.Location = new System.Drawing.Point(436, 25);
            this.ascii.Name = "ascii";
            this.ascii.ReadOnly = true;
            this.ascii.Size = new System.Drawing.Size(208, 233);
            this.ascii.TabIndex = 2;
            this.ascii.Text = "";
            // 
            // hex
            // 
            this.hex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hex.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.hex.DetectUrls = false;
            this.hex.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hex.Location = new System.Drawing.Point(15, 25);
            this.hex.Name = "hex";
            this.hex.ReadOnly = true;
            this.hex.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.hex.Size = new System.Drawing.Size(415, 233);
            this.hex.TabIndex = 3;
            this.hex.Text = "";
            // 
            // InfoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 315);
            this.Controls.Add(this.hex);
            this.Controls.Add(this.ascii);
            this.Controls.Add(this.packetfromlabel);
            this.Controls.Add(this.openinhexedit);
            this.Name = "InfoPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openinhexedit;
        private System.Windows.Forms.Label packetfromlabel;
        private System.Windows.Forms.RichTextBox ascii;
        private System.Windows.Forms.RichTextBox hex;
    }
}