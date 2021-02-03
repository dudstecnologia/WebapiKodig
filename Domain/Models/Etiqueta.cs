using System.ComponentModel.DataAnnotations;

namespace WebapiKodig.Domain.Models
{
    public class Etiqueta
    {
        [Key]
        [MaxLength(15, ErrorMessage = "O Campo código suporta apenas {1} caracteres")]
        public string CODIGO { get; set; }

        [MaxLength(20, ErrorMessage = "O Campo código do produto suporta apenas {1} caracteres")]
        public string PRODUTO { get; set; }

        public decimal QUANTIDADE { get; set; }

        public decimal SALDO { get; set; }
    }
}