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
    /// LewDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class LewDetailView : Window
    {
        private LewModelDetailModel lewModelDetailModel;

        // 在构造函数中将参数进行传递
        public LewDetailView(LewModel lewModel)
        {
            InitializeComponent();
            lewModelDetailModel = new LewModelDetailModel(lewModel);
            this.DataContext = lewModelDetailModel;
        }
    }
}