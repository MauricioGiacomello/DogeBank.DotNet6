using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class AcessoRequest
    {
        [Required(ErrorMessage = "Email é campo obrigatório para acesso")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no maximo {100} caracteres")]
        public string email { get; set; }
    }
}
