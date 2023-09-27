using System;
using System.Collections.Generic;
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

namespace SampleTools
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class MsgBox : UserControl
    {
        public MsgBox(string title, string message)
        {
            InitializeComponent();

            //メッセージをテキストボックスへ反映
            txtTile.Text = title;
            txtMessage.Text = message;
        }
    }
}
