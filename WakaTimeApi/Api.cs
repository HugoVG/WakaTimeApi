using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using WakaTimeApi.Models;
using WakaTimeApi.Models.Common;
using WakaTimeApi.Models.Project;
using WakaTimeApi.Models.Stats;
using WakaTimeApi.Models.Summaries;
using Range = WakaTimeApi.Models.Summaries.Range;

namespace WakaTimeApi;

public interface WakaTimeApiClient
{
    [Get("/users/current/projects")]
    Task<ProjectsResponse> GetProjects();
    
    [Get("/users/current/projects?q={projectName}")]
    Task<ProjectsResponse> GetProjects(string projectName);
    
    [Get("/users/current/projects")]
    Task<ApiResponse<ProjectsResponse>> GetProjectsResponse();
    
    [Get("/users/current/projects?q={projectName}")]
    Task<ApiResponse<ProjectsResponse>> GetProjectsResponse(string projectName);
    
    [Get("/users/current/summaries?range=today")]
    Task<SummariesResponse> GetSummaries();
    
    [Get("/users/current/summaries?range=today")]
    Task<ApiResponse<SummariesResponse>> GetSummariesResponse();
    
    [Get("/users/current/stats/last_7_days")]
    Task<Stats> GetStats();
    
    [Get("/users/current/stats/last_year")]
    Task<ApiResponse<Stats>> GetStatsResponse();
}

public static class WakaTimeServiceProvider
{
    public const string WakaTimeBaseUrl = "https://wakatime.com/api/v1";
    /// <summary>
    /// Adds all necessary services to use the WakaTime API
    /// </summary>
    /// <param name="service">Service collection to append to</param>
    /// <param name="wakaTimeToken">WakaTime token from <a href="https://wakatime.com/settings/api-key">Waka time's website</a></param>
    /// <returns></returns>
    /// <seealso href="https://wakatime.com/settings/api-key"/>
    public static IServiceCollection AddWakaTimeApiClient(this IServiceCollection service, string wakaTimeToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(wakaTimeToken);
        service.AddRefitClient<WakaTimeApiClient>(new RefitSettings()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(WakaTimeSerializer.Default.Options)
        }).ConfigureHttpClient(c=>
        {
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", wakaTimeToken);
            c.BaseAddress = new Uri(WakaTimeBaseUrl);
        });
        return service;
    }

    /// <summary>
    /// Get waka time api client
    /// </summary>
    /// <param name="wakaTimeToken"></param>
    /// <param name="client"></param>
    /// <returns></returns>
    public static WakaTimeApiClient GetWakaTimeApiClient(string wakaTimeToken, HttpClient? client = null)
    {
        client ??= new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", wakaTimeToken);
        client.BaseAddress = new Uri(WakaTimeBaseUrl);
        
        var wakaTimeApi = RestService.For<WakaTimeApiClient>(client, new RefitSettings()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(WakaTimeSerializer.Default.Options)
        });
        return wakaTimeApi;
    }
    
}
[JsonSerializable(typeof(ProjectsResponse))]    
[JsonSerializable(typeof(SummariesResponse))]    
[JsonSerializable(typeof(Summaries))]    
[JsonSerializable(typeof(Cumulative_total))]    
[JsonSerializable(typeof(Daily_average))]    
[JsonSerializable(typeof(Range))]    
[JsonSerializable(typeof(Projects))]
[JsonSerializable(typeof(SummariesResponse))]    
[JsonSerializable(typeof(TimeModel))]    
[JsonSerializable(typeof(Badge))]    
[JsonSerializable(typeof(Snippets))]    
[JsonSerializable(typeof(Stats))]    
public partial class WakaTimeSerializer : JsonSerializerContext
{
}