using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace workiomAPI.Models;

public class Contact {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;

    [BsonElement("companyIds")]
    [JsonPropertyName("companyIds")]
    public List<string> CompanyIds { get; set; } = null!;
}

