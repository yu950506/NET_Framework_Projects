using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    public class Area2Model
    {
        public int Id { get; set; }
        public int LewNum { get; set; }
        public string ImagePath { get; set; }
        public double Bolt1Ang { get; set; }
        public string Bolt1Res { get; set; }
        public double Bolt2Ang { get; set; }
        public string Bolt2Res { get; set; }

        //public double Bolt3Ang { get; set; }
        //public string Bolt3Res { get; set; }
        //public double Bolt4Ang { get; set; }
        //public string Bolt4Res { get; set; }
        public DateTime Time { get; set; }
    }
}