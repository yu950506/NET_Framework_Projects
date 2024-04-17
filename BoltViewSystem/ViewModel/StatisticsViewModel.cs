using BoltViewSystem.Model;
using BoltViewSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace BoltViewSystem.ViewModel
{
    public class StatisticsViewModel : ObservableObject
    {
        // =============================== 表头查询条件 数据绑定属性区域 start =======================================
        private ObservableCollection<int> lewNumList = new ObservableCollection<int>();

        /// <summary>
        /// 吊具号集合
        /// </summary>
        public ObservableCollection<int> LewNumList
        {
            get { return lewNumList; }
            set { lewNumList = value; OnPropertyChanged(); }
        }

        private int lewNum = 1;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> areaNumList = new ObservableCollection<int>();

        /// <summary>
        /// 区域号集合
        /// </summary>
        public ObservableCollection<int> AreaNumList
        {
            get { return areaNumList; }
            set { areaNumList = value; OnPropertyChanged(); }
        }

        private int areaNum = 1;

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

        private int boltNum = 1;

        public int BoltNum
        {
            get { return boltNum; }
            set { boltNum = value; }
        }

        private DateTime startDt = DateTime.Now;

        public DateTime StartDt
        {
            get { return startDt; }
            set { startDt = value; OnPropertyChanged(); }
        }

        private DateTime endDt = DateTime.Now;

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

        private string quality = "否";

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
            for (int i = 1; i <= 400; i++)
            {
                lewNumList.Add(i);
            }
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
            qualityList.Add("是");
            qualityList.Add("否");
        }

        // =============================== 表头查询条件 数据绑定属性区域 end =======================================

        private ObservableCollection<ModelData> modelDataObservableCollection = new ObservableCollection<ModelData>();

        public ObservableCollection<ModelData> ModelDataObservableCollection
        {
            get { return modelDataObservableCollection; }
            set { modelDataObservableCollection = value; OnPropertyChanged(); }
        }

        // 分页区域====================== start

        private List<int> pageCountList = new List<int> { 10, 20, 50 };

        /// <summary>
        /// 前端绑定的下拉选择框的值
        /// </summary>
        public List<int> PageCountList
        {
            get { return pageCountList; }
            set { pageCountList = value; OnPropertyChanged(); }
        }

        private int pageCount = 10;

        /// <summary>
        /// 每页显示的记录数，默认是10条
        /// </summary>
        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; OnPropertyChanged(); }
        }

        private int currentPage;

        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged(); }
        }

        private int totalPage;

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; OnPropertyChanged(); }
        }

        private int totalCount;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; OnPropertyChanged(); }
        }

        private int currentStart;

        /// <summary>
        /// 当前记录开始数
        /// </summary>
        public int CurrentStart
        {
            get { return currentStart; }
            set { currentStart = value; OnPropertyChanged(); }
        }

        private int currentEnd;

        /// <summary>
        /// 当前记录结束数
        /// </summary>
        public int CurrentEnd
        {
            get { return currentEnd; }
            set { currentEnd = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 首页的命令
        /// </summary>
        public DelegateCommand CommFirst { get; set; }

        /// <summary>
        /// 上一页的命令
        /// </summary>
        public DelegateCommand CommPrev { get; set; }

        /// <summary>
        /// 下一页的命令
        /// </summary>
        public DelegateCommand CommNext { get; set; }

        /// <summary>
        /// 尾页的命令
        /// </summary>
        public DelegateCommand CommLast { get; set; }

        // 分页方法的具体实现

        /// <summary>
        /// 下一页的命令
        /// </summary>
        /// <param name="paramter"></param>
        private void Next(object paramter)
        {
            if (CurrentPage < TotalPage)
            {
                TotalPage = (TotalCount / PageCount) * PageCount < TotalCount ? TotalCount / PageCount + 1 : TotalCount / PageCount;
                CurrentStart = CurrentPage * PageCount + 1;
                CurrentEnd = CurrentStart + PageCount - 1 > TotalCount ? TotalCount : CurrentStart + PageCount - 1;
                CurrentPage++;
                // 封装数据模型
                List<ModelData> modelDatas = iModelDataService.SelectAllModelData(CurrentStart - 1, PageCount);
                ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="paramter"></param>
        private void Last(object paramter)
        {
            TotalPage = (TotalCount / PageCount) * PageCount < TotalCount ? TotalCount / PageCount + 1 : TotalCount / PageCount;
            CurrentPage = TotalPage;
            CurrentStart = TotalPage > 1 ? (CurrentPage - 1) * PageCount + 1 : 1;
            CurrentEnd = TotalCount;
            List<ModelData> modelDatas = iModelDataService.SelectAllModelData(CurrentStart - 1, PageCount);
            ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
        }

        /// <summary>
        /// 上一页的功能
        /// </summary>
        /// <param name="paramter"></param>
        private void Prev(object paramter)
        {
            if (CurrentPage > 1)
            {
                TotalPage = (TotalCount / PageCount) * PageCount < TotalCount ? TotalCount / PageCount + 1 : TotalCount / PageCount;
                CurrentPage--;
                CurrentEnd = CurrentStart - 1;
                CurrentStart = (CurrentPage - 1) * PageCount + 1;
                List<ModelData> modelDatas = iModelDataService.SelectAllModelData(CurrentStart - 1, PageCount);
                ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
            }
        }

        /// <summary>
        /// 首页的功能
        ///
        /// </summary>
        /// <param name="paramter"></param>
        private void First(object paramter)
        {
            CurrentPage = 1;
            TotalPage = (TotalCount / PageCount) * PageCount < TotalCount ? TotalCount / PageCount + 1 : TotalCount / PageCount;
            CurrentStart = 1;
            CurrentEnd = PageCount > TotalCount ? TotalCount : PageCount;
            List<ModelData> modelDatas = iModelDataService.SelectAllModelData(CurrentStart - 1, PageCount);
            ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
        }

        // 初始化表格数据，即首次分页的算法
        public void InitDataGrid()
        {
            TotalCount = iModelDataService.SelectCountModelData();
            TotalPage = (TotalCount / PageCount) * PageCount < TotalCount ? TotalCount / PageCount + 1 : TotalCount / PageCount;
            CurrentPage = 1;
            CurrentStart = 1;
            CurrentEnd = PageCount > TotalCount ? TotalCount : PageCount;
            List<ModelData> modelDatas = iModelDataService.SelectAllModelData(CurrentStart - 1, PageCount);
            ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
        }

        // 分页区域end

        // ===============================  命令绑定区域  =======================================

        public DelegateCommand ButtonSelectDelegateCommand { get; set; }

        public DelegateCommand ButtonDeleteDelegateCommand { get; set; }

        public DelegateCommand AreaNumSelectionChangedCommand { get; set; }

        // ===============================  成员变量区域  =======================================
        private IModelDataService iModelDataService = new ModelDataService();

        public StatisticsViewModel()
        {
            // 初始化基础数据
            InitData();
            // 初始化表格及分页数据
            InitDataGrid();
            // 初始化命令
            ButtonSelectDelegateCommand = new DelegateCommand(ButtonSelectDelegateCommandImpl);
            AreaNumSelectionChangedCommand = new DelegateCommand(AreaNumSelectionChangedCommandImpl);
            ButtonDeleteDelegateCommand = new DelegateCommand(ButtonDeleteDelegateCommandImpl);

            // 初始化分页命令
            CommFirst = new DelegateCommand(First);
            CommPrev = new DelegateCommand(Prev);
            CommNext = new DelegateCommand(Next);
            CommLast = new DelegateCommand(Last);
        }

        // 按钮查询的功能
        public void ButtonSelectDelegateCommandImpl(object paramter)
        {
            MessageBox.Show(LewNum.ToString() + "," + AreaNum.ToString() + "," + BoltNum.ToString() + "," + Quality + "," + StartDt + "," + EndDt);

            List<ModelData> modelDatas = iModelDataService.SelectAllModelData(0, PageCount);

            ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
        }

        // 按钮清空的功能
        public void ButtonDeleteDelegateCommandImpl(object paramter)
        {
            // 1.将表头参数情况
            LewNum = 0;
            AreaNum = 0;
            BoltNum = 0;

            MessageBox.Show(LewNum.ToString() + "," + AreaNum.ToString() + "," + BoltNum.ToString() + "," + Quality + "," + StartDt + "," + EndDt);
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
    }
}