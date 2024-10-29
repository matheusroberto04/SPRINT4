using System.ComponentModel.DataAnnotations;

namespace TargetCustomer.Models
{
    public class Consultoria
    {
        [Key]
        public int ConsultoriaId { get; set; }
        public string NomeConsultoria { get; set; } = string.Empty;
    }
}
