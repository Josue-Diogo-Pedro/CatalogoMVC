using System.ComponentModel.DataAnnotations;

namespace CatalogoMVC.Models;

public class CategoriasMvc
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obirgatório")]
    public string Nome { get; set; }

    [Required]
    [Display(Name = "Imagem")]
    public string ImagemUrl { get; set; }
}
