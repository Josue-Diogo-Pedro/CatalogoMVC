using System.ComponentModel.DataAnnotations;

namespace CatalogoMVC.Models;

public class ProdutoViewModel
{
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O nome do Produto é obrigatório")]    
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição do Produto é obrigatória")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Informe o preço do Produto")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Informe o caminho da imagem do Produto")]
    [Display(Name = "Caminho da Imagem")]
    public string ImagemUrl { get; set; }

    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }
}
