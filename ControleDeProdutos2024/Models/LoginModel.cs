using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos2024.Models
{
    public class LoginModel
    {
        public Int64 Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Favor inserir seu nome de usuário!!!")]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
        public int NivelAcesso { get; set; }
        public int Ativo { get; set; }
        public bool? EmailConfirmacao { get; set; }
        public bool? TelefoneConfirmacao { get; set; }
        public DateTime DataDeRegistro { get; set; }
    }
}
