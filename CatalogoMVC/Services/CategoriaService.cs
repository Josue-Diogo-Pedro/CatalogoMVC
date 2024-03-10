using CatalogoMVC.Models;
using System.Text.Json;

namespace CatalogoMVC.Services;

public class CategoriaService : ICategoriaService
{
    private const string apiEndpoint = "/api/categorias";

    private readonly JsonSerializerOptions _options;
    private readonly IHttpClientFactory _clientFactory;

    private CategoriaViewModel categoriaVM;
    private IEnumerable<CategoriaViewModel> categoriasVM;

    public CategoriaService(IHttpClientFactory clientFactory)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<CategoriaViewModel>> GetCategorias()
    {
        throw new NotImplementedException();
    }

    public async Task<CategoriaViewModel> GetCategoriaById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoriaViewModel> CreateCategoria(CategoriaViewModel categoriaVM)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCategoria(int id, CategoriaViewModel categoriaVM)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveCategoria(int id)
    {
        throw new NotImplementedException();
    }

}
