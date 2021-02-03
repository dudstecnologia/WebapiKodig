
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebapiKodig.Domain.Models
{
    public class Produto
    {
        [Key]
        [MaxLength(20, ErrorMessage = "O Campo código suporta apenas {1} caracteres")]
        public string CODIGO { get; set; }

        [MaxLength(2, ErrorMessage = "O Campo tipo suporta apenas {1} caracteres")]
        public string TIPO { get; set; }

        [MaxLength(2, ErrorMessage = "O Campo unidade de medida suporta apenas {1} caracteres")]
        public string UM { get; set; }

        [MaxLength(50, ErrorMessage = "O Campo descrição suporta apenas {1} caracteres")]
        public string DESCRICAO { get; set; }
    }
}