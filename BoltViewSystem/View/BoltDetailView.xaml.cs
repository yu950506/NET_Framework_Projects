using BoltViewSystem.Model;
using BoltViewSystem.ViewModel;
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
using System.Windows.Shapes;

namespace BoltViewSystem.View
{
    /// <summary>
    /// BoltDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class BoltDetailView : Window
    {
        private BoltDetailViewModel boltDetailViewModel;

        public BoltDetailView(BoltModel boltModel)
        {
            InitializeComponent();
            boltDetailViewModel = new BoltDetailViewModel(boltModel);
            this.DataContext = boltDetailViewModel;
        }
    }
}