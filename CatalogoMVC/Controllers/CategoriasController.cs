using CatalogoMVC.Models;
using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

    [HttpGet]
    public async Task<IActionResult> AtualizarCategoria(int id)
    {
        var result = await _categoriaService.GetCategoriaById(id);

        if (result is null) return View("Error");

        return View(result);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaViewModel>> AtualizarCategoria(int id, CategoriaViewModel categoriaVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _categoriaService.UpdateCategoria(id, categoriaVM);

            if (result) return RedirectToAction(nameof(Index));
        }

        ViewBag.Erro = "Erro ao actualizar Categoria";
        return View(categoriaVM);
    }

    [HttpGet]
    public async Task<ActionResult> DeletarCategoria(int id)
    {
        var categoria = await _categoriaService.GetCategoriaById(id);

        if (categoria is null) return View("Error");

        return View(categoria);
    }



}

