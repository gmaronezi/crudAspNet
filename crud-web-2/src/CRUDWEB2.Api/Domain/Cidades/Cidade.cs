using System.ComponentModel.DataAnnotations;
using System;

namespace SPMigracao.Api.Domain.Cidades

{
    public class Cidade
    {
         public Guid Id { get; internal set; }
        [Required(ErrorMessage = "Nome não informado")]
        public string Nome { get; set; }
        public string Uf { get; set; }
    }
}