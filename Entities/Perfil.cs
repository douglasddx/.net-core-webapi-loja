using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loja.Entities
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O atributo {0} deve possuir no mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O atributo {0} deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuario { get; set; }
    }
}