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

namespace SimpleTrader.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {

        public ICommand LoginCommand
        {
            get => (ICommand)GetValue(LoginCommandProperty);
            set => SetValue(LoginCommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for LoginCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginWindow), new PropertyMetadata(null));



        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(LoginCommand != null)
            {
                string password = pbPassword.Password;
                LoginCommand.Execute(password);
            }
            
        }
    }
}
