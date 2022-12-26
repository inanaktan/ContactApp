namespace ContactApp.Contact.Domain.Abstractions;

public interface IEntity<TId>
{
    public TId Id { get; set; }
}
