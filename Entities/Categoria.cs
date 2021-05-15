using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loja.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O tamanho mínino do atributo {0} é 3")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do atributo {0} é 50")]
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}