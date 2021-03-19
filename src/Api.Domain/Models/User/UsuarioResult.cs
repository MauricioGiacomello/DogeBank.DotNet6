using System;

namespace Api.Domain.Models
{
    public class UsuarioResult
    {

        public string name { get; set; }
        public string nameMother { get; set; }
        public string nameFather { get; set; }
        public string email { get; set; }
        public string userMf { get; set; }
        public DateTime creatAt { get; set; }
    }
}
