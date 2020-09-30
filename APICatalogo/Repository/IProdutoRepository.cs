using ApiCatalogo.Pagination;
using APICatalogo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutos(ProdutosParamenters produtosParamenters);
        Task<IEnumerable<Produto>> GetProdutosPorPreco();
    }
}
