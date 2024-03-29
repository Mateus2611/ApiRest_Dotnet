using System.ComponentModel.DataAnnotations;

namespace TarefasBackEnd.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        
        public Guid IdUsuario { get; set; }

        [Required]
        public string? Nome { get; set; }

        public bool Concluida { get; set; } = false;
    }
}