using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    /// <summary>
    /// 统计分析模型数据
    /// </summary>
    public class ModelData
    {
        private int lewNum;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; }
        }

        private int areaNum;

        public int AreaNum
        {
            get { return areaNum; }
            set { areaNum = value; }
        }

        private int boltNum;

        public int BoltNum
        {
            get { return boltNum; }
            set { boltNum = value; }
        }

        private string quality;

        public string Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}