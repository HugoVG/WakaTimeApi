namespace WakaTimeApi.Models.Common;

public class TimeModel
{
    public int hours { get; set; }
    public int minutes { get; set; }
    public double percent { get; set; }
    public double total_seconds { get; set; }
    
    public TimeSpan? Time => total_seconds != null ? TimeSpan.FromSeconds(total_seconds) : null;
}