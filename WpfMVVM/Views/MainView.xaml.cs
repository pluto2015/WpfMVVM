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
using System.Windows.Shapes;
using WpfMVVM.ViewModels;

namespace WpfMVVM.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void Frame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            try
            {
                var frame = sender as Frame;
                var page = frame.DataContext as Page;
                if (page != null)//释放资源
                {
                    var vm = page.DataContext as IDisposable;
                    vm.Dispose();
                    page.DataContext = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                var frame = sender as Frame;
                if (frame.CanGoBack)
                {
                    frame.RemoveBackEntry();
                    //主动回收，加快释放资源
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
