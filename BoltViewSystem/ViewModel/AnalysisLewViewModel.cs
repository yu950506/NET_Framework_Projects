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

namespace BoltViewSystem.ViewModel
{
    public class AnalysisLewViewModel : ObservableObject
    {
        private ObservableCollection<int> lewNumList = new ObservableCollection<int>();

        /// <summary>
        /// 吊具号集合
        /// </summary>
        public ObservableCollection<int> LewNumList
        {
            get { return lewNumList; }
            set { lewNumList = value; OnPropertyChanged(); }
        }

        private int lewNum;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; OnPropertyChanged(); }
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

        private ObservableCollection<LewModel> lewModeObservableCollection;

        public ObservableCollection<LewModel> LewModeObservableCollection
        {
            get { return lewModeObservableCollection; }
            set { lewModeObservableCollection = value; OnPropertyChanged(); }
        }

        private long lewTotalSum;

        public long LewTotalSum
        {
            get { return lewTotalSum; }
            set { lewTotalSum = value; OnPropertyChanged(); }
        }

        private string lewNumInput;

        public string LewNumInput
        {
            get { return lewNumInput; }
            set { lewNumInput = value; OnPropertyChanged(); }
        }

        public DelegateCommand ButtonSelectDelegateCommand { get; set; }
        public DelegateCommand ButtonDeleteDelegateCommand { get; set; }
        public DelegateCommand SelectDetailDelegateCommand { get; set; }
        public DelegateCommand ButtonExportDelegateCommand { get; set; }

        public void ButtonExportDelegateCommandImpl(object paramter)
        {
            if (LewModeObservableCollection ==null || LewModeObservableCollection.Count <= 0)
            {
                MessageBox.Show("当前表格无数据，无需导出");
                return;
            }

            try
            {
                // 将当前集合数据导出
                DataTable dt = new DataTable();
                dt.Columns.Add("吊具号");
                dt.Columns.Add("不合格次数");
                dt.Columns.Add("开始时间");
                dt.Columns.Add("结束时间");
                foreach (LewModel lewModel in LewModeObservableCollection)
                {
                    dt.Rows.Add(lewModel.LewNum, lewModel.Sum,lewModel.StartDt, lewModel.EndDt);
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

        public void ButtonSelectDelegateCommandImpl(object parameter)
        {

            // 判断参数
            try
            {
             
                // 先判断是否为空

                if (String.IsNullOrEmpty(LewNumInput)){
                    LewNum = 0;
                }
                else{
                    LewNum = int.Parse(LewNumInput);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                MessageBox.Show($"'{LewNumInput}' 输入有误，请输入正确的吊具号！");
                return;
            }
            if (StartDt > EndDt)
            {
                MessageBox.Show("开始时间不能大于结束时间!");
                return;
            }

            // 封装参数
            LewModel model = new LewModel();
            model.StartDt = StartDt;
            model.EndDt = EndDt;
            model.LewNum = LewNum;
            Trace.WriteLine($"LewModel => {model}");
            try
            {
                List<LewModel> lewModels = _modelService.SelectAllByLewModel(model);
                if (lewModels.Count > 0)
                {
                    // 封装集合数据
                    LewModeObservableCollection = new ObservableCollection<LewModel>(lewModels);
                    // 计算当前不合格的吊具总数
                    long totalSum = 0;
                    foreach (var lewModel in lewModels)
                    {
                        totalSum += lewModel.Sum;
                    }
                    LewTotalSum = totalSum;
                    // 绘制柱状图
                    DrawColumnSeries();
                }
                else
                {
                    MessageBox.Show("当前查询无数据");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        // 按钮清空的功能
        public void ButtonDeleteDelegateCommandImpl(object paramter)
        {
            // 1.将表头参数情况
            LewNumInput = "";
            StartDt = DateTime.Now;
            EndDt = DateTime.Now;
            // 清空表格数据
            if (LewModeObservableCollection != null)
            {
                LewModeObservableCollection.Clear();
            }
            // 清空柱状图数据
            if (SeriesCollection != null)
            {
                SeriesCollection.Clear();
            }
            if (LewNumListX != null)
            {
                LewNumListX.Clear();
            }

            // 清空总数
            LewTotalSum = 0;
        }

        // 表格双击查看明细的功能
        public void SelectDetailDelegateCommandImpl(object parameter)
        {
            if (parameter != null)
            {
                LewModel lewModel = parameter as LewModel;
                Trace.WriteLine(lewModel.ToString());
                LewDetailView lewDetailView = new LewDetailView(lewModel);
                lewDetailView.ShowDialog();
            }
        }

        private readonly ILewModelService _modelService = new LewModelServiceImpl();

        public AnalysisLewViewModel()
        {
            InitData();
            ButtonSelectDelegateCommand = new DelegateCommand(ButtonSelectDelegateCommandImpl);
            ButtonDeleteDelegateCommand = new DelegateCommand(ButtonDeleteDelegateCommandImpl);
            SelectDetailDelegateCommand = new DelegateCommand(SelectDetailDelegateCommandImpl);
            ButtonExportDelegateCommand = new DelegateCommand(ButtonExportDelegateCommandImpl);
        }

        private void InitData()
        {
            //  一共有406个吊具
            for (int i = 1; i <= 406; i++)
            {
                lewNumList.Add(i);
            }
            StartDt = DateTime.Now;
            EndDt = DateTime.Now;
        }

        private List<String> lewNumListX;

        public List<String> LewNumListX
        {
            get { return lewNumListX; }
            set { lewNumListX = value; OnPropertyChanged(); }
        }

        public Func<double, string> Formatter { get; set; }

        public SeriesCollection seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; OnPropertyChanged(); }
        }

        // 查询并渲染柱状图数据
        private void DrawColumnSeries()
        {
            SeriesCollection = new SeriesCollection();

            // 显示柱状图 X轴上的数据
            List<String> xStrings = new List<String>();

            // 显示柱状图 Y 轴上的的数据
            ColumnSeries columnSerie = new ColumnSeries();
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (LewModel lewModel in LewModeObservableCollection)
            {
                xStrings.Add(lewModel.LewNum.ToString());
                chartValues.Add(lewModel.Sum);
            }
            columnSerie.Title = "不合格总数"; // 数据的标题，即图例上面的标题
            columnSerie.Values = chartValues; // 数据值的绑定，ChartValues是泛型，可以自己定义类型
            columnSerie.DataLabels = true; // 是否显示数据，即在柱状图上显示数值
            SeriesCollection.Add(columnSerie); // 为前端Y轴柱状图绑定数据
            LewNumListX = xStrings; // 为前端X轴绑定数据
        }
    }
}