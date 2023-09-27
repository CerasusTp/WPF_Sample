using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SampleButton01_Badged.Badge = 0;
        }

        private void SampleButton01_Click(object sender, RoutedEventArgs e)
        {
            SampleButton01_Badged.Badge = int.Parse(SampleButton01_Badged.Badge.ToString()) + 1;
        }

        private async void SampleButton02_Click(object sender, RoutedEventArgs e)
        {
            await DialogHost.Show(new MsgBox(TitleBox.Text, MessageBox.Text));
        }

        private async void MakeInsertSQL_Click(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>(insertSQL_Data.Text.Split('\n'));

            if (data.Count < 2) {
                await DialogHost.Show(new MsgBox("INSERT文生成", "入力されたデータが不正です"));
                return;
            }
            else
            {
                List<string> column = new List<string>(data[0].TrimEnd('\r', '\n').Split('\t'));
                List<string> result = new List<string>();

                for (var i = 1; i < data.Count; i++)
                {
                    List<string> value = new List<string>(data[i].TrimEnd('\r', '\n').Split('\t'));
                    if (column.Count != value.Count)
                    {
                        await DialogHost.Show(new MsgBox("INSERT文生成", "カラム数とデータ数が一致しません"));
                        return;
                    }
                    result.Add($"INSERT INTO {InsertSQL_Table.Text} ({string.Join(", ", column)}) VALUES ({string.Join(", ", value)})");
                }

                insertSQL_Code.Text = string.Join("\n", result);
            }
            
        }
    }
}
