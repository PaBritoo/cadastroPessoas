using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroPessoas.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {

        [Key]  //significa que o campo ID é uma chave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //identifica que o campo alem de chave primaria devido ao [Key] ele tambem será auto incremento
        public int Id { get; set; }  //campo int por padrão é obrigatório o preenchimento, caso queira que não seje obrigatório basta colocar "?" em frente a funçao utilizada

        [Required]    //faz com que o campo a ser preenchido seja obrigatorio
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "date")]   //define para utilizar apenas o campo data ao invez de utilizar data/hora
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(1)]    //tamanho do campo a ser preenchido
        public string Sexo { get; set; }

        [Required]
        [StringLength(20)]
        public string EstadoCivil { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(30)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(50)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }


    }
}
