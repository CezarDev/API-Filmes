using System;
using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.DTOs
{
    public class ReadFilmeDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Título do filme é obrigatorio")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Insira o nome do Diretor")]
        public string Diretor { get; set; }
        
        [StringLength(30, ErrorMessage = "Tamanho máximo do é trinta caractéres")]
        public string Genero { get; set; }
        
        [Range(1, 240, ErrorMessage = "Insira a duração de 1 a 240 minutos !")]
        public int Duracao { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}