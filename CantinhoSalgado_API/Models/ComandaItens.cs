using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CantinhoSalgado_API.Models
{
    public class ComandaItens
    {
        [Key]
        public int ComandaID { get; set; }

        public int ProdutoID { get; set; }

        public int ProdutoNome { get; set; }

        public int ProdutoQtd { get; set; }

        public Comanda Comanda { get; set; }
    }
}