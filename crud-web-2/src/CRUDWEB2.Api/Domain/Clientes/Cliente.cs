using System.ComponentModel.DataAnnotations;
using System;
using SPMigracao.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Domain.Clientes
{
    public class Cliente
    {
         public Guid Id { get; internal set; }
        [Required(ErrorMessage = "Nome não informado")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF não informado")]
         [MaxLength(11, ErrorMessage = "O CPF não pode possuir mais que 11 caracteres")]
        public string Cpf { get; set; }

        public string Telefone { get; set; }

         public string Rua { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

         [IsNotEmpty(ErrorMessage = "Cidade inválida")]
        public Guid CidadeId { get; set; }

        public Cidade Cidade { get; internal set; }
    }
}