using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TarefasController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TarefasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tarefas = await _appDbContext.Tarefas.ToListAsync();

            return View(tarefas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var novaTarefa = new TarefasModel();

            return View("CreateEdit", novaTarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TarefasModel tarefa)
        {
            if (!ModelState.IsValid)
            {
                // criei isso para se houver erro, parar aqui e devolve a tela com as mensagens do <span>
                return View("CreateEdit", tarefa);
            }
            _appDbContext.Tarefas.Add(tarefa);

            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tarefa = _appDbContext.Tarefas.Find(id);

            if(tarefa == null)
                return NotFound();

            return View("CreateEdit", tarefa);
        }

        [HttpPost]
        public IActionResult Edit(int id, TarefasModel tarefa)
        {
            var tarefaById = _appDbContext.Tarefas.Find(id);

            if (tarefaById == null)
                return NotFound();

            tarefaById.Nome = tarefa.Nome;
            tarefaById.Descricao = tarefa.Descricao;
            tarefaById.Prazo = tarefa.Prazo;
            tarefaById.Prioridade = tarefa.Prioridade;
            tarefaById.Status = tarefa.Status;

            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tarefa = _appDbContext.Tarefas.Find(id);

            if (tarefa == null)
                return NotFound();

            _appDbContext.Tarefas.Remove(tarefa);

            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}