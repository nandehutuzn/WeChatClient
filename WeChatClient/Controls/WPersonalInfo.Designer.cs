namespace WeChatClient.Controls
{
    partial class WPersonalInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plTop = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.plCenter = new System.Windows.Forms.Panel();
            this.picSexImage = new System.Windows.Forms.PictureBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblNick = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plTop.SuspendLayout();
            this.plCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSexImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(56)))));
            this.plTop.Controls.Add(this.btnBack);
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(255, 37);
            this.plTop.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::WeChatClient.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // plCenter
            // 
            this.plCenter.Controls.Add(this.picImage);
            this.plCenter.Controls.Add(this.lblNick);
            this.plCenter.Controls.Add(this.lblSignature);
            this.plCenter.Controls.Add(this.lblArea);
            this.plCenter.Controls.Add(this.btnSendMsg);
            this.plCenter.Controls.Add(this.picSexImage);
            this.plCenter.Location = new System.Drawing.Point(12, 41);
            this.plCenter.Name = "plCenter";
            this.plCenter.Size = new System.Drawing.Size(231, 355);
            this.plCenter.TabIndex = 1;
            // 
            // picSexImage
            // 
            this.picSexImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picSexImage.Image = global::WeChatClient.Properties.Resources.male;
            this.picSexImage.Location = new System.Drawing.Point(130, 218);
            this.picSexImage.Name = "picSexImage";
            this.picSexImage.Size = new System.Drawing.Size(20, 20);
            this.picSexImage.TabIndex = 0;
            this.picSexImage.TabStop = false;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendMsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendMsg.Location = new System.Drawing.Point(57, 316);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(121, 35);
            this.btnSendMsg.TabIndex = 1;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // lblArea
            // 
            this.lblArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArea.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblArea.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblArea.Location = new System.Drawing.Point(14, 279);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(201, 20);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "地区: 深圳，广东";
            // 
            // lblSignature
            // 
            this.lblSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSignature.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignature.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSignature.Location = new System.Drawing.Point(14, 242);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(201, 20);
            this.lblSignature.TabIndex = 3;
            this.lblSignature.Text = "骑士，必胜！！！";
            // 
            // lblNick
            // 
            this.lblNick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNick.AutoSize = true;
            this.lblNick.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNick.Location = new System.Drawing.Point(13, 214);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(88, 25);
            this.lblNick.TabIndex = 4;
            this.lblNick.Text = "男的糊涂";
            // 
            // picImage
            // 
            this.picImage.Image = global::WeChatClient.Properties.Resources.holmes2;
            this.picImage.Location = new System.Drawing.Point(17, 4);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(200, 200);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WPersonalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.plCenter);
            this.Controls.Add(this.plTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WPersonalInfo";
            this.Size = new System.Drawing.Size(255, 405);
            this.Resize += new System.EventHandler(this.WPersonalInfo_Resize);
            this.plTop.ResumeLayout(false);
            this.plCenter.ResumeLayout(false);
            this.plCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSexImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel plCenter;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.PictureBox picSexImage;
        private System.Windows.Forms.Timer timer1;
    }
}
