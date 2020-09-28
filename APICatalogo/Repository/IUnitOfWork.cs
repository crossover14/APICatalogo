namespace APICatalogo.Repository
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepsitory CategoriaRepository { get; }
        void Commit();
    }
}
