using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace BoltViewSystem.Utils
{
    /// <summary>
    /// Password 附加属性
    /// </summary>
    public class PasswordHelper
    {
        // PasswordProperty: 这是一个依赖属性，用于存储密码。它的类型是 string，因此可以存储密码的明文字符串。
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper),
            new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }
        // GetPassword 和 SetPassword 方法用于获取和设置 PasswordProperty 的值。
        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(string), typeof(PasswordHelper),
            new PropertyMetadata(new PropertyChangedCallback(OnAttachChanged)));

        public static string GetAttach(DependencyObject d)
        {
            return (string)d.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject d, string value)
        {
            d.SetValue(AttachProperty, value);
        }

        static bool _isUpdating = false;
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged -= Pb_PasswordChanged;
            if (!_isUpdating)
                (d as PasswordBox).Password = e.NewValue.ToString();
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            _isUpdating = true;
            SetPassword(pb, pb.Password);
            _isUpdating = false;
        }
    }
}
