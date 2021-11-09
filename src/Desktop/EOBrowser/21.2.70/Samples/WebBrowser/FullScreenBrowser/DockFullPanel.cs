using System.Windows;
using System.Windows.Controls;

namespace FullScreenBrowser
{
    public class DockFullPanel : DockPanel
    {
        public DockFullPanel() : base()
        {
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            Size panelDesiredSize = new Size();
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
                panelDesiredSize = child.DesiredSize;
                //break;
            }
            return panelDesiredSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Arrange(new Rect(new Point(), child.DesiredSize));
                //break;
            }
            return finalSize;
        }
    }
}
