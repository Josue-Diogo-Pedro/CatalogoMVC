using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Index()
    {
        return View();
    }

    private string ObtemToken()
    {
        if (HttpContext.Request.Cookies.ContainsKey("X-Access-Token"))
            token = HttpContext.Request.Cookies["X-Access-Token"].ToString();

        return token;
    }
}
