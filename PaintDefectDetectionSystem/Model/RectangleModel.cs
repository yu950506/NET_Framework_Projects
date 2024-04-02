using System.Windows.Media;

namespace PaintDefectDetectionSystem.Model
{
    public class RectangleModel
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public SolidColorBrush Stroke { get; set; }
        public double StrokeThickness { get; set; }

        public string CameraId { get; set; }

        public RectangleModel(double width, double height, SolidColorBrush stroke, double strokeThickness, double x, double y, string cameraId)
        {
            Width = width;
            Height = height;
            Stroke = stroke;
            StrokeThickness = strokeThickness;
            X = x;
            Y = y;
            CameraId = cameraId;
        }

        public RectangleModel(double width, double height, double x, double y, string cameraId)
        {
            Width = width;
            Height = height;
            Stroke = Brushes.Red; // 用于设置矩形的描边颜色。可以通过设置颜色值或使用Brush填充。这里默认是红色
            StrokeThickness = 1; // 用于设置矩形的描边粗细。
            X = x;
            Y = y;
            CameraId = cameraId;
        }

        public RectangleModel()
        {
        }
    }
}