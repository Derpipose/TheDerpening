using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace TheDerpening.Data
{
    public static class DerpingMonitor
    {
        public static int MyCountToTrack { get; set; } = 2;
        public static Meter meter = new("derpmetrics");
        public static string DerpString = "I am a derp trace";
        public static ActivitySource source = new ActivitySource(DerpString, "1.0.0");
        public static Counter<int> countAdd = meter.CreateCounter<int>("derpcount", description: "Counts times hit");
    }
}
