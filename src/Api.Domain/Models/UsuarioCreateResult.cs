using System;

namespace Api.Domain.Models
{
    public class UsuarioCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string userMf { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
