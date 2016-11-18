using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChatClient.HTTP;

namespace WeChatClient
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkReturn.Visible = false;
            DoLogin();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DoLogin();
        }

        /// <summary>
        /// 登录逻辑
        /// </summary>
        private void DoLogin()
        {
            picQRCode.Image = Properties.Resources.holmes2;
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            lblTip.Text = "手机微信扫一扫以登录";
            //异步加载二维码
            ((Action)delegate()    
            {
                LoginService ls = new LoginService();
                Image qrcode = ls.GetQRCode();
                if (qrcode != null)
                {
                    this.BeginInvoke((Action)delegate()
                    {
                        picQRCode.Image = qrcode;
                    });

                    object login_result = null;
                    while (true)  //循环判断手机扫描二维码结果
                    {
                        login_result = ls.LoginCheck();
                        if (login_result is Image)
                        {
                            this.BeginInvoke((Action)delegate()
                            {
                                lblTip.Text = "请点击手机上登录按钮";
                                picQRCode.SizeMode = PictureBoxSizeMode.CenterImage;  //显示头像
                                picQRCode.Image = login_result as Image;
                                linkReturn.Visible = true;
                            });
                        }
                        if (login_result is string)
                        {
                            ls.GetSidUid(login_result as string);
                            this.BeginInvoke((Action)delegate()
                            {
                                this.Hide();
                                new frmMainForm().Show();
                            });
                            break;
                        }
                    }
                }
            }).BeginInvoke(null, null);
        }
    }
}
