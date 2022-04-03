using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfMVVM.Services;

namespace WpfMVVM.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        public RelayCommand ButtonCommand { set; get; }
        public RelayCommand<Window> CloseCommand { set; get; }
        public RelayCommand<TextBox> TextBoxClickCommand { set; get; }

        private string _TextOfBox = "文本框点击命令";
        public string TextOfBox
        {
            set => SetProperty(ref _TextOfBox, value);
            get => _TextOfBox;
        }

        protected readonly ITestService _testService;

        public MainViewModel(ITestService testService)
        {
            ButtonCommand = new RelayCommand(OnButtonCommand);
            CloseCommand = new RelayCommand<Window>(OnCloseCommand);
            TextBoxClickCommand = new RelayCommand<TextBox>(OnTextBoxClickCommand);

            _testService = testService;
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
