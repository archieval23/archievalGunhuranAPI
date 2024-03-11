namespace FlexisourceIT_API.Model
{
    public class FloodMonitoring
    {
        public string Id { get; set; }
        public int Easting { get; set; }
        public string GridReference { get; set; }
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public List<Measure> Measures { get; set; }
        public int Northing { get; set; }
        public string Notation { get; set; }
        public string StationReference { get; set; }
    }
    public class Measure
    {
        public string Id { get; set; }
        public string Parameter { get; set; }
        public string ParameterName { get; set; }
        public int Period { get; set; }
        public string Qualifier { get; set; }
        public string UnitName { get; set; }
    }
}
