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
    public class TextBoxPageViewModel:ObservableObject
    {
        #region props
        
        #endregion
        #region commands
        public RelayCommand<TextBox> TxtClickCommand { set; get; }
        #endregion
        #region methods
        public TextBoxPageViewModel()
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
            TxtClickCommand = new RelayCommand<TextBox>(OnTxtClickCommand);
        }

        private void OnTxtClickCommand(TextBox obj)
        {
            MessageBox.Show("点击了编辑框");
        }
        #endregion
    }
}
