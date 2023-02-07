using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfMVVM.ViewModels
{
    public class ButtonPageViewModel:ObservableObject
    {
        #region props
        #endregion
        #region commands
        public RelayCommand<string> BtnCmdWithPara { set;get; }
        public RelayCommand BtnCmd { set; get; }
        public RelayCommand BtnCloseCmd { set; get; }
        #endregion
        #region methods
        public ButtonPageViewModel()
        {
            try
            {
                InitCommands();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private void InitCommands()
        {
            BtnCmdWithPara = new RelayCommand<string>(OnBtnCmdWithPara);
            BtnCmd = new RelayCommand(OnBtnCmd);
            BtnCloseCmd = new RelayCommand(OnBtnCloseCmd);
        }

        private void OnBtnCloseCmd()
        {
            App.Current.Shutdown();
        }

        private void OnBtnCmd()
        {
            MessageBox.Show("您点击了按钮");
        }

        private void OnBtnCmdWithPara(string obj)
        {
            MessageBox.Show($"文本框内输入的是:{obj}");
        }
        #endregion
    }
}
