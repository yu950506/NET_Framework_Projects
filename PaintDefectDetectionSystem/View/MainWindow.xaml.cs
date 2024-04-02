using PaintDefectDetectionSystem.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaintDefectDetectionSystem.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                String BodyNo = (sender as ComboBox).SelectedValue.ToString();
                mainViewModel.ComboBoxSelectCommand(BodyNo);
            }
        }

        private void SysClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}