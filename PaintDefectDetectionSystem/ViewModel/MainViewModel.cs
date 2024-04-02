using PaintDefectDetectionSystem.Model;
using PaintDefectDetectionSystem.Service;
using PaintDefectDetectionSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintDefectDetectionSystem.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        // 与前端绑定的属性

        // 主页车身图片
        private ImageSource carImageUri;

        public ImageSource CarImageUri
        {
            get
            {
                return carImageUri;
            }
            set
            {
                carImageUri = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Car> carObservableCollection;

        public ObservableCollection<Car> CarObservableCollection
        {
            get
            {
                return carObservableCollection;
            }
            set
            {
                carObservableCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RectangleModel> rectangles2H00;

        public ObservableCollection<RectangleModel> Rectangles2H00
        { get { return rectangles2H00; } set { rectangles2H00 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles2H01;

        public ObservableCollection<RectangleModel> Rectangles2H01
        { get { return rectangles2H01; } set { rectangles2H01 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles2H02;

        public ObservableCollection<RectangleModel> Rectangles2H02
        { get { return rectangles2H02; } set { rectangles2H02 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles2H03;

        public ObservableCollection<RectangleModel> Rectangles2H03
        { get { return rectangles2H03; } set { rectangles2H03 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles2H04;

        public ObservableCollection<RectangleModel> Rectangles2H04
        { get { return rectangles2H04; } set { rectangles2H04 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles3H00;

        public ObservableCollection<RectangleModel> Rectangles3H00
        { get { return rectangles3H00; } set { rectangles3H00 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles3H01;

        public ObservableCollection<RectangleModel> Rectangles3H01
        { get { return rectangles3H01; } set { rectangles3H01 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles3H02;

        public ObservableCollection<RectangleModel> Rectangles3H02
        { get { return rectangles3H02; } set { rectangles3H02 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles3H03;

        public ObservableCollection<RectangleModel> Rectangles3H03
        { get { return rectangles3H03; } set { rectangles3H03 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles3H04;

        public ObservableCollection<RectangleModel> Rectangles3H04
        { get { return rectangles3H04; } set { rectangles3H04 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles4H00;

        public ObservableCollection<RectangleModel> Rectangles4H00
        { get { return rectangles4H00; } set { rectangles4H00 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles4H01;

        public ObservableCollection<RectangleModel> Rectangles4H01
        { get { return rectangles4H01; } set { rectangles4H01 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles4H02;

        public ObservableCollection<RectangleModel> Rectangles4H02
        { get { return rectangles4H02; } set { rectangles4H02 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles4H03;

        public ObservableCollection<RectangleModel> Rectangles4H03
        { get { return rectangles4H03; } set { rectangles4H03 = value; OnPropertyChanged(); } }

        private ObservableCollection<RectangleModel> rectangles4H04;

        public ObservableCollection<RectangleModel> Rectangles4H04
        { get { return rectangles4H04; } set { rectangles4H04 = value; OnPropertyChanged(); } }

        // 与前端调用的命令

        public DelegateCommand ButtonClickCommand { get; set; }

        // 下拉选择框车身集合
        public List<String> BodyNoList { get; set; } = new List<String>();

        public ObservableCollection<String> CameraIdList { get; set; } = new ObservableCollection<string>();

        public MainViewModel()
        {
            LoadBodyNoListData();
            LoadCameraIdListData();
            ButtonClickCommand = new DelegateCommand(ButtonClickCommandOpenNewWindow);
        }

        /// <summary>
        /// 点击按钮执行的方法
        /// </summary>
        /// <param name="parameter">传过去的是矩形缺陷数据集合</param>
        public void ButtonClickCommandOpenNewWindow(object parameter)
        {
            if (parameter is ObservableCollection<RectangleModel>)
            {
                ObservableCollection<RectangleModel> rectangleModels = parameter as ObservableCollection<RectangleModel>;
                if (rectangleModels.Count > 0)
                {
                    string cameraId = rectangleModels[0].CameraId;
                    DetailWindow detailWindow = new DetailWindow();
                    DetailViewModel detailViewModel = detailWindow.DataContext as DetailViewModel;
                    detailViewModel.ImageUri = cameraId;
                    detailViewModel.RectangleModels = rectangleModels;
                    detailWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("该区域没有缺陷，无需点开");
            }
        }

        /// <summary>
        /// 初始化的时候需要加载有缺陷的车身号，现在是模拟手动添加了几条数据，后面需要修改为从数据库中查询
        /// </summary>
        private void LoadBodyNoListData()
        {
            // 添加车身号
            BodyNoList.Add("1");
            BodyNoList.Add("56");
            BodyNoList.Add("238");
            BodyNoList.Add("436");
            BodyNoList.Add("1101");
        }

        private void LoadCameraIdListData()
        {
            // 添加相机号
            CameraIdList.Add("2H00");
            CameraIdList.Add("2H01");
            CameraIdList.Add("2H02");
            CameraIdList.Add("2H03");
            CameraIdList.Add("2H04");
            CameraIdList.Add("3H00");
            CameraIdList.Add("3H01");
            CameraIdList.Add("3H02");
            CameraIdList.Add("3H03");
            CameraIdList.Add("3H04");
            CameraIdList.Add("4H00");
            CameraIdList.Add("4H01");
            CameraIdList.Add("4H02");
            CameraIdList.Add("4H03");
            CameraIdList.Add("4H04");
        }

        /// <summary>
        /// 调用下拉选择框，选择具体指需要执行的操作
        /// </summary>
        /// <param name="BodyNo"></param>
        public void ComboBoxSelectCommand(string BodyNo)
        {
            // 后续可以切换成使用数据库的实现
            ICarSerivice carSerivice = new CarSeriviceMockImpl();
            // 定义弹框提示语
            String Message = String.Empty;
            // 1. 显示车身图片,根据车身号查询对应的照片
            string carImaUri = carSerivice.SelectCarImgURIByBodyNo(BodyNo);
            if (!string.IsNullOrEmpty(carImaUri))
            {
                CarImageUri = new BitmapImage(new Uri(carImaUri));
            }
            else
            {
                Message += $"未查询到车身对应的照片";
                CarImageUri = null;
            }

            // 2. 显示车的详细信息
            List<Car> carList = carSerivice.SelectCarListByBodyNo(BodyNo);
            if (carList != null && carList.Count > 0)
            {
                CarObservableCollection = new ObservableCollection<Car>(carList);
            }
            else
            {
                Message += $"未查询到车身对应缺陷信息";
                CarObservableCollection = null;
            }

            // 3. 根据车身信息绘制缺陷坐标

            Rectangles2H00 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("2H00", BodyNo));
            Rectangles2H01 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("2H01", BodyNo));
            Rectangles2H02 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("2H02", BodyNo));
            Rectangles2H03 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("2H03", BodyNo));
            Rectangles2H04 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("2H04", BodyNo));

            Rectangles3H00 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("3H00", BodyNo));
            Rectangles3H01 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("3H01", BodyNo));
            Rectangles3H02 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("3H02", BodyNo));
            Rectangles3H03 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("3H03", BodyNo));
            Rectangles3H04 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("3H04", BodyNo));

            Rectangles4H00 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("4H00", BodyNo));
            Rectangles4H01 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("4H01", BodyNo));
            Rectangles4H02 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("4H02", BodyNo));
            Rectangles4H03 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("4H03", BodyNo));
            Rectangles4H04 = new ObservableCollection<RectangleModel>(carSerivice.SelectRectangleByCarameIdAndBodyNo("4H04", BodyNo));

            // 4. 错误弹框提醒

            if (!string.IsNullOrEmpty(Message))
            {
                MessageBox.Show(Message);
            }
        }
    }
}