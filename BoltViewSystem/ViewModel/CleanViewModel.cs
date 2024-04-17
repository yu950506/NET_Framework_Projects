using BoltViewSystem.Service;
using BoltViewSystem.Utils;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;

namespace BoltViewSystem.ViewModel
{
    public class CleanViewModel : ObservableObject
    {
        private int cleanDay;

        /// <summary>
        /// 清理间隔天数
        /// </summary>
        public int CleanDay
        {
            get { return cleanDay; }
            set { cleanDay = value; OnPropertyChanged(); }
        }

        private int cleanHour;

        /// <summary>
        /// 清理时间-小时
        /// </summary>
        public int CleanHour
        {
            get { return cleanHour; }
            set { cleanHour = value; OnPropertyChanged(); }
        }

        private int cleanMinute;

        /// <summary>
        /// 清理时间-分钟
        /// </summary>
        public int CleanMinute
        {
            get { return cleanMinute; }
            set { cleanMinute = value; OnPropertyChanged(); }
        }

        private int cleanSecond;

        /// <summary>
        /// 清理时间-秒
        /// </summary>
        public int CleanSecond
        {
            get { return cleanSecond; }
            set { cleanSecond = value; OnPropertyChanged(); }
        }

        private int saveNewPhoto;

        /// <summary>
        /// 保留最新的照片数
        /// </summary>
        public int SaveNewPhoto
        {
            get { return saveNewPhoto; }
            set { saveNewPhoto = value; OnPropertyChanged(); }
        }

        private string cleanTextContent;

        /// <summary>
        /// 前端展示清理策略数据
        /// </summary>
        public string CleanTextContect
        {
            get { return cleanTextContent; }
            set { cleanTextContent = value; OnPropertyChanged(); }
        }

        // 下拉选择框集合

        public ObservableCollection<int> CleanDays { get; set; }
        public ObservableCollection<int> CleanHours { get; set; }
        public ObservableCollection<int> CleanMinutes { get; set; }
        public ObservableCollection<int> CleanSeconds { get; set; }
        public ObservableCollection<int> SaveNewPhotos { get; set; }

        /// <summary>
        /// 和前端按钮删除时绑定的命令
        /// </summary>
        public DelegateCommand CleanCommand { get; set; }

        /// <summary>
        /// 构造函数，初始化数据和命令
        /// </summary>
        public CleanViewModel()
        {
            InitData();
            CleanCommand = new DelegateCommand(CleanCommandImpl);
            ButtonUpdateCommand = new DelegateCommand(ButtonUpdateCommandImpl);
        }

        /// <summary>
        /// 构造函数初始化的时候执行的函数，定时器的相关默认值
        /// </summary>
        private void InitData()
        {
            CleanDays = new ObservableCollection<int>();
            for (int i = 1; i <= 15; i++)
            {
                CleanDays.Add(i);
            }
            CleanHours = new ObservableCollection<int>();
            for (int i = 0; i <= 23; i++)
            {
                CleanHours.Add(i);
            }
            CleanMinutes = new ObservableCollection<int>();
            for (int i = 0; i <= 59; i++)
            {
                CleanMinutes.Add(i);
            }
            CleanSeconds = new ObservableCollection<int>();
            for (int i = 0; i <= 59; i++)
            {
                CleanSeconds.Add(i);
            }
            SaveNewPhotos = new ObservableCollection<int>() { 10, 20, 30, 40, 50, 70, 100 };

            // 设置定时器的默认值
            cleanDay = 7;
            CleanHour = 2;
            CleanMinute = 0;
            CleanSecond = 0;
            saveNewPhoto = 50;
        }

        // 定义一个成员变量定时器，用于定时删除过期照片
        private System.Timers.Timer timer;

        /// <summary>
        /// 点击按钮执行生产清理照片定时器的命令的实际执行方法
        /// </summary>
        /// <param name="parameter"></param>
        public void CleanCommandImpl(object parameter)
        {
            // 如果定时器不为null,就停止定时器，释放定时器资源
            if (timer != null)
            {
                // 停止定时器
                timer.Stop();
                // 释放定时器资源
                timer.Dispose();
                Trace.WriteLine("上次定时清理策略已清除");
            }
            // 创建一个定时器
            timer = new System.Timers.Timer();

            // 计算首次触发时间
            DateTime firstRunTime = DateTime.Today.AddHours(CleanHour).AddMinutes(CleanMinute).AddSeconds(CleanSecond); // 计算首次运行是几点几秒
            if (firstRunTime < DateTime.Now) // 如果首次运行时间小于当前时间，就将时间往后延迟一天
            {
                firstRunTime = firstRunTime.AddDays(1);
            }
            // 计算距离下一个触发时间的时间间隔
            double interval = (firstRunTime - DateTime.Now).TotalMilliseconds;

            // 设置定时器第一次触发的时间间隔
            timer.Interval = interval;
            timer.AutoReset = true;
            timer.Elapsed += TimerElapsedCleanPhoto;
            timer.Start();

            // 前端显示当前清理策略提示
            CleanTextContect = $"当前定时清理策略：每隔【{CleanDay}】天【{CleanHour}】点【{CleanMinute}】分【{CleanSecond}】秒，定时清理照片，并且只保留最新的【{SaveNewPhoto}】张照片。";
            CleanTextContect += "\n" + $"首次触发时间：{firstRunTime}";

            // 打印下一个触发时间
            Trace.WriteLine("当前定时器的时间间隔" + timer.Interval / 1000 / 60 / 60 + "小时");
            MessageBox.Show("定时策略保存成功");
        }

        /// <summary>
        /// 定时清理照片的程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void TimerElapsedCleanPhoto(object sender, ElapsedEventArgs e)
        {
            try
            {
                // 定时器触发时间
                DateTime timerDt = e.SignalTime;
                // 删除照片的开始时间
                DateTime startDt = DateTime.Now;
                // 执行删除照片的程序
                CleanPhoto(SaveNewPhoto);
                // 删除照片的结束时间
                DateTime endDt = DateTime.Now;
                Trace.WriteLine($"定时器触发时间：{timerDt}，清理照片开始时间：{startDt}，清理照片结束时间：{endDt}");
                // 停止当前定时器
                ((System.Timers.Timer)sender).Stop();
                // 释放定时器资源 ,这里不能释放资源，不然下一次定时器就访问不到对象了
                // ((System.Timers.Timer)sender).Dispose();
                // 计算下一个触发时间
                DateTime nextRunTime = DateTime.Today.AddDays(CleanDay).AddHours(CleanHour).AddMinutes(CleanMinute).AddSeconds(CleanSecond); // 下一个凌晨2点
                if (nextRunTime < DateTime.Now) // 如果下次运行时间小于当前时间，就将时间往后延迟一天
                {
                    nextRunTime = nextRunTime.AddDays(1);
                }
                // 计算距离下一个触发时间的时间间隔
                double interval = (nextRunTime - DateTime.Now).TotalMilliseconds;
                // 重新设置定时器的间隔和触发时间
                ((System.Timers.Timer)sender).Interval = interval;
                // 启动定时器
                ((System.Timers.Timer)sender).Start();
                CleanTextContect += " 执行结果：成功";
                CleanTextContect += "\n" + $"下一次启动的时间：{nextRunTime}";
                Trace.WriteLine($"当前定时器的下一次启动的时间为：{nextRunTime}");
                Trace.WriteLine("当前定时器的时间间隔" + timer.Interval / 1000 / 60 / 60 + "小时");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("定时器执行出错：" + ex.ToString());
            }
        }

        /// <summary>
        /// 执行删除照片的程序
        /// </summary>
        private void CleanPhoto(int saveNewPhoto)
        {
            FileUtils.TraverseDirectoryDeletePhotos(@"D:\20240202\Cam1", saveNewPhoto);
            FileUtils.TraverseDirectoryDeletePhotos(@"D:\20240202\Cam2", saveNewPhoto);
            FileUtils.TraverseDirectoryDeletePhotos(@"D:\20240202\Cam3", saveNewPhoto);
            FileUtils.TraverseDirectoryDeletePhotos(@"D:\20240202\Cam4", saveNewPhoto);
        }

        private int lewNum;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; OnPropertyChanged(); }
        }

        private string lewNumInput = String.Empty;

        public string LewNumInput
        {
            get { return lewNumInput; }
            set { lewNumInput = value; OnPropertyChanged(); }
        }

        public DelegateCommand ButtonUpdateCommand { get; set; }
        private readonly ITemplateService templateService = new TemplateServiceImpl();

        public void ButtonUpdateCommandImpl(object parameter)
        {
            Trace.WriteLine(parameter.ToString());
            try
            {
                // 根据吊具号更新数据库模版状态
                if (parameter != null)
                {
                    int lewNum = 0;
                    try
                    {
                        lewNum = int.Parse(LewNumInput);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("请输入合格的吊具号");
                        return;
                    }

                    if (lewNum == 0)
                    {
                        MessageBox.Show($"不存在 {lewNum} 号的吊具号");
                        return;
                    }
                    // 合格的吊具号

                    // 根据吊具号 更新模板状态
                    int result1 = 0, result2 = 0, result3 = 0;
                    templateService.UpdateTemplateByLewNum(lewNum, ref result1, ref result2, ref result3);
                    if (result1 >= 0 && result2 >= 0 && result3 >= 0)
                    {
                        MessageBox.Show($"{lewNum} 号吊具的模板更新成功");
                    }
                }
                else
                {
                    MessageBox.Show($"{parameter} 为空");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}