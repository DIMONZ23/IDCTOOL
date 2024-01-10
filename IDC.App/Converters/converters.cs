using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace IDC.App.ProjectManagement.Converters {
    public class FirstRowVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            DataGridRow row = value as DataGridRow;

            if (row != null && row.Item != null) {
                // Kiểm tra xem đây có phải là dòng đầu tiên không
                return row.GetIndex() == 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class FirstRowIconConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            DataGridRow row = value as DataGridRow;

            if (row != null && row.Item != null) {
                // Kiểm tra xem đây có phải là dòng đầu tiên không
                return row.GetIndex() == 0 ? FontAwesomeIcon.Plus : FontAwesomeIcon.Remove;
            }

            return FontAwesomeIcon.Remove;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
