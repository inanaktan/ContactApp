namespace ContactApp.Contact.Domain.Abstractions;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;
}
