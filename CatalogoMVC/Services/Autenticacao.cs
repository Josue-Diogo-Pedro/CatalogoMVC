using CatalogoMVC.Models;

namespace CatalogoMVC.Services;

public class Autenticacao : IAutenticacao
{
    public Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM)
    {
        throw new NotImplementedException();
    }
}
