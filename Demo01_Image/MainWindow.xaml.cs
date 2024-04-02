using System;
using System.Windows;

namespace Demo01_Image
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(Environment.CurrentDirectory);
        }
    }
}