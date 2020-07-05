using System.ComponentModel.DataAnnotations;

namespace CantinhoSalgado_API.Models
{
    public class Estoque
    {
        [Key]
        public int EstoqueID { get; set; }

        public string ProdutoNome { get; set; }

        public int QtdEstoque { get; set; }

        public Produto Produto { get; set; }
    }
}