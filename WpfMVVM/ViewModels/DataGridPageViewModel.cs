using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfMVVM.ViewModels
{
    public class DataGridPageViewModel:ObservableObject
    {
        #region props
        public DataTable AutoColList { set; get; }

        private Visibility _ColumnVisible = Visibility.Visible;
        public Visibility ColumnVisible { set => SetProperty(ref _ColumnVisible, value); get => _ColumnVisible; }
        #endregion
        #region commands
        public RelayCommand<string> ItemCommand { set; get; }
        public RelayCommand<Button> VisibleCommand { set; get; }
        #endregion
        #region methods
        public DataGridPageViewModel()
        {
            InitDataTable();
            InitCommands();
        }
        //初始化datatable
        private void InitDataTable()
        {
            AutoColList = new DataTable();
            for(int i=0;i<5;i++)
            {
                AutoColList.Columns.Add($"列{i}");
            }
            AutoColList.Columns.Add("id");
            for(int i=0;i<5;i++)
            {
                AutoColList.Rows.Add(new object[] { 0, 1, 2, 3, 4, i.ToString() });
            }
        }

        private void InitCommands()
        {
            ItemCommand = new RelayCommand<string>(OnItemCommand);
            VisibleCommand = new RelayCommand<Button>(OnVisibleCommand);
        }

        private void OnVisibleCommand(Button obj)
        {
            if("显示"==obj.Content.ToString())
            {
                ColumnVisible = Visibility.Visible;
                obj.Content = "隐藏";
            }
            else
            {
                ColumnVisible = Visibility.Collapsed;
                obj.Content = "显示";
            }
        }

        private void OnItemCommand(string obj)
        {
            MessageBox.Show($"行id:{obj}");
        }
        #endregion
    }
}
