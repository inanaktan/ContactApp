using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactApp.Report.Domain.Abstractions;

public interface IDocument
{
    [BsonId]
    Guid Id { get; set; }

    DateTime CreatedOn { get; }
}
