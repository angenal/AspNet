using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WindowsWPF.Controls
{
    [TemplatePart(Name = ThumbTemplateName, Type = typeof(Thumb))]
    [TemplatePart(Name = ThumbRightBottomTemplateName, Type = typeof(Thumb))]
    public class DragDrop : Control
    {
        private const string ThumbTemplateName = "PART_Rect";
        private const string ThumbRightBottomTemplateName = "PART_RectRightBottom";

        private Thumb _thumb;
        private Thumb _rectRightBottomThumb;

        public event Action UpdateImageEvent;

        #region 依赖属性
        public static readonly DependencyProperty ParentMaxWidthProperty =
            DependencyProperty.Register("ParentMaxWidth", typeof(double), typeof(DragDrop), new PropertyMetadata(null));
        public double ParentMaxWidth
        {
            get { return (double)GetValue(ParentMaxWidthProperty); }
            set { SetValue(ParentMaxWidthProperty, value); }
        }

        public static readonly DependencyProperty ParentMaxHeightProperty =
            DependencyProperty.Register("ParentMaxHeight", typeof(double), typeof(DragDrop), new PropertyMetadata(null));
        public double ParentMaxHeight
        {
            get { return (double)GetValue(ParentMaxHeightProperty); }
            set { SetValue(ParentMaxHeightProperty, value); }
        }
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _thumb = GetTemplateChild(ThumbTemplateName) as Thumb;
            _rectRightBottomThumb = GetTemplateChild(ThumbRightBottomTemplateName) as Thumb;
            RegisterEventListener();
        }
        protected virtual void RegisterEventListener()
        {
            _thumb.DragDelta += OnDragDeltaHandler;
            _rectRightBottomThumb.DragDelta += OnRightBottomDragDeltaHandler;
        }
        static DragDrop()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragDrop), new FrameworkPropertyMetadata(typeof(DragDrop)));
        }
        public System.Drawing.Rectangle GetCutRectangle()
        {
            return new System.Drawing.Rectangle((int)Canvas.GetLeft(this), (int)Canvas.GetTop(this), (int)this.ActualWidth, (int)this.ActualHeight);
        }

        #region 中间拖动
        private void OnDragDeltaHandler(object sender, DragDeltaEventArgs e)
        {
            double left = Canvas.GetLeft(this) + e.HorizontalChange;
            double top = Canvas.GetTop(this) + e.VerticalChange;

            if (left < 0) left = 0;
            if (top < 0) top = 0;

            if (left + Width > ParentMaxWidth) left = ParentMaxWidth - Width;
            if (top + Height > ParentMaxHeight) top = ParentMaxHeight - Height;

            Canvas.SetLeft(this, left);
            Canvas.SetTop(this, top);
            UpdateImageEvent?.Invoke();
        }
        #endregion

        #region 右下点拖动
        private void OnRightBottomDragDeltaHandler(object sender, DragDeltaEventArgs e)
        {
            if (Width + e.HorizontalChange > 0) Width += e.HorizontalChange;
            double left = Canvas.GetLeft(this);
            if (left + Width > ParentMaxWidth)
            {
                Width = ParentMaxWidth - left;
            }

            if (Height + e.VerticalChange > 0) Height += e.VerticalChange;
            double top = Canvas.GetTop(this);
            if (top + Height > ParentMaxHeight)
            {
                Height = ParentMaxHeight - top;
            }
            UpdateImageEvent?.Invoke();
        }
        #endregion
    }
}
