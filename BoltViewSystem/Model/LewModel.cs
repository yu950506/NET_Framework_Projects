using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    /// <summary>
    /// 吊具号维度的模型
    /// </summary>
    public class LewModel
    {
        private int lewNum;

        public int LewNum
        {
            get { return lewNum; }
            set { lewNum = value; }
        }

        private int sum;

        public int Sum
        {
            get { return sum; }
            set { sum = value; }
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

        public override string ToString()
        {
            return $"吊具号维度模型 LewModel ：LewNum = {LewNum} , Sum = {Sum} , StartDt = {StartDt} , EndDt = {EndDt}";
        }
    }
}