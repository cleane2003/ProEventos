using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set;}
        public string DataEvento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "{0} Deve ter no mínimo 4 caracteres.")]
        [MaxLength(50, ErrorMessage = "{0} Deve ter no máximo 50 caracteres.")]
        public string Tema { get; set; }

        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000.")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} precisa ser válido.")]
        public string Email { get; set; }

        public IEnumerable<LoteDto> LoteDto { get; set; }
        public IEnumerable<RedeSocialDto> RedeSocialDto { get; set; }
        public IEnumerable<PalestranteDto> PalestranteDto { get; set; }
    }
}