using System.Windows;
using System.Windows.Controls;

namespace Dbe.Timer.SL.Controls
{
    public partial class DataGrid
    {
        #region ///////////////// ColumnHeader
        public static readonly DependencyProperty ColumnHeaderProperty =
            DependencyProperty.RegisterAttached("ColumnHeader", typeof(string), typeof(DataGrid), new PropertyMetadata(OnColumnHeaderPropertyChanged));

        private static void OnColumnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = d as DataGridColumn;
            column.Header = e.NewValue;
        }

        public static string GetColumnHeader(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnHeaderProperty);
        }

        public static void SetColumnHeader(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnHeaderProperty, value);
        }
        #endregion

        #region ///////////////// ColumnVisibility
        public static readonly DependencyProperty ColumnVisibilityProperty =
            DependencyProperty.RegisterAttached("ColumnVisibility", typeof(Visibility), typeof(DataGrid), new PropertyMetadata(OnColumnVisibilityPropertyChanged));

        private static void OnColumnVisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = d as DataGridColumn;
            column.Visibility = (Visibility)e.NewValue;
        }

        public static Visibility GetColumnVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(ColumnVisibilityProperty);
        }

        public static void SetColumnVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(ColumnVisibilityProperty, value);
        }
        #endregion
    }
}
