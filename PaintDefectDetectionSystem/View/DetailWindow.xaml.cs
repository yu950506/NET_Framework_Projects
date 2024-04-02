using PaintDefectDetectionSystem.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintDefectDetectionSystem.View
{
    /// <summary>
    /// DetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DetailWindow : Window
    {
        private Point zoomCenter;
        private double scaleFactor = 1.0;

        public DetailWindow()
        {
            InitializeComponent();
            this.DataContext = new DetailViewModel();
        }

        //private double scale = 1.0;
        //private void CanvasMouseWheelZoom(object sender, MouseWheelEventArgs e)
        //{
        //    // 根据滚轮滚动方向调整缩放比例
        //    if (e.Delta > 0)
        //        scale *= 1.1;
        //    else
        //        scale /= 1.1;

        //    // 限制缩放比例的最小和最大值
        //    scale = Math.Max(0.1, Math.Min(scale, 10.0));

        //    // 将缩放应用到Canvas上，就能将整个canvas的元素进行放大缩小
        //    ScaleTransform scaleTransform = new ScaleTransform(scale, scale);
        //    canvas.LayoutTransform = scaleTransform;
        //}

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 记录鼠标点击点相对于 Canvas 的位置
            zoomCenter = e.GetPosition(canvas);
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // 计算放大缩小的中心点
            double centerX = zoomCenter.X / canvas.ActualWidth;
            double centerY = zoomCenter.Y / canvas.ActualHeight;

            // 根据鼠标滚轮方向修改缩放因子
            if (e.Delta > 0)
                scaleFactor *= 1.1;
            else
                scaleFactor /= 1.1;

            // 限制缩放因子的范围
            scaleFactor = Math.Max(0.1, Math.Min(scaleFactor, 10.0));

            // 应用缩放变换
            ScaleTransform scaleTransform = new ScaleTransform(scaleFactor, scaleFactor, centerX, centerY);
            canvas.LayoutTransform = scaleTransform;
        }
    }
}