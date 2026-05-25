using System.ComponentModel.DataAnnotations;
using ToDoList.Models.Enums;


namespace ToDoList.Models
{

    public class TarefasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome não pode passar de {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        public DateTime Prazo {  get; set; } = DateTime.MinValue;
        public PrioridadeEnum Prioridade { get; set; }
        public bool Status {  get; set; }
    }
}
