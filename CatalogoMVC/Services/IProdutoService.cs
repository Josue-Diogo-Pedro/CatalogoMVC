using CatalogoMVC.Models;

namespace CatalogoMVC.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoViewModel>> GetProdutos(string token);
    Task<ProdutoViewModel> GetProdutoPorId(int id, string token);
    Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produtoVM, string token);
    Task<bool> UpdateProduto(int id, ProdutoViewModel produtoVM, string token);
    Task<bool> RemoveProduto(int id, string token);
}
