namespace DemoChart.Models
{
    public class ChartViewModel
    {
        public string ChartType { get; set; } = "bar";
        public string Labels { get; set; } = "";
        public string DataValues { get; set; } = "";
        public string ChartTitle { get; set; } = "My Chart";
        public bool ShowLegend { get; set; } = true;
        public string BackgroundColor { get; set; } = "";
        public string BorderColor { get; set; } = "";
    }

    public class  SavedChartModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ChartType { get; set; } = "";
        public string Labels { get; set; } = "";
        public string DataValues { get; set; } = "";
        public string ChartTitle { get; set; } = "";
        public bool ShowLegend { get; set; } = true;
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
