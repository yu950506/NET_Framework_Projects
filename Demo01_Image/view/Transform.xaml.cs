using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Demo01_Image.view
{
    /// <summary>
    /// Transform.xaml 的交互逻辑
    /// </summary>
    public partial class Transform : Window
    {
        public Transform()
        {
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MyRec.RenderTransform is RotateTransform)
            {
                RotateTransform rotate = MyRec.RenderTransform as RotateTransform;
                Point p = e.GetPosition(this);
                rotate.Angle = p.X + p.Y;
            }
        }
    }
}