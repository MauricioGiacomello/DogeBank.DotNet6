
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DOB.ApiDotNet6.Domain.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string? Nome { get; set; }

        [BsonElement("sobrenome")]
        public string? Sobrenome { get; set; }  

        [BsonElement("rg")]
        public string? Rg { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }
    }
}
