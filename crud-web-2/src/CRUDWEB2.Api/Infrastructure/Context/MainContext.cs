using System;
using CRUDWEB2.Api.Domain.Clientes;
using CRUDWEB2.Api.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPMigracao.Api.Domain.Cidades;

namespace SPMigracao.Api.Infrastructure.Context
{
    public class MainContext : IdentityDbContext
    {
        public virtual DbSet<Cidade> Origins { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CidadeMap());
            builder.ApplyConfiguration(new ClienteMap());
        }

    }
}