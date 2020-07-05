using System.Threading.Tasks;
using CantinhoSalgado_API.Models;

namespace CantinhoSalgado_API.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //PRODUTO
        Task<Produto[]> GetAllProdutos();

        Task<Produto> GetProdutoByID(int ProdutoID);

        //ESTOQUE
        Task<Estoque[]> GetAllEstoque(bool OnlyWithEstoque);

        Task<Estoque> GetEstoqueByID(int EstoqueID);

        Task<Estoque> GetEstoqueByProduct(Produto produto);

        void AddProdutoNoEstoque(Produto produto);

    };
}