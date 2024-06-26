using Refit;
using WakaTimeApi;
using WakaTimeApi.Models.Project;

Console.WriteLine("Hello, World!");

var token = Environment.GetEnvironmentVariable("WakaTimeToken", EnvironmentVariableTarget.User);
WakaTimeApiClient api = WakaTimeServiceProvider.GetWakaTimeApiClient(token);

ApiResponse<ProjectsResponse>? projects = await api.GetProjectsResponse();

if (projects?.Content?.projects == null)
{
    Console.WriteLine("No projects found");
    return;
}

foreach (var project in projects.Content.projects)
{
    Console.WriteLine(project.name);
}