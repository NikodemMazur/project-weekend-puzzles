<Query Kind="Program">
  <Reference Relative="..\..\..\src\modules\step-list\ProjectWeekendPuzzles.StepList.Client\bin\Debug\ProjectWeekendPuzzles.StepList.Client.dll">C:\Repos\project-weekend-puzzles\src\modules\step-list\ProjectWeekendPuzzles.StepList.Client\bin\Debug\ProjectWeekendPuzzles.StepList.Client.dll</Reference>
  <Namespace>ProjectWeekendPuzzles.StepList.Client</Namespace>
</Query>

async void Main()
{
	using (var stepListUpdaterClient = new StepListUpdaterClient())
	{
		for (int i = 0; i < 16; i++)
		{
			var rng = new Random();
			var result = rng.NextDouble() * 5;
			var status = (StepListUpdaterClient.StepStatus)(rng.Next() % 3);
			stepListUpdaterClient.AddStepAsync($"Step {i}", result.ToString("F1"), status).Wait();
			Thread.Sleep(400);
		}
		
		await stepListUpdaterClient.ClearAsync();
	}
}
