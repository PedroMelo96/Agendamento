using Agendamento.Models;

namespace Agendamento.Data
{
    public class SeedingService
    {
        // Declara uma referência para o contexto do banco de dados.
        // O AppDbContext permite consultar, adicionar, atualizar e remover registros.
        // O modificador readonly impede que essa referência seja substituída
        // depois que o objeto SeedingService for construído.
        private readonly AppDbContext _context;

        // O AppDbContext é recebido pelo construtor por meio da
        // injeção de dependência (DI).
        // O ASP.NET Core cria a instância configurada do AppDbContext
        // e a fornece automaticamente quando cria o SeedingService.
        public SeedingService(AppDbContext context)
        {
            // Armazena a instância recebida para que ela possa ser utilizada
            // pelos outros métodos da classe.
            _context = context;
        }

        // Popula o banco de dados com os registros iniciais.
        public void Popula2()
        {
            // Utiliza o contexto para consultar a tabela Medicos.
            // Any() retorna true quando a tabela já possui pelo menos um registro.
            if (_context.Pacientes.Any())
            {
                // Encerra o método para evitar a inserção de dados duplicados.
                return;

            }
            else
            {
                // Cria o primeiro objeto que será inserido no banco.
                Paciente p1 = new Paciente
                {
                    Nome = "Luiza",
                    Cpf = "12345678901",
                    Endereco = "Rua A, 123",
                    Telefone = "11987654321",
                    DataNascimento = new DateOnly(1990, 1, 1)
                };

                // Cria o segundo objeto que será inserido no banco.
                Paciente p2 = new Paciente
                {
                    Nome = "João",
                    Cpf = "12345678902",
                    Endereco = "Rua B, 456",
                    Telefone = "11987654322",
                    DataNascimento = new DateOnly(1985, 5, 15)
                };

                // Adiciona os dois pacientes ao contexto de uma única vez.
                // Mas ainda não salva no banco de dados
                _context.Pacientes.AddRange(p1, p2);

                // Confirma as alterações pendentes.
                // O EF Core gera e executa os comandos INSERT no banco de dados.
                _context.SaveChanges();

            }
        }

             public void Popula()
        {
            // Utiliza o contexto para consultar a tabela Medicos.
            // Any() retorna true quando a tabela já possui pelo menos um registro.
            if (_context.Medicos.Any())
            {
                // Encerra o método para evitar a inserção de dados duplicados.
                return;

            }
            else
            {
                // Cria o primeiro objeto que será inserido no banco.
                Medico m1 = new Medico
                {
                    Nome = "Luiza",
                    Crm = "123456",
                    Especialidade = "Vascular"
                };

                // Cria o segundo objeto que será inserido no banco.
                Medico m2 = new Medico
                {
                    Nome = "João",
                    Crm = "456789",
                    Especialidade = "Ortopedista"
                };

                // Adiciona os dois médicos ao contexto de uma única vez.
                // Mas ainda não salva no banco de dados
                _context.Medicos.AddRange(m1, m2);

                // Confirma as alterações pendentes.
                // O EF Core gera e executa os comandos INSERT no banco de dados.
                _context.SaveChanges();

            }
        }
    }
}
