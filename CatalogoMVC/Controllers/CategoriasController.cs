using CatalogoMVC.Models;
using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoMVC.Controllers;

public class CategoriasController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService) => _categoriaService = categoriaService;

    public async Task<ActionResult<IEnumerable<CategoriaViewModel>>> Index()
    {
        var result = await _categoriaService.GetCategorias();

        if (result is null) return View("Error");

        return View(result);
    }

    [HttpGet]
    public IActionResult CriarNovaCategoria()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaViewModel>> CriarNovaCategoria(CategoriaViewModel categoriaVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _categoriaService.CreateCategoria(categoriaVM);
            if (result is not null) return RedirectToAction(nameof(Index));
        }

        ViewBag.Erro = "Erro ao criar categoria";

        return View(categoriaVM);
    }
}

