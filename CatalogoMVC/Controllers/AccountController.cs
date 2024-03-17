using CatalogoMVC.Models;
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

    [HttpPost]
    public async Task<ActionResult> Login(UsuarioViewModel usuarioViewModel)
    {
        //check if model is valid
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido...");
            return View(usuarioViewModel);
        }

        //check the credentials of user and return some value
        var result = await _autenticacaoService.AutenticaUsuario(usuarioViewModel);

        if(result is null)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido...");
            return View(usuarioViewModel);
        }

        //return token and protectecd inside of coockie
        Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        });

        return Redirect("/");
    }
}
