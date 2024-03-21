using CatalogoMVC.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CatalogoMVC.Services;

public class ProdutoService : IProdutoService
{
    private const string apiEndpoint = "/api/produtos/";

    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;

    private ProdutoViewModel _produtoVM;
    private IEnumerable<ProdutoViewModel> _produtosVM;

    public ProdutoService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProdutoViewModel>> GetProdutos(string token)
    {
        var client = _clientFactory.CreateClient("ProdutosApi");
        PutTokenInHeaderAuthorization(token, client);

        using(var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _produtosVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ProdutoViewModel>>
                    (apiResponse, _options);
            }
            else return null;
        }
        return _produtosVM;
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
