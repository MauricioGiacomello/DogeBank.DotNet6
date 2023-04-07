using MongoDB.Bson.Serialization.Attributes;

namespace DOB.ApiDotNet6.Api.Models.ViewModels
{
    public class UsuarioViewModel
    {
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
