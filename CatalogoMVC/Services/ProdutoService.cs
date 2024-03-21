using CatalogoMVC.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CatalogoMVC.Services;

public class ProdutoService : IProdutoService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "api/produtos/";
    private readonly JsonSerializerOptions _options;
    private ProdutoViewModel _produtoVM;
    private IEnumerable<ProdutoViewModel> _produtosVM;

    public ProdutoService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public Task<IEnumerable<ProdutoViewModel>> GetProdutos(string token)
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoViewModel> GetProdutoPorId(int id, string token)
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produtoVM, string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProduto(int id, ProdutoViewModel produtoVM, string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveProduto(int id, string token)
    {
        throw new NotImplementedException();
    }

    private static void PutTokenInHeaderAuthorization(string token, HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
