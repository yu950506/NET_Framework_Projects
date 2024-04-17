using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    /// <summary>
    /// 螺栓模型
    /// </summary>
    public class BoltModel
    {
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

        private int sum;

        public int Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        public override string ToString()
        {
            return $"StartDt = {StartDt} ,EndDt = {EndDt},AreaNum = {AreaNum},BoltNum = {BoltNum},Quality = {Quality},Sum = {Sum}";
        }
    }
}