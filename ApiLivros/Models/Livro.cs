using System.ComponentModel.DataAnnotations;

namespace ApiLivros.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string? Autor { get; set; }

        [Required]
        [StringLength(500)]
        public string? Descricao { get; set; }
    }
}
