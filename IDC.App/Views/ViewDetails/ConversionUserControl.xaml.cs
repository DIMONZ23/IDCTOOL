using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDC.App.Views.ViewDetails {
    /// <summary>
    /// Interaction logic for ConversionUserControl.xaml
    /// </summary>
    public partial class ConversionUserControl : UserControl {
        public ConversionUserControl() {
            InitializeComponent();
            EncodingList = new ObservableCollection<string>(Encoding.GetEncodings().Select(s => s.DisplayName).ToList());
            EncodingList.Add("shift_jis (SJIS)");
            FormatList = new List<string>() { "*.xlsx", "*.xls", "*.tsv", "*.csv"};
        }
        public ObservableCollection<string> EncodingList { get; set; }
        public List<string> FormatList { get; set; }
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ConversionUserControl), new PropertyMetadata(string.Empty));

        public string FilePath {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public static readonly DependencyProperty SelectedEncodingProperty =
            DependencyProperty.Register("SelectedEncoding", typeof(string), typeof(ConversionUserControl), new PropertyMetadata(string.Empty));
        public string SelectedEncoding {
            get { return (string)GetValue(SelectedEncodingProperty); }
            set { SetValue(SelectedEncodingProperty, value); }
        }

        public static readonly DependencyProperty SelectedFormatProperty =
            DependencyProperty.Register("SelectedFormat", typeof(string), typeof(ConversionUserControl), new PropertyMetadata(string.Empty));
        public string SelectedFormat {
            get { return (string)GetValue(SelectedFormatProperty); }
            set { SetValue(SelectedFormatProperty, value); }
        }

        public static readonly DependencyProperty StartColumnProperty =
            DependencyProperty.Register("StartColumn", typeof(int), typeof(ConversionUserControl), new PropertyMetadata(0));
        public int StartColumn {
            get { return (int)GetValue(StartColumnProperty); }
            set { SetValue(StartColumnProperty, value); }
        }
        public static readonly DependencyProperty StartRowProperty =
            DependencyProperty.Register("StartRow", typeof(int), typeof(ConversionUserControl), new PropertyMetadata(0));
        public int StartRow {
            get { return (int)GetValue(StartRowProperty); }
            set { SetValue(StartRowProperty, value); }
        }

        public static readonly DependencyProperty NumberOfColumnsProperty =
            DependencyProperty.Register("NumberOfColumns", typeof(int), typeof(ConversionUserControl), new PropertyMetadata(0));
        public int NumberOfColumns {
            get { return (int)GetValue(NumberOfColumnsProperty); }
            set { SetValue(NumberOfColumnsProperty, value); }
        }

        public static readonly DependencyProperty NumberOfRowsProperty =
            DependencyProperty.Register("NumberOfRows", typeof(int), typeof(ConversionUserControl), new PropertyMetadata(0));
        public int NumberOfRows {
            get { return (int)GetValue(NumberOfRowsProperty); }
            set { SetValue(NumberOfRowsProperty, value); }
        }
        private void Browse_Btn_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = string.Format("Add files ({0})|{1}", string.Join(",", FormatList), string.Join(";", FormatList));
            if (openFileDialog.ShowDialog() == true) {
                FilePath = openFileDialog.FileName;
            }
        }
    }
}
