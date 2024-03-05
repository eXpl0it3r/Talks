using Clockify.Net;

var client = new ClockifyClient("MyApiKey", "http://localhost:3002/api/v1");

var workspaces = await client.GetWorkspacesAsync();
if (!workspaces.IsSuccessful || workspaces.Data == null)
{
    Console.WriteLine($"ERROR: Unable to retrieve Workspaces: {workspaces.ErrorMessage}");
    return;
}
const string clientName = "MyClient";
var workspaceId = workspaces.Data?.SingleOrDefault(w => w.Name == clientName)?.Id;

if (workspaceId is null)
{
    Console.WriteLine($"ERROR: Workspace '{clientName}' could not be found");
    return;
}

Console.WriteLine($"Workspace ID: {workspaceId}");