﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChatClient.Controls
{
    /// <summary>
    /// 自定义控件 微信主界面tab控件   只能添加三个选项卡
    /// </summary>
    public partial class WTabControl : TabControl
    {
        int _mouse_over = -1;

        public WTabControl()
        {
            InitializeComponent();
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(this.Width / 3 - 1, 60);
            Alignment = TabAlignment.Bottom;
            //自绘
            base.SetStyle(ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (ItemSize.Width != ClientRectangle.Width / 3 - 1)
                ItemSize = new Size(ClientRectangle.Width / 3 - 1, 60);
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(37, 37, 37)))
            {
                Rectangle all_back = new Rectangle(1, 1, Width - 2, Height - 2);  //整个背景区域
                pe.Graphics.FillRectangle(sb, all_back);

                Rectangle back = new Rectangle(1, 1, Width - 3, Height - ItemSize.Height - 2);//客户区
                pe.Graphics.FillRectangle(Brushes.White, back);
                pe.Graphics.DrawRectangle(Pens.Gray, back);

                using (Font f = new Font("微软雅黑", 12))
                {
                    foreach (TabPage tab in TabPages)
                    {
                        Rectangle tab_rect = GetTabRect(TabPages.IndexOf(tab));
                        tab_rect = new Rectangle(tab_rect.X - 1, tab_rect.Y + 1, tab_rect.Width, tab_rect.Height - 1);
                        Size size_tab_text = TextRenderer.MeasureText(tab.Text, f);

                        if (this.SelectedTab == tab || TabPages.IndexOf(tab) == _mouse_over)
                        {
                            using (SolidBrush bsb = new SolidBrush(Color.FromArgb(51, 133, 255)))
                            {
                                pe.Graphics.FillRectangle(bsb, tab_rect);
                            }
                            pe.Graphics.DrawString(tab.Text, f, Brushes.White, new PointF(tab_rect.X + (tab_rect.Width - size_tab_text.Width) / 2, tab_rect.Y + 20));
                        }
                        else
                        {
                            pe.Graphics.FillRectangle(sb, tab_rect);
                            pe.Graphics.DrawString(tab.Text, f, Brushes.White, new PointF(tab_rect.X + (tab_rect.Width - size_tab_text.Width) / 2, tab_rect.Y + 20));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标进入选项卡
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _mouse_over = -1;
            foreach (TabPage tab in TabPages)
            {
                Rectangle tab_tect = GetTabRect(TabPages.IndexOf(tab));
                if(tab_tect.Contains(e.Location))
                {
                    _mouse_over = TabPages.IndexOf(tab);
                    break;
                }
            }
        }

        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouse_over = -1;
            Invalidate();
        }
    }
}
