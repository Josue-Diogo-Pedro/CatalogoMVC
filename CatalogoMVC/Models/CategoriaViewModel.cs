using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CatalogoMVC.Models;

public class CategoriaViewModel
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obirgatório")]
    public string Nome { get; set; }

    [Required]
    [Display(Name = "Imagem")]
    public string ImagemUrl { get; set; }
}
