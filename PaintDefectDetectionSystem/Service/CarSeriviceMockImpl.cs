using PaintDefectDetectionSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace PaintDefectDetectionSystem.Service
{
    /// <summary>
    /// 模拟数据的形式进行实现
    /// </summary>
    public class CarSeriviceMockImpl : ICarSerivice
    {
        public string SelectCarImgURIByBodyNo(string bodyNo)
        {
            string imgUri = null;
            if (String.IsNullOrEmpty(bodyNo))
            {
                imgUri = string.Empty;
            }
            else if ("1101".Equals(bodyNo))
            {
                imgUri = "pack://application:,,,/PaintDefectDetectionSystem;component/Images/body_no/1101.jpg";
            }
            else
            {
                imgUri = string.Empty;
            }
            return imgUri;
        }

        public List<Car> SelectCarListByBodyNo(string bodyNo)
        {
            List<Car> list = new List<Car>();
            if (String.IsNullOrEmpty(bodyNo))
            {
                return list;
            }
            else if ("1101".Equals(bodyNo))
            {
                list.Add(new Car(1, bodyNo, "2H01", "[[(20,20),(40,40)]]", DateTime.Now));
                list.Add(new Car(2, bodyNo, "2H01", "[[(100,100),(130,130)]]", DateTime.Now));
                list.Add(new Car(3, bodyNo, "2H02", "[[(30,30),(40,40)]]", DateTime.Now));
                list.Add(new Car(4, bodyNo, "3H03", "[[(20,20),(60,60)]]", DateTime.Now));
                list.Add(new Car(5, bodyNo, "4H02", "[[(20,20),(40,40)]]", DateTime.Now));
            }
            else if ("56".Equals(bodyNo))
            {
                list.Add(new Car(1, bodyNo, "2H01", "[[(20,20),(40,40)]]", DateTime.Now));
                list.Add(new Car(2, bodyNo, "2H02", "[[(100,100),(130,130)]]", DateTime.Now));
                list.Add(new Car(3, bodyNo, "2H02", "[[(30,30),(40,40)]]", DateTime.Now));
                list.Add(new Car(4, bodyNo, "2H03", "[[(20,20),(60,60)]]", DateTime.Now));
                list.Add(new Car(5, bodyNo, "2H03", "[[(20,20),(40,40)]]", DateTime.Now));
            }
            return list;
        }

        public List<RectangleModel> SelectRectangleByCarameIdAndBodyNo(string carameId, string bodyNo)
        {
            List<RectangleModel> lists = new List<RectangleModel>();
            if (!string.IsNullOrEmpty(carameId) && !string.IsNullOrEmpty(bodyNo))
            {
                List<Car> cars = this.SelectCarListByBodyNo(bodyNo);
                if (cars.Count > 0)
                {
                    foreach (Car car in cars)
                    {
                        if (carameId.Equals(car.CameraId))
                        {
                            string result = car.DefectPos.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "");
                            // [[(20,20),(40,40)]] = > 20,20,40,40
                            string[] points = result.Split(',');
                            RectangleModel rect = new RectangleModel()
                            {
                                X = double.Parse(points[0]),
                                Y = double.Parse(points[1]),
                                Width = double.Parse(points[2]) - double.Parse(points[0]),
                                Height = double.Parse(points[3]) - double.Parse(points[1]),
                                Stroke = Brushes.Red, // 用于设置矩形的描边颜色。可以通过设置颜色值或使用Brush填充。这里默认是红色
                                StrokeThickness = 1, // 用于设置矩形的描边粗细。
                                CameraId = car.CameraId
                            };
                            lists.Add(rect);
                        }
                    }
                }
            }
            return lists;
        }
    }
}