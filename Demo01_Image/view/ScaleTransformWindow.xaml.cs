using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Demo01_Image.view
{
    /// <summary>
    /// ScaleTransform.xaml 的交互逻辑
    /// </summary>
    public partial class ScaleTransformWindow : Window
    {
        public ScaleTransformWindow()
        {
            InitializeComponent();
        }

        private Point clickPosition;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickPosition = e.GetPosition(sender as IInputElement);
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // 计算缩放比例
            double scale = e.Delta > 0 ? 1.1 : 0.9;

            ScaleTransformWindow scaleTransformWindow = sender as ScaleTransformWindow;

            ScaleTransform transform = scaleTransformWindow.image.RenderTransform as ScaleTransform;
            transform.ScaleX *= scale;
            transform.ScaleY *= scale;
            // 根据点击位置缩放图片
            //var transform = (sender as Image).RenderTransform as ScaleTransform;
            //transform.ScaleX *= scale;
            //transform.ScaleY *= scale;

            // 调整图片位置以保持点击位置不变
            var position = e.GetPosition(sender as IInputElement);
            transform.CenterX = clickPosition.X - position.X * (scale - 1);
            transform.CenterY = clickPosition.Y - position.Y * (scale - 1);

            rec.Width *= scale;
            rec.Height *= scale;
        }
    }
}