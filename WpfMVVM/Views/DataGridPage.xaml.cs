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
using WpfMVVM.ViewModels;

namespace WpfMVVM.Views
{
    /// <summary>
    /// DataGridPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridPage : Page
    {
        public DataGridPage()
        {
            InitializeComponent();
            DataContext = new DataGridPageViewModel();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var colTemplate = new DataGridTemplateColumn();
            var cellTemplate = new DataTemplate();

            colTemplate.CellTemplate = cellTemplate;
            if("id" == e.Column.Header.ToString() )
            {
                var cell = new FrameworkElementFactory(typeof(Button));

                var cmdBinding = new Binding
                {
                    Path = new PropertyPath("DataContext.ItemCommand", new object[] { e.Column.Header }),
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Page), 1)
                };

                var cmdParaBinding = new Binding
                {
                    Path = new PropertyPath(e.Column.Header.ToString(),null),
                };

                cell.SetValue(Button.ContentProperty, "查看id");

                cell.SetBinding(Button.CommandProperty, cmdBinding);
                cell.SetBinding(Button.CommandParameterProperty, cmdParaBinding);

                cellTemplate.VisualTree = cell;
            }
            else
            {
                var cell = new FrameworkElementFactory(typeof(TextBox));

                var cmdBinding = new Binding
                {
                    Path = new PropertyPath(e.Column.Header.ToString(),null),
                };

                cell.SetBinding(TextBox.TextProperty, cmdBinding);

                cellTemplate.VisualTree = cell;
            }

            e.Column = colTemplate;
        }
    }
}
