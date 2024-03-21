using CatalogoMVC.Models;
using System.Text.Json;

namespace CatalogoMVC.Services;

public class ProdutoService
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


}
