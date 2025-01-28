using System.ComponentModel.DataAnnotations;

namespace Teste_Pratico_Entity
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome do anúncio deve ter pelo menos 5 caracet")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória.")]
        public DateTime DataPublicacao { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a R$ 1,00.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Selecione uma cidade válida.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria válida.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Selecione um modelo válido.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Selecione uma condição válida para o produto.")]
        public string Condicao { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1 unidade.")]
        public int Quantidade { get; set; }
    }

}
