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
    /// Statistics.xaml 的交互逻辑
    /// </summary>
    public partial class StatisticsView : Page
    {
        private StatisticsViewModel statisticsViewModel;

        public StatisticsView()
        {
            InitializeComponent();
            statisticsViewModel = new StatisticsViewModel();
            this.DataContext = statisticsViewModel;
        }
    }
}
