namespace SimpleBudgetTracker.Models.InputModels
{
    public class UserModel
    {
        public required string UserName { get; init; }

        public string? Email { get; init; }

        public required string FirstName { get; init; }

        public required string LastName { get; init; }
    }
}
