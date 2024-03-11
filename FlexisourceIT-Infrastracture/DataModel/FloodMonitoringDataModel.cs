using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexisourceIT_Infrastracture.DataModel
{
    public class FloodMonitoringDataModel
    {
        public string Id { get; set; }
        public int Easting { get; set; }
        public string GridReference { get; set; }
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public List<MeasureDataModel> Measures { get; set; }
        public int Northing { get; set; }
        public string Notation { get; set; }
        public string StationReference { get; set; }
    }
    public class MeasureDataModel
    {
        public string Id { get; set; }
        public string Parameter { get; set; }
        public string ParameterName { get; set; }
        public int Period { get; set; }
        public string Qualifier { get; set; }
        public string UnitName { get; set; }
    }
}

