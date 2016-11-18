using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChatClient.Objects;

namespace WeChatClient.Controls
{
    /// <summary>
    /// 通讯录列表控件
    /// </summary>
    public partial class WFriendsList : ListBox
    {
        private int _mouse_over = -1;
        private Timer timer1;
        //private System.ComponentModel.IContainer components;
        public event FriendInfoViewEventHandler FriendInfoView;

        public WFriendsList()
        {
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Cursor = Cursors.Hand;

            InitializeComponent();
            timer1.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle bound;
            for (int i = 0; i < Items.Count; i++)
            {
                WXUser user = Items[i] as WXUser;
                bound = GetItemRectangle(i);
                if (user != null)  //好友项
                {
                    if (!ClientRectangle.IntersectsWith(bound))
                        continue;
                    if (_mouse_over == i)
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 37, 37, 37)), bound);
                    if (SelectedIndex == i)
                        e.Graphics.FillRectangle(Brushes.LightGray, bound);
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black)), new Point(bound.X, bound.Y + 50), new Point(bound.X + Width, bound.Y + 50));
                    using (Font f = new Font("微软雅黑", 11))
                    {
                        if (user.Icon != null)
                            e.Graphics.DrawImage(user.Icon, new Rectangle(bound.X + 8, bound.Y + 8, 34, 34));//头像
                        e.Graphics.DrawString(user.ShowName, f, Brushes.Black, new PointF(bound.X + 50, bound.Y + 16)); //昵称
                    }
                }
                else  //分类项
                {
                    if (!ClientRectangle.IntersectsWith(bound))
                        continue;
                    using (Font f = new Font("微软雅黑", 15))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Gray)), bound);
                        e.Graphics.DrawString(Items[i].ToString(), f, Brushes.Black, new PointF(bound.X + 10, bound.Y + 3));
                    }
                }
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            if (e.Index > 0)
            {
                e.ItemHeight = (Items[e.Index] as WXUser != null) ? 50 : 30;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            for (int i = 0; i < Items.Count; i++)
            {
                if (GetItemRectangle(i).Contains(e.Location))
                {
                    _mouse_over = i;
                    Invalidate();
                    return;
                }
            }
            _mouse_over = -1;
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            Invalidate();
            if (SelectedIndex != -1 && FriendInfoView != null)
                FriendInfoView(Items[SelectedIndex] as WXUser);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouse_over = -1;
            Invalidate();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new Timer(this.components);
            this.SuspendLayout();

            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += timer1_Tick;
            this.ResumeLayout(false);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
