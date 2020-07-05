using System;
using System.Collections.Generic;

namespace CantinhoSalgado_API.Models
{
    public class Comanda
    {
        public int ComandaID { get; set; }

        public string NomeCliente { get; set; }

        public bool Encomenda { get; set; }

        public DateTime DataEncomenda { get; set; }

        public string TelefoneCliente { get; set; }

        public List<ComandaItens> Itens { get; set; }
    }
}