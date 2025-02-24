using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleBudgetTracker.Data.Entities.Interfaces;
using System;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleBudgetTracker.Data.Entities;

public class User: IAudit
{
    public required int Id { get; private set; }

    public required Guid Guid { get; private set; }
    
    public string UserName { get; private set; }

    public string Email { get; private set; } = default!;

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required DateTime CreatedOn { get; private set; }

    public required int CreatedById { get; private set; }

    public DateTime? UpdatedOn { get; private set; }

    public int? UpdatedById { get; private set; }

    public required bool IsActive { get; private set; }

    public virtual User CreatedBy { get; private set; }

    public virtual User UpdatedBy { get; private set; }

    public static User Create(
        string userName,
        string firstName,
        string lastName,
        int createdById,
        int updatedById)
    {
        return new User
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            CreatedById = createdById,
            UpdatedById = updatedById,
        };
    }


    public void Update(
        string username,
        string firstName,
        string lastName,
        int updatedById)
    {
        UserName = username;
        FirstName = firstName;
        LastName = lastName;
        UpdatedById = updatedById;
    }

    public void Inactivate(string updatedByID)
    {
        IsActive = false;
    }
}
