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

namespace AsyncAwaitTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 呼び出し元までasyncを付けるタイプの呼び出し方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AllAsyncButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "Start";
            await PseudoHeavyProcess();
            ResultTextBox.Text = "AllAsync";
        }

        /// <summary>
        /// 呼び出し元にはasyncを付けないタイプの呼び出し方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartialAsyncButton_Click(object sender, RoutedEventArgs e)
        {
            PseudoHeavyProcess().ContinueWith((result) =>
            {
                this.Dispatcher.Invoke((Action)(() => 
                { 
                    ResultTextBox.Text = "PartialAsync"; 
                }));
            });
            ResultTextBox.Text = "Start";
        }

        /// <summary>
        /// 疑似重い処理
        /// </summary>
        /// <returns></returns>
        private async Task<bool> PseudoHeavyProcess()
        {
            await Task.Delay(5000);
            return true;
        }
    }
}
