using System;

namespace Api.Domain.Models.User
{
    public class CadastroUsuarioResult
    {
        public string name { get; set; }
        public string nameMother { get; set; }
        public string nameFather { get; set; }
        public string email { get; set; }
        public string userMF { get; set; }
        public DateTime creatAt { get; set; }
    }
}
