using CatalogoMVC.Models;
using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogoMVC.Controllers;

public class ProdutosController : Controller
{
    private readonly ICategoriaService _categoriaService;
    private readonly IProdutoService _produtoService;
    private string token = string.Empty;

    public ProdutosController(ICategoriaService categoriaService, IProdutoService produtoService)
    {
        _categoriaService = categoriaService;
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
    {
        var result = await _produtoService.GetProdutos(ObtemToken());

        if (result is null) return View("Error");
        else return View(result);
    }

    [HttpGet]
    public async Task<ActionResult> CriarNovoProduto()
    {
        var categorias = await _categoriaService.GetCategorias();
        ViewBag.CategoriaId = new SelectList(categorias, "CategoriaId", "Nome");

        return View();
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoViewModel>> CriarNovoProduto(ProdutoViewModel produtoVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _produtoService.CreateProduto(produtoVM, ObtemToken());

            if (result is not null) return RedirectToAction(nameof(Index));

        }
        else ViewBag.CategoriaId = new SelectList(await _categoriaService.GetCategorias(), "CategoriaId", "Nome");

        return View(produtoVM);
    }

    [HttpGet]
    public async Task<ActionResult<ProdutoViewModel>> DetalhesProduto(int id)
    {
        var produto = await _produtoService.GetProdutoPorId(id, ObtemToken());

        if (produto is null) return View("Error");

        return View(produto);
    }

    [HttpGet]
    public async Task<ActionResult<ProdutoViewModel>> AtualizarProduto(int id)
    {
        var produto = await _produtoService.GetProdutoPorId(id, ObtemToken());

        if (produto is null) return View("Error");

        ViewBag.CategoriaId = new SelectList(await _categoriaService.GetCategorias(), "CategoriaId", "Nome");

        return View(produto);
    }

    [HttpPost]
    public async Task<ActionResult> AtualizarProduto(int id, ProdutoViewModel produtoVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _produtoService.UpdateProduto(id, produtoVM, ObtemToken());

            if (result) return RedirectToAction(nameof(Index));
        }

        return View("Error");
    }

    [HttpGet]
    public async Task<ActionResult<ProdutoViewModel>> DeletarProduto(int id)
    {
        var produto = await _produtoService.GetProdutoPorId(id, ObtemToken());

        if (produto is null) return View("Error");
        else return View(produto);
    }

    [HttpPost(), ActionName("DeletarProduto")]
    public async Task<ActionResult> DeletaConfirmado(int id)
    {
        var result = await _produtoService.RemoveProduto(id, ObtemToken());

        if (result) return RedirectToAction(nameof(Index));
        else return View("Error");
    }

    private string ObtemToken()
    {
        if (HttpContext.Request.Cookies.ContainsKey("X-Access-Token"))
            token = HttpContext.Request.Cookies["X-Access-Token"].ToString();

        return token;
    }
}
