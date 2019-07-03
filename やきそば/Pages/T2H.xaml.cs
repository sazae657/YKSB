using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace やきそば.Pages
{
    /// <summary>
    /// T2H.xaml の相互作用ロジック
    /// </summary>
    public partial class T2H : Page
    {
        public T2H()
        {
            InitializeComponent();
            Source = new RejectablePrperty<string>(TextBox_TextChanged);
            DataContext = this;
        }

        public RejectablePrperty<string> Source { get; set; } 
        public RejectablePrperty<string> Dest { get; set; } = new RejectablePrperty<string>();

        private void TextBox_TextChanged(object sender, PropertyChangedEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var c in Source.Value) {
                sb.Append("0x")
                  .Append(string.Join("", from k in Encoding.UTF8.GetBytes(new[] { c }) select k.ToString("X2")));
                sb.Append(", ");
            }
            Dest.Value = sb.ToString();
        }
    }
}
