using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agendamento.Controllers
{
    // A classe PacienteController recebe as requisições relacionadas aos pacientes.
    //
    // Ela utiliza o PacienteService para solicitar as operações da aplicação
    // e retorna as views que serão apresentadas ao usuário.
    public class PacienteController : Controller
    {
        // Armazena uma referência para o serviço responsável pelas
        // operações relacionadas aos pacientes.
        private readonly PacienteService _pacienteService;

        // Recebe o PacienteService por Injeção de Dependência.
        // O ASP.NET Core fornece uma instância do serviço ao criar a controller.
        public PacienteController(PacienteService pacienteService)
        {
            // Armazena o serviço para que ele possa ser utilizado
            // pelas ações da controller.
            _pacienteService = pacienteService;
        }

        // Recebe a requisição para a página de listagem de pacientes.
        public IActionResult Index()
        {
            // Solicita ao serviço todos os pacientes cadastrados.
            var listaPacientes = _pacienteService.Listar();

            // Envia a lista recebida para a view Index.cshtml.
            return View(listaPacientes);
        }

        // Recebe uma requisição GET para abrir a tela de inserção.
        public IActionResult Inserir()
        {
            // Retorna a view Inserir.cshtml, que contém o formulário.
            return View();
        }

        // Indica que esta ação será executada quando o formulário
        // enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Paciente paciente)
        {
            // Recebe o objeto Paciente preenchido com os dados enviados
            // pelos campos do formulário e solicita sua inserção ao serviço.
            _pacienteService.Inserir(paciente);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a inserção.
            return RedirectToAction(nameof(Index));
        }

        // Recebe o identificador do paciente selecionado na listagem
        // e apresenta seus dados na página de detalhes.
        public IActionResult Detalhar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do paciente pelo identificador recebido.
            var obj = _pacienteService.EncontrarId(id.Value);

            // Verifica se algum paciente foi encontrado.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o paciente encontrado para a view Detalhar.
            return View(obj);
        }

        // Recebe o identificador do paciente selecionado e apresenta
        // seus dados no formulário de edição.
        public IActionResult Editar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do paciente que será editado.
            var obj = _pacienteService.EncontrarId(id.Value);

            // Verifica se o paciente foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o paciente encontrado para a view Editar,
            // permitindo que o formulário seja preenchido com seus dados.
            return View(obj);
        }

        // Indica que esta ação será executada quando o formulário
        // de edição enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Paciente paciente)
        {
            // Recebe o objeto Paciente preenchido com os dados enviados
            // pelo formulário e solicita sua atualização ao serviço.
            _pacienteService.Atualizar(paciente);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a atualização.
            return RedirectToAction(nameof(Index));
        }

        // Recebe o identificador do paciente selecionado e apresenta
        // seus dados na página de confirmação da remoção.
        public IActionResult Remover(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do paciente que será removido.
            var obj = _pacienteService.EncontrarId(id.Value);

            // Verifica se o paciente foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o paciente encontrado para a view Remover,
            // permitindo que o usuário confira os dados antes da exclusão.
            return View(obj);
        }

        // Indica que esta ação será executada quando o formulário
        // de confirmação enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            // Recebe o identificador enviado pelo formulário e solicita
            // ao serviço a remoção do paciente correspondente.
            _pacienteService.Remover(id);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a remoção.
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel);
        }
    }
}
