using System.ComponentModel.DataAnnotations;

namespace loja.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(10, ErrorMessage = "O atributo {0} deve possuir no mínimo 10 caracteres")]
        [MaxLength(50, ErrorMessage = "O atributo {0} deve possuir no máximo 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(10, ErrorMessage = "O atributo {0} deve possuir no mínimo 10 caracteres")]
        [MaxLength(50, ErrorMessage = "O atributo {0} deve possuir no máximo 50 caracteres")]
        public int Nome { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        [MinLength(8, ErrorMessage = "O atributo {0} deve possuir no mínimo 8 caracteres")]
        [MaxLength(8, ErrorMessage = "O atributo {0} deve possuir no máximo 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O atributo {0} é obrigatório")]
        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }
    }
}