namespace SimpleBudgetTracker.Data.Entities.Interfaces;

public interface IAudit
{
    int CreatedById { get; set; }

    DateTime CreatedOn { get; set; }

    int UpdatedById { get;  set; }

    DateTime UpdatedOn { get; set; }

    User CreatedBy { get; set; }

    User UpdatedBy { get; set; }
}
