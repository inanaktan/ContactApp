using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactApp.Report.Domain.Abstractions;

public class Document : IDocument
{
    public Guid Id { get; set; }

    public DateTime CreatedOn => DateTime.Now;
}
