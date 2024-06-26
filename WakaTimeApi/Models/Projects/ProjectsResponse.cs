namespace WakaTimeApi.Models.Project;

public class ProjectsResponse
{
    [JsonPropertyName("data")]
    public List<Projects> projects { get; set; }
}
public class Projects
{
    public Badge badge { get; set; }
    public object color { get; set; } // TODO: Figure this out
    public string created_at { get; set; }
    public string first_heartbeat_at { get; set; }
    public bool has_public_url { get; set; }
    public string human_readable_first_heartbeat_at { get; set; }
    public string human_readable_last_heartbeat_at { get; set; }
    public string id { get; set; }
    public string last_heartbeat_at { get; set; }
    public string name { get; set; }
    public string repository { get; set; }
    public string url { get; set; }
    public string urlencoded_name { get; set; }
}

public class Badge
{
    public string color { get; set; }
    public string created_at { get; set; }
    public string id { get; set; }
    public string left_text { get; set; }
    public string link { get; set; }
    public string project_id { get; set; }
    public List<Snippets> snippets { get; set; }
    public string title { get; set; }
    public string url { get; set; }
}

public class Snippets
{
    public string content { get; set; }
    public string name { get; set; }
}