using ApiCatalogo.Repository;
using APICatalogo.Models;
using System.Collections.Generic;

namespace APICatalogo.Repository
{
    public interface ICategoriaRepsitory : IRepository<Categoria>
    {

        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
