using WakaTimeApi.Models.Common;

namespace WakaTimeApi.Models.Summaries;


public class SummariesResponse
{
    public Summaries[] data { get; set; }
    public string start { get; set; }
    public string end { get; set; }
    public Cumulative_total cumulative_total { get; set; }
    public Daily_average daily_average { get; set; }
}

public class Summaries
{
    public Range range { get; set; }
    public TimeModel grand_total { get; set; }
    public TimeModel[] projects { get; set; }
    public TimeModel[] languages { get; set; }
    public TimeModel[] dependencies { get; set; }
    public TimeModel[] machines { get; set; }
    public TimeModel[] editors { get; set; }
    public TimeModel[] operating_systems { get; set; }
    public TimeModel[] categories { get; set; }
}


public class Range
{
    public string start { get; set; }
    public string end { get; set; }
    public string date { get; set; }
    public string text { get; set; }
    public string timezone { get; set; }
}


public class Cumulative_total
{
    public double seconds { get; set; }
    public string text { get; set; }
    public string digital { get; set; }
    public string @decimal { get; set; }
    
    public TimeSpan? Time => TimeSpan.FromSeconds(seconds);
}

public class Daily_average
{
    public int holidays { get; set; }
    public int days_minus_holidays { get; set; }
    public int days_including_holidays { get; set; }
    public int seconds { get; set; }
    public int seconds_including_other_language { get; set; }
    public string text { get; set; }
    public string text_including_other_language { get; set; }
    
    public TimeSpan? Time => TimeSpan.FromSeconds(seconds);
}

