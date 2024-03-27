using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace TheDerpening.Data
{
    public static class DerpingMonitor
    {
        public static int DerpCounter { get; set; } = 2;
        public static int TaskCounter { get; set; }
        public static int FunPageViews { get; set; } = 0;
        public static Meter meter = new("derpmetrics");
        public static string DerpString = "I am a derp trace";
        public static ActivitySource source = new ActivitySource(DerpString, "1.0.0");
        public static Counter<int> countAdd = meter.CreateCounter<int>("derpcount", description: "Counts times hit");
        public static UpDownCounter<int> upDownCounter = meter.CreateUpDownCounter<int>("Derptasks", unit: "tasks", description: "Tasks in total");
        public static ObservableCounter<int> observableCounter = meter.CreateObservableCounter<int>("apiviews", () => DerpCounter, unit: "views", "Api views?");
        public static ObservableUpDownCounter<int> observableUpDownCounter = meter.CreateObservableUpDownCounter<int>("FunPageViews", () => FunPageViews, unit: "A different page view", "A page view");
        public static ObservableGauge<int> observableGauge = meter.CreateObservableGauge<int>("TaskHistory", () => TaskCounter, unit: "tasks", description: "History of tasks");
        public static Histogram<int> histogram = meter.CreateHistogram<int>("HistoryDerping", unit: "tasks", "A histogram of things");

    }
}
