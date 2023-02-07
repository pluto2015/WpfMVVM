using Microsoft.Extensions.DependencyInjection;
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
using WpfMVVM.Views;

namespace WpfMVVM.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        #region props
        private Page _SubPage;
        public Page SubPage { set => SetProperty(ref _SubPage, value); get => _SubPage; }
        #endregion
        #region commands
        public RelayCommand ButtonCommand { set; get; }
        public RelayCommand TextBoxCommand { set; get; }
        public RelayCommand DataGridCommand { set; get; }
        #endregion
        #region methods
        protected readonly ITestService _testService;

        public MainViewModel()
        {
            InitCommands();

            _testService = App.Current.Services.GetService<ITestService>();
        }

        private void InitCommands()
        {
            ButtonCommand = new RelayCommand(OnButtonCommand);
            TextBoxCommand = new RelayCommand(OnTextBoxCommand);
            DataGridCommand = new RelayCommand(OnDataGridCommand);
        }

        private void OnDataGridCommand()
        {
            SubPage = new DataGridPage();
        }

        private void OnTextBoxCommand()
        {
            SubPage = new TextBoxPage();
        }

        private void OnButtonCommand()
        {
            SubPage = new ButtonPage();
        }
        #endregion
    }
}
