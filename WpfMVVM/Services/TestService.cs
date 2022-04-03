using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMVVM.Services
{
    public class TestService : ITestService
    {
        public void Test()
        {
            MessageBox.Show($"您调用了注入的{nameof(TestService)}的{nameof(Test)}方法");
        }
    }
}
