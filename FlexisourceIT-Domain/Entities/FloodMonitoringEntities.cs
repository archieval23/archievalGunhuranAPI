using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexisourceIT_Domain.Entities
{
    public class FloodMonitoringEntities
    {
        public string Id { get; set; }
        public int Easting { get; set; }
        public string GridReference { get; set; }
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public List<MeasureEntities> Measures { get; set; }
        public int Northing { get; set; }
        public string Notation { get; set; }
        public string StationReference { get; set; }
    }
    public class MeasureEntities
    {
        public string Id { get; set; }
        public string Parameter { get; set; }
        public string ParameterName { get; set; }
        public int Period { get; set; }
        public string Qualifier { get; set; }
        public string UnitName { get; set; }
    }

    public class Meta
    {
        public string Publisher { get; set; }
        public string Licence { get; set; }
        public string Documentation { get; set; }
        public string Version { get; set; }
        public string Comment { get; set; }
        public List<string> HasFormat { get; set; }
        public int Limit { get; set; }
    }
    public class Items
    {
        public string Id { get; set; }
        public int Easting { get; set; }
        public string GridReference { get; set; }
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public List<MeasureEntities> Measures { get; set; }
        public int Northing { get; set; }
        public string Notation { get; set; }
        public string StationReference { get; set; }
    }

    public class RootObject
    {
        public string Context { get; set; }
        public Meta Meta { get; set; }
        public List<FloodMonitoringEntities> FloodMonitoringEntities { get; set; }
        public List<Items> Items { get; set; }
    }
}
