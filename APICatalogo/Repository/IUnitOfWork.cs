namespace APICatalogo.Repository
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepsitory CategoriaRepsitory { get; }
        void Commit();
    }
}
