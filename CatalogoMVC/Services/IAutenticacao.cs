using CatalogoMVC.Models;

namespace CatalogoMVC.Services;

public interface IAutenticacao
{
    Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM);
}
