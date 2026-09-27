using System.ComponentModel.DataAnnotations;
namespace Agendamento.Models
{
    public class Paciente
    {
        // Identificador único do médico.
        // O Entity Framework Core utiliza essa propriedade como chave primária da tabela.
        public int Id { get; set; }


        [Required] // Indica que o nome é obrigatório.
        [MaxLength(100)] // Define que o nome pode ter, no máximo, 100 caracteres.
        public string? Nome { get; set; }


        [Required] // Indica que o CPF é obrigatório.
        [MaxLength(15)] // Define que o CPF pode ter, no máximo, 15 caracteres.
        public string? Cpf { get; set; }

        [Required] // Indica que o telefone é obrigatório.
        [MaxLength(18)] // Define que o telefone pode ter, no máximo, 18 caracteres.
        public string? Telefone { get; set; }


        [Required] // Indica que o endereço é obrigatório.
        [MaxLength(100)] // Define que o endereço pode ter, no máximo, 100 caracteres.
        public string? Endereco { get; set; }   = null;

        [Required] // Indica que a data de nascimento é obrigatória.
        public DateOnly DataNascimento { get; set; }
    }
}
