using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChatClient.Objects;

namespace WeChatClient.Controls
{
    /// <summary>
    /// 个人信息面板
    /// </summary>
    public partial class WPersonalInfo : UserControl
    {
        public event StartChatEventHandler StartChat;

        private bool _showTopPanel = true;
        /// <summary>
        /// 是否显示最上端栏
        /// </summary>
        public bool ShowTopPanel
        {
            get { return _showTopPanel; }
            set
            {
                plTop.Visible = btnSendMsg.Visible = _showTopPanel = value;
            }
        }

        /// <summary>
        /// 好友
        /// </summary>
        private WXUser _friendUser;
        public WXUser FriendUser {
            get { return _friendUser; }
            set {
                _friendUser = value;
                if (_friendUser != null)
                {
                    picImage.Image = _friendUser.Icon;
                    lblNick.Text = _friendUser.NickName;
                    lblArea.Text = _friendUser.City + ", " + _friendUser.Province;
                    lblSignature.Text = _friendUser.Signature;
                    picSexImage.Image = _friendUser.Sex == "1" ? Properties.Resources.male : Properties.Resources.female;
                    picSexImage.Location = new Point(lblNick.Location.X + lblNick.Width + 4, picSexImage.Location.Y);
                }
            }
        }

        public WPersonalInfo()
        {
            InitializeComponent();
        }

        private void WPersonalInfo_Resize(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (StartChat != null)
                StartChat(_friendUser);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picImage.Image == null)
            {
                if (_friendUser != null && _friendUser.Icon != null)
                    picImage.Image = _friendUser.Icon;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        
    }
}
