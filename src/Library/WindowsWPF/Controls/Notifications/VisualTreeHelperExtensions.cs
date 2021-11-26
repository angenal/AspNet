using System.Windows;
using System.Windows.Media;

namespace WindowsWPF.Controls
{
    internal class VisualTreeHelperExtensions
    {
        public static T GetParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent == null) return null;

            T tParent = parent as T;

            return tParent != null ? tParent : GetParent<T>(parent);
        }
    }
}
