<Query Kind="Program">
  <Reference Relative="..\..\..\src\clients\dashboard-client\ProjectWeekendPuzzles.Dashboard.Client\bin\Debug\ProjectWeekendPuzzles.Dashboard.Client.dll">C:\Repos\project-weekend-puzzles\src\clients\dashboard-client\ProjectWeekendPuzzles.Dashboard.Client\bin\Debug\ProjectWeekendPuzzles.Dashboard.Client.dll</Reference>
  <Namespace>ProjectWeekendPuzzles.Dashboard.Client</Namespace>
</Query>

void Main()
{
	using (var statusUpdaterClient = new StatusUpdaterClient())
	{
		statusUpdaterClient.UpdateStatus(11, 22, 33);
	}
}

// Define other methods and classes here
