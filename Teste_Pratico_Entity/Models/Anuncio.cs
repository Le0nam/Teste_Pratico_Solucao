using System.ComponentModel.DataAnnotations;

namespace Teste_Pratico_Entity.Models
{
    public class Anuncio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataPublicacao { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Valor { get; set; }

        [Required]
        public string Cidade { get; set; }

        public string TipoAnuncio { get; set; } // Produto ou Serviço
    }

}
