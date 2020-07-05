using System;
using System.Collections.Generic;
using CantinhoSalgado_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CantinhoSalgado_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Comanda> Comandas { get; set; }

        public DbSet<ComandaItens> ComandaItens { get; set; }

        public DbSet<Estoque> Estoque { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Produto>()
            //     .HasData(
            //         new List<Produto>(){
            //             new Produto(){
            //                 ProdutoID = 1,
            //                 ProdutoNome = "Coxinha de frango",
            //                 ProdutoPreco = 1.0,
            //                 DataCadastro = DateTime.Now.Date
            //             },
            //             new Produto(){
            //                 ProdutoID = 2,
            //                 ProdutoNome = "Salsicha empanada",
            //                 ProdutoPreco = 1.0,
            //                 DataCadastro = DateTime.Now.Date
            //             }
            //     }
            // );
        }
    }
}