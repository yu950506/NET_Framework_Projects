using System;

namespace BoltViewSystem.Model
{
    /// <summary>
    /// 表头螺栓查询条件模型数据
    /// </summary>
    public class BoltQueryModel
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

        private DateTime startDt;

        public DateTime StartDt
        {
            get { return startDt; }
            set { startDt = value; }
        }

        private DateTime endDt;

        public DateTime EndDt
        {
            get { return endDt; }
            set { endDt = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public override string ToString()
        {
            return $"BoltQueryModel : LewNum = {LewNum} , AreaNum = {AreaNum} , BoltNum = {BoltNum} , Quality = {Quality} , StartDt = {StartDt}, EndDt = {EndDt}, Time = {Time}";
        }
    }
}