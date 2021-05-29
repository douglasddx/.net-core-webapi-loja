using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace loja.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(10, ErrorMessage = "O atributo {0} deve possuir no mínimo 10 caracteres")]
        [MaxLength(100, ErrorMessage = "O atributo {0} deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [Range(1, 9999, ErrorMessage = "O atributo {0} deve estar entre 1 e 999")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O atributo {0} é obrigatório e deve ser maior que 1")]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }
    }
}