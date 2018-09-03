namespace UdpProxyUi
{
    partial class MainView
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
            this.mainPacketList = new System.Windows.Forms.ListView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.CheckBox();
            this.beginproxybtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPacketList
            // 
            this.mainPacketList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPacketList.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPacketList.Location = new System.Drawing.Point(12, 12);
            this.mainPacketList.Name = "mainPacketList";
            this.mainPacketList.Size = new System.Drawing.Size(1055, 637);
            this.mainPacketList.TabIndex = 0;
            this.mainPacketList.UseCompatibleStateImageBehavior = false;
            this.mainPacketList.ItemActivate += new System.EventHandler(this.mainPacketList_ItemActivate);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(992, 661);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadBtn.Location = new System.Drawing.Point(911, 661);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // resetbtn
            // 
            this.resetbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetbtn.Location = new System.Drawing.Point(774, 661);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(75, 23);
            this.resetbtn.TabIndex = 3;
            this.resetbtn.Text = "Clear";
            this.resetbtn.UseVisualStyleBackColor = true;
            this.resetbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 674);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UDP Proxy by RomanPort - A simple UDP proxy for capturing data.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pause
            // 
            this.pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pause.AutoSize = true;
            this.pause.Location = new System.Drawing.Point(656, 665);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(93, 17);
            this.pause.TabIndex = 5;
            this.pause.Text = "Pause Display";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.CheckedChanged += new System.EventHandler(this.pause_CheckedChanged);
            // 
            // beginproxybtn
            // 
            this.beginproxybtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.beginproxybtn.Location = new System.Drawing.Point(350, 661);
            this.beginproxybtn.Name = "beginproxybtn";
            this.beginproxybtn.Size = new System.Drawing.Size(126, 23);
            this.beginproxybtn.TabIndex = 6;
            this.beginproxybtn.Text = "Begin Proxy";
            this.beginproxybtn.UseVisualStyleBackColor = true;
            this.beginproxybtn.Click += new System.EventHandler(this.beginproxybtn_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 696);
            this.Controls.Add(this.beginproxybtn);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.mainPacketList);
            this.Name = "MainView";
            this.Text = "Simple UDP Proxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mainPacketList;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox pause;
        private System.Windows.Forms.Button beginproxybtn;
    }
}

