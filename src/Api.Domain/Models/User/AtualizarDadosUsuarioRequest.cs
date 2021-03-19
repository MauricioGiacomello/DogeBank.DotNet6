namespace Api.Domain.Models.User
{
    public class AtualizarDadosUsuarioRequest
    {
        public string name { get; set; }
        public string nameMother { get; set; }
        public string nameFather { get; set; }
        public string email { get; set; }
        public string userMf { get; set; }
        public string odlUserMf { get; set; }
    }
}
