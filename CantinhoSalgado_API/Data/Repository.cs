using System.Linq;
using System.Threading.Tasks;
using CantinhoSalgado_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CantinhoSalgado_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //PRODUTOS
        public async Task<Produto[]> GetAllProdutos()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query
                        .AsNoTracking()
                        .OrderBy(p => p.ProdutoNome);

            return await query.ToArrayAsync();

        }

        public async Task<Produto> GetProdutoByID(int ProdutoID)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().Where(p => p.ProdutoID == ProdutoID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Estoque[]> GetAllEstoque(bool OnlyWithEstoque)
        {
            IQueryable<Estoque> query = _context.Estoque;

            if (OnlyWithEstoque)
            {
                query = query.Where(e => e.QtdEstoque > 0);
            }
            query = query.AsNoTracking().OrderBy(e => e.ProdutoNome);

            return await query.ToArrayAsync();
        }

        public void AddProdutoNoEstoque(Produto produto)
        {
            Estoque estoque = new Estoque();

            estoque.ProdutoNome = produto.ProdutoNome;
            estoque.Produto = produto;

            _context.Add(estoque);
        }

        public async Task<Estoque> GetEstoqueByID(int EstoqueID)
        {
            IQueryable<Estoque> query = _context.Estoque;

            query = query.AsNoTracking().Where(e => e.EstoqueID == EstoqueID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Estoque> GetEstoqueByProduct(Produto produto)
        {
            IQueryable<Estoque> query = _context.Estoque;

            query = query.AsNoTracking().Where(e => e.Produto == produto);

            return await query.FirstOrDefaultAsync();
        }

    }
}