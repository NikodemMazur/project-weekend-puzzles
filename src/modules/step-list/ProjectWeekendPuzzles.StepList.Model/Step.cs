using System;

namespace ProjectWeekendPuzzles.StepList.Model
{
    public record Step
    {
        public Step(string name, string result, StepStatus status)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Result = result ?? throw new ArgumentNullException(nameof(result));
            Status = status;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Result { get; }
        public StepStatus Status { get; }

        public enum StepStatus
        {
            Pass,
            Fail,
            Error
        };
    }
}
