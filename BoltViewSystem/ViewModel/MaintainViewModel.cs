using BoltViewSystem.Model;
using BoltViewSystem.Service;
using BoltViewSystem.View;
using Google.Protobuf.WellKnownTypes;
using LiveCharts;
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
    public class MaintainViewModel : ObservableObject
    {
        // 表头查询条件区域 start

        private string lewNumInput;

        // 螺栓号输入框
        public string LewNumInput
        {
            get { return lewNumInput; }
            set { lewNumInput = value; OnPropertyChanged(); }
        }

        private int lewNum;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; OnPropertyChanged(); }
        }

        //private int areaNum;

        //public int AreaNum
        //{
        //    get { return areaNum; }
        //    set { areaNum = value; OnPropertyChanged(); }
        //}

        //private int boltNum;

        //public int BoltNum
        //{
        //    get { return boltNum; }
        //    set { boltNum = value; OnPropertyChanged(); }
        //}

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

        //private List<int> areaNumList;

        //public List<int> AreaNumList
        //{
        //    get { return areaNumList; }
        //    set { areaNumList = value; OnPropertyChanged(); }
        //}

        //private List<int> boltNumList;

        //public List<int> BoltNumList
        //{
        //    get { return boltNumList; }
        //    set { boltNumList = value; OnPropertyChanged(); }
        //}

        // 表头查询条件区域 end

        private void InitData()
        {
            //AreaNumList = new List<int>() { 1, 2, 3 };
            //BoltNumList = new List<int>() { 1, 2, 3, 4 };
            startDt = DateTime.Now;
            endDt = DateTime.Now;
        }

        private ObservableCollection<BoltPositionModel> boltPositionModelsObservableCollection;

        public ObservableCollection<BoltPositionModel> BoltPositionModelsObservableCollection
        {
            get { return boltPositionModelsObservableCollection; }
            set { boltPositionModelsObservableCollection = value; OnPropertyChanged(); }
        }

        public DelegateCommand ButtonSelectDelegateCommand { get; set; }

        public DelegateCommand ButtonDeleteDelegateCommand { get; set; }

        public DelegateCommand SelectDetailDelegateCommand { get; set; }

        public DelegateCommand AreaNumSelectionChangedCommand { get; set; }

        public DelegateCommand ButtonExportDelegateCommand { get; set; }

        public MaintainViewModel()
        {
            InitData();
            //  AreaNumSelectionChangedCommand = new DelegateCommand(AreaNumSelectionChangedCommandImpl);
            ButtonDeleteDelegateCommand = new DelegateCommand(ButtonDeleteDelegateCommandImpl);
            ButtonSelectDelegateCommand = new DelegateCommand(ButtonSelectDelegateCommandImpl);
            SelectDetailDelegateCommand = new DelegateCommand(SelectDetailDelegateCommandImpl);
            ButtonExportDelegateCommand = new DelegateCommand(ButtonExportDelegateCommandImpl);
        }

        public void ButtonExportDelegateCommandImpl(object paramter)
        {
            if (BoltPositionModelsObservableCollection == null || BoltPositionModelsObservableCollection.Count <= 0)
            {
                MessageBox.Show("当前表格无数据，无需导出");
                return;
            }

            try
            {
                // 将当前集合数据导出
                DataTable dt = new DataTable();
                dt.Columns.Add("吊具号");
                dt.Columns.Add("区域号");
                dt.Columns.Add("螺栓号");
                dt.Columns.Add("中心位置像素横坐标");
                dt.Columns.Add("中心位置像素纵坐标");
                dt.Columns.Add("水平偏移量");
                dt.Columns.Add("垂直偏移量");
                dt.Columns.Add("时间");
                foreach (BoltPositionModel boltModel in BoltPositionModelsObservableCollection)
                {
                    dt.Rows.Add(boltModel.LewNum, boltModel.AreaNum, boltModel.BoltNum, boltModel.RMid, boltModel.CMid, boltModel.HvRMid, boltModel.HvCMid, boltModel.Time);
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

        private readonly IBoltPositionModelService boltPositionModelService = new BoltPositionModelServiceImpl();

        /// <summary>
        ///  双击查询明细的功能
        /// </summary>
        /// <param name="parameter"></param>
        public void SelectDetailDelegateCommandImpl(object parameter)
        {
            if (parameter != null)
            {
                BoltPositionModel boltPositionModel = parameter as BoltPositionModel;
                Trace.WriteLine(DateTime.Now + "" + boltPositionModel);

                // 打开详情页面

                BoltPositionDetailView boltPositionDetailView = new BoltPositionDetailView(boltPositionModel);

                boltPositionDetailView.ShowDialog();
            }
        }

        public void ButtonSelectDelegateCommandImpl(object parameter)
        {
            // 判断参数
            try
            {
                // 先判断是否为空

                if (String.IsNullOrEmpty(LewNumInput))
                {
                    LewNum = 0;
                }
                else
                {
                    LewNum = int.Parse(LewNumInput);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"'{LewNumInput}' 输入有误，请输入正确的吊具号！");
                return;
            }
            if (StartDt > EndDt)
            {
                MessageBox.Show("开始时间不能大于结束时间!");
                return;
            }

            BoltPositionModel model = new BoltPositionModel();
            model.StartDt = startDt;
            model.EndDt = endDt;
            model.LewNum = LewNum;

            List<BoltPositionModel> boltPositionModelList = boltPositionModelService.GetPositions(model);

            if (boltPositionModelList.Count > 0)
            {// 为当前表格数据赋值
                try
                {
                    BoltPositionModelsObservableCollection = new ObservableCollection<BoltPositionModel>(boltPositionModelList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("当前查询无数据");
            }
        }

        public void ButtonDeleteDelegateCommandImpl(object parameter)
        {
            // 1.将表头参数情况
            LewNumInput = "";
            StartDt = DateTime.Now;
            EndDt = DateTime.Now;
            // 清空表格数据
            if (BoltPositionModelsObservableCollection != null)
            {
                BoltPositionModelsObservableCollection.Clear();
            }
        }

        // 区域号变更的功能
        //public void AreaNumSelectionChangedCommandImpl(object paramter)
        //{
        //    Trace.WriteLine("156446");
        //    if (AreaNum == 2)
        //    {
        //        BoltNumList.Clear();
        //        BoltNumList.Add(1);
        //        BoltNumList.Add(2);
        //    }
        //    else
        //    {
        //        BoltNumList.Clear();
        //        // 每个区域最多有4个螺栓，1，3区域有4个螺栓，2区域有两个螺栓
        //        for (int i = 1; i <= 4; i++)
        //        {
        //            BoltNumList.Add(i);
        //        }
        //    }
        //}
    }
}