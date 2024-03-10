using CatalogoMVC.Models;

namespace CatalogoMVC.Services;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaViewModel>> GetCategorias();
    Task<CategoriaViewModel> GetCategoriaById(int id);
    Task<CategoriaViewModel> CreateCategoria(CategoriaViewModel categoriaVM);
    Task<bool> UpdateCategoria(int id, CategoriaViewModel categoriaVM);
    Task<bool> RemoveCategoria(int id);
}
