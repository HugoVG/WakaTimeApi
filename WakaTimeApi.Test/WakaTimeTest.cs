using Refit;
using WakaTimeApi.Models;
using WakaTimeApi.Models.Project;
using WakaTimeApi.Models.Stats;
using WakaTimeApi.Models.Summaries;
using WakaTimeApi.Test.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace WakaTimeApi.Test;

public class WakaTimeTest : TestBed<TestProjectFixture>
{
    public WakaTimeTest(ITestOutputHelper testOutputHelper, TestProjectFixture fixture) : base(testOutputHelper, fixture)
    {
        _apiClient = _fixture.GetService<WakaTimeApiClient>(_testOutputHelper)!;
    }
    
    private readonly WakaTimeApiClient _apiClient;
    
    [Fact]
    public async Task TestGetSummaries()
    {
        ApiResponse<SummariesResponse> result = await _apiClient.GetSummariesResponse();
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.Content);
    }
    
    [Fact]
    public async Task TestGetProjects()
    {
        ApiResponse<ProjectsResponse> result = await _apiClient.GetProjectsResponse();
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.Content);
    }
    
    [Fact]
    public async Task TestGetSingularProject()
    {
        ApiResponse<ProjectsResponse> result = await _apiClient.GetProjectsResponse("WakaTimeApi");
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.Content);
    }
    
    [Fact]
    public async Task TestGetStats()
    {
        ApiResponse<Stats> result = await _apiClient.GetStatsResponse();
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.Content);
        Assert.NotNull(result?.Content?.Statistics?.categories?.FirstOrDefault()?.Time);
    }

    
}