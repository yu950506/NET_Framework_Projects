using BoltViewSystem.Model;
using BoltViewSystem.Service;
using BoltViewSystem.View;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;

//using System.Windows.Forms;

namespace BoltViewSystem.ViewModel
{
    public class AnalysisBoltViewModel : ObservableObject
    {
        // =============================== 表头查询条件 数据绑定属性区域 start =======================================
        //  private ObservableCollection<int> lewNumList = new ObservableCollection<int>();

        /// <summary>
        /// 吊具号集合
        /// </summary>
        //public ObservableCollection<int> LewNumList
        //{
        //    get { return lewNumList; }
        //    set { lewNumList = value; OnPropertyChanged(); }
        //}

        //private int lewNum = 1;

        //public int LewNum
        //{
        //    get { return lewNum; }
        //    set { lewNum = value; OnPropertyChanged(); }
        //  }

        private ObservableCollection<int> areaNumList = new ObservableCollection<int>();

        /// <summary>
        /// 区域号集合
        /// </summary>
        public ObservableCollection<int> AreaNumList
        {
            get { return areaNumList; }
            set { areaNumList = value; OnPropertyChanged(); }
        }

        private int areaNum;

        public int AreaNum
        {
            get { return areaNum; }
            set { areaNum = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> boltNumList = new ObservableCollection<int>();

        /// <summary>
        /// 螺栓号集合
        /// </summary>
        public ObservableCollection<int> BoltNumList
        {
            get { return boltNumList; }
            set { boltNumList = value; OnPropertyChanged(); }
        }

        private int boltNum;

        public int BoltNum
        {
            get { return boltNum; }
            set { boltNum = value; }
        }

        private DateTime startDt;

        public DateTime StartDt
        {
            get { return startDt; }
            set { startDt = value; OnPropertyChanged(); }
        }

        private DateTime endDt;

        public DateTime EndDt
        {
            get { return endDt; }
            set { endDt = value; OnPropertyChanged(); }
        }

        private ObservableCollection<String> qualityList = new ObservableCollection<String>();

        public ObservableCollection<String> QualityList
        {
            get { return qualityList; }
            set { qualityList = value; OnPropertyChanged(); }
        }

        private string quality;

        public string Quality
        {
            get { return quality; }
            set { quality = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 初始化和前端绑定的数据
        /// </summary>
        public void InitData()
        {
            // 一共有400个吊具
            //for (int i = 1; i <= 400; i++)
            //{
            //    lewNumList.Add(i);
            //}
            // 每个吊具有划分了3个局域,区域号
            for (int i = 1; i <= 3; i++)
            {
                areaNumList.Add(i);
            }

            // 每个区域最多有4个螺栓，1，3区域有4个螺栓，2区域有两个螺栓
            for (int i = 1; i <= 4; i++)
            {
                boltNumList.Add(i);
            }

            // 是否合格下拉框集合
            qualityList.Add("1");
            qualityList.Add("True");
            qualityList.Add("False");

            // 为下拉选择框赋值，默认值
            //LewNum = lewNumList[0];
            AreaNum = areaNumList[0];
            BoltNum = boltNumList[0];
            Quality = qualityList[0];
            StartDt = DateTime.Now;
            EndDt = DateTime.Now;
        }

        // =============================== 表头查询条件 数据绑定属性区域 end =======================================

        // ===============================  命令绑定区域  =======================================

        public DelegateCommand ButtonSelectDelegateCommand { get; set; }

        public DelegateCommand ButtonDeleteDelegateCommand { get; set; }

        public DelegateCommand AreaNumSelectionChangedCommand { get; set; }

        public DelegateCommand SelectDetailDelegateCommand { get; set; }

        public DelegateCommand ButtonExportDelegateCommand { get; set; }

        // 按钮清空的功能
        public void ButtonDeleteDelegateCommandImpl(object paramter)
        {
            // 1.将表头查询条件参数清空或者赋予默认值
            StartDt = DateTime.Now; 
            EndDt = DateTime.Now;
            // 2.表格数据
            BoltModelsObservableCollection = null;
            // 3.柱状图数据
            SeriesCollection = null; 
        }

        // 区域号变更的功能
        public void AreaNumSelectionChangedCommandImpl(object paramter)
        {
            if (AreaNum == 2)
            {
                BoltNumList.Clear();
                BoltNumList.Add(1);
                BoltNumList.Add(2);
            }
            else
            {
                BoltNumList.Clear();
                // 每个区域最多有4个螺栓，1，3区域有4个螺栓，2区域有两个螺栓
                for (int i = 1; i <= 4; i++)
                {
                    boltNumList.Add(i);
                }
            }
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        public AnalysisBoltViewModel()
        {
            InitData();
            // 初始化命令
            ButtonSelectDelegateCommand = new DelegateCommand(ButtonSelectDelegateCommandImpl);
            AreaNumSelectionChangedCommand = new DelegateCommand(AreaNumSelectionChangedCommandImpl);
            SelectDetailDelegateCommand = new DelegateCommand(SelectDetailDelegateCommandImpl);
            ButtonExportDelegateCommand = new DelegateCommand(ButtonExportDelegateCommandImpl);
            ButtonDeleteDelegateCommand =   new DelegateCommand(ButtonDeleteDelegateCommandImpl);
        }

        public void ButtonSelectDelegateCommandImpl(object parameter)
        {
            BoltQueryModel boltQueryModel = new BoltQueryModel();
            // boltQueryModel.LewNum = this.LewNum;
            boltQueryModel.AreaNum = AreaNum;
            boltQueryModel.BoltNum = BoltNum;
            boltQueryModel.Quality = Quality;
            boltQueryModel.StartDt = StartDt;
            boltQueryModel.EndDt = EndDt;
            //boltQueryModel.Time = DateTime.Now;

            if (StartDt > EndDt)
            {
                MessageBox.Show("开始时间不能大于结束时间!");
                return;
            }

            Trace.WriteLine("ButtonSelectDelegateCommandImpl => " + boltQueryModel);
            try
            {
                // 查询并渲染表格数据
                List<BoltModel> boltModels = boltModelService.SelectBoltModels(boltQueryModel);

                if (boltModels == null || boltModels.Count <= 0)
                {
                    MessageBox.Show("当前查询无记录");
                    return;
                }

                // 给表格集合数据赋值
                BoltModelsObservableCollection = new ObservableCollection<BoltModel>(boltModels);

                // 给记录总数赋值
                BoltTotalSum = boltModelService.SelectBoltModelsCount(boltQueryModel);

                // SelectBoltModelsObservableCollection(boltQueryModel);
                // 查询并渲染柱状图数据
                DrawColumnSeries();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public void ButtonExportDelegateCommandImpl(object paramter)
        {
            if (BoltModelsObservableCollection == null || BoltModelsObservableCollection.Count <= 0)
            {
                MessageBox.Show("当前表格无数据，无需导出");
                return;
            }
            try
            {
                // 将当前集合数据导出
                DataTable dt = new DataTable();
                dt.Columns.Add("区域号");
                dt.Columns.Add("螺栓号");
                dt.Columns.Add("不合格标志");
                dt.Columns.Add("总数");
                dt.Columns.Add("开始时间");
                dt.Columns.Add("结束时间");
                foreach (BoltModel boltModel in BoltModelsObservableCollection)
                {
                    dt.Rows.Add(boltModel.AreaNum, boltModel.BoltNum, boltModel.Quality, boltModel.Sum, boltModel.StartDt, boltModel.EndDt);
                }
                //指定EPPlus使用非商业化许可证
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // 创建一个ExcelPackage对象，用于操作Excel文件
                using (ExcelPackage excel = new ExcelPackage())
                {
                    // 添加一个工作簿和一个工作表
                    var ws = excel.Workbook.Worksheets.Add("Sheet1");
                    // 从单元格A1开始，将DataTable对象的数据加载到工作表中
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    // 自动调整列宽
                    ws.Cells.AutoFitColumns();
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        DefaultExt = ".xlsx",
                        Filter = "Office 2007 File|*.xlsx|Office 2000-2003 File|*.xls|所有文件|*.*"
                    };
                    if (sfd.ShowDialog() == true)
                    {
                        if (sfd.FileName != "")
                        {
                            excel.SaveAs(sfd.FileName);  //将其进行保存到指定的路径
                            MessageBox.Show("导出文件已存储为: " + sfd.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SelectDetailDelegateCommandImpl(object parameter)
        {
            Trace.WriteLine($"parameter = {parameter}");
            if (parameter != null)
            {
                BoltModel boltModel = (BoltModel)parameter;
                BoltDetailView boltDetailView = new BoltDetailView(boltModel);
                boltDetailView.ShowDialog();
            }
        }

        public SeriesCollection seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged(); }
        }

        //public string[] boltNumArray = new[] { "1-1", "1-2", "1-3", "1-4", "2-1", "2-2", "3-1", "3-2", "3-3", "3-4" };

        //public string[] BoltNumArray
        //{
        //    get { return boltNumArray; }
        //    set { boltNumArray = value; OnPropertyChanged(); }
        //}

        private List<String> boltNumListX;

        public List<String> BoltNumListX
        {
            get { return boltNumListX; }
            set { boltNumListX = value; OnPropertyChanged(); }
        }

        public Func<double, string> Formatter { get; set; }

        private ObservableCollection<BoltModel> boltModelsObservableCollection;

        /// <summary>
        /// 表格数据几个
        /// </summary>
        public ObservableCollection<BoltModel> BoltModelsObservableCollection
        {
            get { return boltModelsObservableCollection; }
            set { boltModelsObservableCollection = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 当前页面的记录总数
        /// </summary>
        private long boltTotalSum;

        public long BoltTotalSum
        {
            get { return boltTotalSum; }
            set { boltTotalSum = value; OnPropertyChanged(); }
        }

        private IBoltModelService boltModelService = new BoltModelServiceImpl();

        private void SelectBoltModelsObservableCollection(BoltQueryModel boltQueryModel)
        {
            List<BoltModel> boltModels = boltModelService.SelectBoltModels(boltQueryModel);

            if (boltModels == null || boltModels.Count <= 0)
            {
                MessageBox.Show("当前查询无记录");
                return;
            }

            // 给表格集合数据赋值
            BoltModelsObservableCollection = new ObservableCollection<BoltModel>(boltModels);

            // 给记录总数赋值
            BoltTotalSum = boltModelService.SelectBoltModelsCount(boltQueryModel);
        }

        // 查询并渲染柱状图数据
        private void DrawColumnSeries()
        {
            SeriesCollection = new SeriesCollection();

            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "True",
            //    Values = new ChartValues<double> { 1, 2, 3, 4, 1, 2, 1, 2, 3, 4 }
            //});

            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "False",
            //    Values = new ChartValues<double> { 1, 2, 3, 4, 1, 2, 1, 2, 3, 4 }
            //});

            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "1",
            //    Values = new ChartValues<double> { 1, 2, 3, 4, 1, 2, 1, 2, 3, 4 }
            //});
            // 显示柱状图 X轴上的数据
            List<String> xStrings = new List<String>();

            // 显示柱状图 Y 轴上的的数据
            ColumnSeries columnSerie = new ColumnSeries();
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (BoltModel boltModel in BoltModelsObservableCollection)
            {
                xStrings.Add(boltModel.AreaNum + "-" + boltModel.BoltNum);
                chartValues.Add(boltModel.Sum);
            }
            columnSerie.Title = "不合格总数"; // 数据的标题，即图例上面的标题
            columnSerie.Values = chartValues; // 数据值的绑定，ChartValues是泛型，可以自己定义类型
            columnSerie.DataLabels = true; // 是否显示数据，即在柱状图上显示数值
            SeriesCollection.Add(columnSerie); // 为前端Y轴柱状图绑定数据
            BoltNumListX = xStrings; // 为前端X轴绑定数据
        }
    }
}