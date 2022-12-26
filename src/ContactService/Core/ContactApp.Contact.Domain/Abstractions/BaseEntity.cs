namespace ContactApp.Contact.Domain.Abstractions;

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; } = false;
}
