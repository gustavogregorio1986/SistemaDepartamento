using System;
using System.ComponentModel.DataAnnotations;

namespace DepartamentoPessoal.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Email invallido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o Rg")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Informe A Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Pai")]
        public string NomePai { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Mãe")]
        public string NomeMae { get; set; }
    }
}
