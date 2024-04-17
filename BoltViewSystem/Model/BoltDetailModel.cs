using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    public class BoltDetailModel
    {
        private int boltNum;

        public int BoltNum
        {
            get { return boltNum; }
            set { boltNum = value; }
        }

        private string ang;

        public string Ang
        {
            get { return ang; }
            set { ang = value; }
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