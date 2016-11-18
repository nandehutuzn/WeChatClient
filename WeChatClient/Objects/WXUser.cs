using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WeChatClient.HTTP;

namespace WeChatClient.Objects
{
    /// <summary>
    /// 表示处理消息发送完成事件的方法
    /// </summary>
    /// <param name="msg"></param>
    public delegate void MsgSentEventHandler(WXMsg msg);

    /// <summary>
    /// 表示处理接收到新消息事件的方法
    /// </summary>
    /// <param name="msg"></param>
    public delegate void MsgRecevedEventHandler(WXMsg msg);

    /// <summary>
    /// 微信用户
    /// </summary>
    public class WXUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        private string _userName;
        public string UserName { 
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// 昵称
        /// </summary>
        private string _nickName;
        public string NickName {
            get { return _nickName; }
            set { _nickName = value; }
        }

        /// <summary>
        /// 头像url
        /// </summary>
        private string _headImgUrl;
        public string HeadImgUrl {
            get { return _headImgUrl; }
            set { _headImgUrl = value; }
        }

        /// <summary>
        /// 备注名
        /// </summary>
        private string _remarkName;
        public string RemarkName {
            get { return _remarkName; }
            set { _remarkName = value; }
        }

        /// <summary>
        /// 性别  男1   女2  其他0
        /// </summary>
        private string _sex;
        public string Sex {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// 签名
        /// </summary>
        private string _signature;
        public string Signature {
            get { return _signature; }
            set { _signature = value; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        private string _city;
        public string City {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// 省份
        /// </summary>
        private string _province;
        public string Province {
            get { return _province; }
            set { _province = value; }
        }

        /// <summary>
        /// 昵称全拼
        /// </summary>
        private string _pyQuanPin;
        public string PYQuanPin{
            get { return _pyQuanPin; }
            set { _pyQuanPin = value; }
        }

        /// <summary>
        /// 备注全拼
        /// </summary>
        private string _remarkPYQuanPin;
        public string RemarkPYQuanPin {
            get { return _remarkPYQuanPin; }
            set { _remarkPYQuanPin = value; }
        }

        /// <summary>
        /// 头像
        /// </summary>
        private bool _loading_icon = false;
        private Image _icon;
        public Image Icon
        {
            get 
            {
                if (_icon == null && !_loading_icon)
                {
                    _loading_icon = true;
                    ((Action)(delegate()
                    {
                        WXService wxs = new WXService();
                        if (_userName.Contains("@@"))//讨论组
                            _icon = wxs.GetHeadImg(_userName);
                        else if (_userName.Contains("@"))//好友
                            _icon = wxs.GetIcon(_userName);
                        else
                            _icon = wxs.GetIcon(_userName);
                        _loading_icon = false;
                    })).BeginInvoke(null, null);
                }
                return _icon;
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName
        {
            get {
                return string.IsNullOrEmpty(_remarkName) ? _nickName : _remarkName;
            }
        }

        /// <summary>
        /// 显示的拼音全拼
        /// </summary>
        public string ShowPinYin {
            get {
                return string.IsNullOrEmpty(_remarkPYQuanPin) ? _pyQuanPin : _remarkPYQuanPin;
            }
        }

        /// <summary>
        /// 发送给对方的消息
        /// </summary>
        private Dictionary<DateTime, WXMsg> _sentMsg = new Dictionary<DateTime, WXMsg>();
        public Dictionary<DateTime, WXMsg> SentMsg {
            get { return _sentMsg;}
        }

        /// <summary>
        /// 收到对方的消息
        /// </summary>
        private Dictionary<DateTime, WXMsg> _recevedMsg = new Dictionary<DateTime,WXMsg>();
        public Dictionary<DateTime, WXMsg> RecevedMsg{
            get { return _recevedMsg; }
        }

        public event MsgSentEventHandler MsgSent;
        public event MsgRecevedEventHandler MsgReceved;

        /// <summary>
        /// 接收来自该用户的消息
        /// </summary>
        /// <param name="msg"></param>
        public void ReceiveMsg(WXMsg msg)
        {
            _recevedMsg.Add(msg.Time, msg);
            if (MsgReceved != null)
                MsgReceved(msg);
        }

        /// <summary>
        /// 向该用户发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="showOnly"></param>
        public void SendMsg(WXMsg msg, bool showOnly)
        {
            if (!showOnly)
            {
                WXService wxs = new WXService();
                wxs.SendMsg(msg.Msg, msg.From, msg.To, msg.Type);
            }

            _sentMsg.Add(msg.Time, msg);
            if (MsgSent != null)
                MsgSent(msg);
        }

        /// <summary>
        /// 获取该用户发送的未读消息
        /// </summary>
        /// <returns></returns>
        public List<WXMsg> GetUnReadMsg()
        {
            List<WXMsg> list = null;
            foreach (KeyValuePair<DateTime, WXMsg> p in _recevedMsg)
            {
                if (!p.Value.Readed)
                {
                    if (list == null)
                        list = new List<WXMsg>();
                    list.Add(p.Value);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取最近的一条信息
        /// </summary>
        /// <returns></returns>
        public WXMsg GetLatestMsg()
        {
            WXMsg msg = null;
            if (_sentMsg.Count > 0 && _recevedMsg.Count > 0)
                msg = _sentMsg.Last().Value.Time > _recevedMsg.Last().Value.Time ? _sentMsg.Last().Value : _recevedMsg.Last().Value;
            else if (_sentMsg.Count > 0)
                msg = _sentMsg.Last().Value;
            else if (_recevedMsg.Count > 0)
                msg = _recevedMsg.Last().Value;
            return msg;
        }

    }
}
