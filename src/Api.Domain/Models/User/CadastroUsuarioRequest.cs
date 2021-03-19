namespace Api.Domain.Models
{
    public class CadastroUsuarioRequest
    {
        public string name { get; set; }
        public string nameMother { get; set; }
        public string nameFather { get; set; }
        public string email { get; set; }
        public string userMF { get; set; }
    }
}
