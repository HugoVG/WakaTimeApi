using WakaTimeApi.Models.Common;

namespace WakaTimeApi.Models.Stats;

public class Stats
{
    
    [JsonPropertyName("data")]
    public Statistics? Statistics { get; set; }    
    public static implicit operator Statistics?(Stats d) => d.Statistics;
}

public class Statistics
{
    public Best_day? best_day { get; set; }
    public TimeModel[]? categories { get; set; }
    public string created_at { get; set; }
    public double daily_average { get; set; }
    public double daily_average_including_other_language { get; set; }
    public int days_including_holidays { get; set; }
    public int days_minus_holidays { get; set; }
    public TimeModel[]? dependencies { get; set; }
    public TimeModel[]? editors { get; set; }
    public string end { get; set; }
    public int holidays { get; set; }
    public string human_readable_daily_average { get; set; }
    public string human_readable_daily_average_including_other_language { get; set; }
    public string human_readable_range { get; set; }
    public string human_readable_total { get; set; }
    public string human_readable_total_including_other_language { get; set; }
    public string id { get; set; }
    public bool is_already_updating { get; set; }
    public bool is_cached { get; set; }
    public bool is_coding_activity_visible { get; set; }
    public bool is_including_today { get; set; }
    public bool is_other_usage_visible { get; set; }
    public bool is_stuck { get; set; }
    public bool is_up_to_date { get; set; }
    public bool is_up_to_date_pending_future { get; set; }
    public TimeModel[]? languages { get; set; }
    public TimeModel[]? machines { get; set; }
    public string modified_at { get; set; }
    public TimeModel[]? operating_systems { get; set; }
    public int percent_calculated { get; set; }
    public TimeModel[]? projects { get; set; }
    public string range { get; set; }
    public string start { get; set; }
    public string status { get; set; }
    public int timeout { get; set; }
    public string timezone { get; set; }
    public double total_seconds { get; set; }
    public double total_seconds_including_other_language { get; set; }
    public string user_id { get; set; }
    public string username { get; set; }
    public bool writes_only { get; set; }
}

public class Best_day
{
    public string date { get; set; }
    public string text { get; set; }
    public double total_seconds { get; set; }
    
    public TimeSpan? Time => TimeSpan.FromSeconds(total_seconds);
}


