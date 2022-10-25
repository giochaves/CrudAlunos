using Microsoft.AspNetCore.Mvc;
using RegistroAlunos.Models;
using RegistroAlunos.Repositorio;

namespace RegistroAlunos.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            List<AlunoModel> alunos = _alunoRepositorio.BuscarTodos();
            return View(alunos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        public IActionResult ConfirmaDeletar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        public IActionResult Deletar(int id)
        {
            _alunoRepositorio.Deletar(id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Adicionar(AlunoModel aluno)
        {
            _alunoRepositorio.Adicionar(aluno);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(AlunoModel aluno)
        {
            _alunoRepositorio.Atualizar(aluno);
            return RedirectToAction("Index");
        }
    }
}
