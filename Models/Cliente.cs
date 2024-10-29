using System.ComponentModel.DataAnnotations;

namespace TargetCustomer.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string RamodeAtuacao { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public int Senha { get; set; }
    }
}
