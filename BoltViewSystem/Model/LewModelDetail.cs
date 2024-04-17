using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    public class LewModelDetail
    {

		private int lewNum;

		public int LewNum
		{
			get { return lewNum; }
			set { lewNum = value; }
		}

		private DateTime time;

		public DateTime Time
		{
			get { return time; }
			set { time = value; }
		}

        public override string ToString()
        {
            return $"LewModelDetail : LewNum = {LewNum}  , Time = {Time}";
        }
    }
}
