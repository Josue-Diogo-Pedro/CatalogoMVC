using CatalogoMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoMVC.Controllers;

public class AccountController : Controller
{
    private readonly IAutenticacao _autenticacaoService;

	public AccountController(IAutenticacao autenticacaoService) => _autenticacaoService = autenticacaoService;

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


}
