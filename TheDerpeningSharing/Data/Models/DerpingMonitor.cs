using System.Diagnostics;
using System.Diagnostics.Metrics;

public static class DerpingMonitor
{

    public static Meter meter = new("derpmetrics");
    public static string DerpString = "I am a derp trace";
    public static ActivitySource source = new ActivitySource(DerpString, "1.0.0");
    public static Counter<int> countAdd = meter.CreateCounter<int>("derpcount", description: "Counts times hit");
}
