using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMVVM.Helpers
{
    public class VisibilityBindingProxy: Freezable
    {
        public Visibility Data
        {
            get { return (Visibility)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(Visibility), typeof(VisibilityBindingProxy), new PropertyMetadata(Visibility.Collapsed));

        protected override Freezable CreateInstanceCore()
        {
            return new VisibilityBindingProxy();
        }
    }
}
