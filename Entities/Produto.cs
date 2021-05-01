using System.ComponentModel.DataAnnotations;

namespace loja.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(10, ErrorMessage = "O tamanho mínino do atributo {0} é 3")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do atributo {0} é 50")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [Range(1, 999, ErrorMessage = "O atributo {0} deve estar entre 1 e 999")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O atributo {0} é obrigatório e deve ser maior que 1")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}