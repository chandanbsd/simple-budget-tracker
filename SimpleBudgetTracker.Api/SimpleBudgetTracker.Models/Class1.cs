namespace SimpleBudgetTracker.Models
{
    public class UserModel
    {
        public int Id { get; private set; }

        public Guid Guid { get; private set; }

        public string UserName { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public DateTime CreatedOn { get; private set; }

        public int CreatedById { get; private set; }

        public DateTime? UpdatedOn { get; private set; }

        public int? UpdatedById { get; private set; }

        public bool IsActive { get; private set; }
    }
}
