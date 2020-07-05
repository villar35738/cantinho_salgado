using System;

namespace CantinhoSalgado_API.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }

        public string ProdutoNome { get; set; }

        public double ProdutoPreco { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}