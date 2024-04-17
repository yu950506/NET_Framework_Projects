using BoltViewSystem.Model;
using BoltViewSystem.Service;
using BoltViewSystem.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;

namespace BoltViewSystem.ViewModel
{
    internal class LoginViewModel : ObservableObject
    {
        private Users user = new Users();

        public Users User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public DelegateCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(LoginCommandImpl);
        }

        private IUserService userService = new UserServiceImpl();

        public void LoginCommandImpl(object parameter)
        {
          
            Trace.WriteLine(User);

            List<Users> userList = userService.SelectUsers(User);
            if (userList != null && userList.Count > 0)
            {
                //   MessageBox.Show("登录成功，即将跳转系统主页面");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                // 关闭登录窗口
                Application.Current.Windows.OfType<Login>().FirstOrDefault().Close();
            }
            else
            {
                MessageBox.Show($"登录失败,{User.User} 或 {User.Password} 填写有误");
            }
        }

    private string ConvertToUnsecureString(SecureString securePassword)
    {
        if (securePassword == null)
            return string.Empty;

        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }

    }
}
