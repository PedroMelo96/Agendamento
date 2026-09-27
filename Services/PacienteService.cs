using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class PacienteService
    {
        // Armazena uma referência para o contexto do banco de dados.
        // O readonly impede que essa referência seja substituída após
        // a criação do objeto MedicoService.
        private readonly AppDbContext _context;

        // Recebe o AppDbContext por Injeção de Dependência.
        // O ASP.NET Core fornece automaticamente o contexto configurado
        // quando cria uma instância do MedicoService.
        public PacienteService(AppDbContext context)
        {
            // Armazena o contexto para que os métodos da classe possam
            // acessar a tabela de médicos no banco de dados.
            _context = context;
        }

        // Retorna todos os pacientes cadastrados no banco de dados.
        public List<Paciente> Listar()
        {
            // Acessa a tabela Pacientes, executa a consulta e transforma
            // os registros retornados em uma lista de objetos Paciente.
            return _context.Pacientes.OrderBy(p => p.Id).ToList();

        }

        // Insere um novo paciente no banco de dados.
        // O parâmetro obj representa o paciente recebido pela controller.
        public void Inserir(Paciente obj)
        {
            // Adiciona o novo paciente ao contexto.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Pacientes.Add(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando INSERT.
            _context.SaveChanges();
        }

        // Procura um paciente no banco de dados utilizando seu identificador.
        // O parâmetro id representa o identificador do paciente procurado.
        public Paciente? EncontrarId(int id)
        {
            // O método Find() procura um registro pela chave primária.
            // Retorna o paciente encontrado ou null caso ele não exista.
            return _context.Pacientes.Find(id);
        }


        // Remove um paciente do banco de dados.
        // O parâmetro id representa o identificador do paciente que será removido.
        public void Remover(int id)
        {
            // Procura o paciente no banco de dados utilizando sua chave primária.
            var obj = _context.Pacientes.Find(id);

            // Verifica se foi encontrado um paciente com o identificador informado.
            // Caso não exista, encerra o método sem realizar nenhuma operação.
            if (obj == null)
            {
                return;
            }

            // Marca o paciente encontrado para remoção.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Pacientes.Remove(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando DELETE.
            _context.SaveChanges();
        }


        // Atualiza os dados de um paciente no banco de dados.
        // O parâmetro obj representa o paciente recebido pela controller.
        public void Atualizar(Paciente obj)
        {
            // Marca o objeto como modificado no contexto.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Pacientes.Update(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando UPDATE.
            _context.SaveChanges();
        }
    }
}
