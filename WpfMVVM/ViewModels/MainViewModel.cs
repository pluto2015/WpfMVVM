using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfMVVM.Models;
using WpfMVVM.Services;

namespace WpfMVVM.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        public RelayCommand ButtonCommand { set; get; }
        public RelayCommand<Window> CloseCommand { set; get; }
        public RelayCommand<TextBox> TextBoxClickCommand { set; get; }
        public RelayCommand<TextBox> ListTextBoxClickCommand { set;get; }

        private string _TextOfBox = "文本框点击命令";
        public string TextOfBox
        {
            set => SetProperty(ref _TextOfBox, value);
            get => _TextOfBox;
        }

        public ObservableCollection<ListModel> list { get; } = new ObservableCollection<ListModel>();

        protected readonly ITestService _testService;

        public MainViewModel(ITestService testService)
        {
            ButtonCommand = new RelayCommand(OnButtonCommand);
            CloseCommand = new RelayCommand<Window>(OnCloseCommand);
            TextBoxClickCommand = new RelayCommand<TextBox>(OnTextBoxClickCommand);
            ListTextBoxClickCommand = new RelayCommand<TextBox>(OnListTextBoxClickCommand);

            _testService = testService;

            for (int i = 0; i < 10; i++)
            {
                list.Add(new ListModel
                {
                    Col0 = i.ToString(),
                    Col1 = i,
                    Col2 = true
                });
            }
        }

        private void OnListTextBoxClickCommand(TextBox obj)
        {
            obj.Text = "123";
        }

        private void OnTextBoxClickCommand(TextBox obj)
        {
            obj.Text = "点击了文本框";
        }

        private void OnCloseCommand(Window obj)
        {
            if(MessageBox.Show("要关闭吗？","提示",MessageBoxButton.YesNo)!= MessageBoxResult.Yes)
            {
                return;
            }
            obj.Close();
        }

        private void OnButtonCommand()
        {
            _testService.Test();
        }
    }
}
