using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Controllers;
using ToDoList.Data;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests.Unit
{
    public class TarefasControllerTests
    {
        private DbContextOptions<AppDbContext> _options;

        public TarefasControllerTests()
        {
            // Banco de dados em memória isolado para cada execução de teste
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task Index_DeveRetornarViewComListaDeTarefas()
        {
            using var context = new AppDbContext(_options);
            context.Tarefas.Add(new TarefasModel { Nome = "Tarefa 1" });
            context.Tarefas.Add(new TarefasModel { Nome = "Tarefa 2" });
            await context.SaveChangesAsync();

            var controller = new TarefasController(context);

            var resultado = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<TarefasModel>>(viewResult.Model);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public void Create_Post_ComDadosValidos_DeveSalvarERedirecionar()
        {
            using var contextCadastro = new AppDbContext(_options);
            var controller = new TarefasController(contextCadastro);
            var novaTarefa = new TarefasModel { Nome = "Estudar xUnit", Status = false };

            var resultado = controller.Create(novaTarefa);

            var redirectResult = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.Equal("Index", redirectResult.ActionName);

            using var contextVerificacao = new AppDbContext(_options);
            var tarefaSalva = contextVerificacao.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaSalva);
            Assert.Equal("Estudar xUnit", tarefaSalva.Nome);
        }

        [Fact]
        public void Edit_Post_ComDadosValidos_DeveAtualizarERedirecionar()
        {

            using var contextInicial = new AppDbContext(_options);
            var tarefaOriginal = new TarefasModel { Id = 1, Nome = "Nome Antigo", Status = false };
            contextInicial.Tarefas.Add(tarefaOriginal);
            contextInicial.SaveChanges();

            var controller = new TarefasController(contextInicial);
            var dadosAtualizados = new TarefasModel { Nome = "Nome Novo", Status = true };

            var resultado = controller.Edit(1, dadosAtualizados);

            var redirectResult = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.Equal("Index", redirectResult.ActionName);

            using var contextVerificacao = new AppDbContext(_options);
            var tarefaAlterada = contextVerificacao.Tarefas.Find(1);
            Assert.NotNull(tarefaAlterada);
            Assert.Equal("Nome Novo", tarefaAlterada.Nome);
            Assert.True(tarefaAlterada.Status);
        }

        [Fact]
        public void Edit_Post_TarefaInexistente_DeveRetornarNotFound()
        {
            using var context = new AppDbContext(_options);
            var controller = new TarefasController(context);
            var dadosAtualizados = new TarefasModel { Nome = "Qualquer Nome" };

            var resultado = controller.Edit(99, dadosAtualizados);

            Assert.IsType<NotFoundResult>(resultado);
        }

        [Fact]
        public void Delete_Post_TarefaExistente_DeveRemoverERedirecionar()
        {
            using var contextInicial = new AppDbContext(_options);
            var tarefa = new TarefasModel { Id = 5, Nome = "Tarefa para Deletar" };
            contextInicial.Tarefas.Add(tarefa);
            contextInicial.SaveChanges();

            var controller = new TarefasController(contextInicial);

            var resultado = controller.Delete(5);

            var redirectResult = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.Equal("Index", redirectResult.ActionName);

            using var contextVerificacao = new AppDbContext(_options);
            var tarefaDeletada = contextVerificacao.Tarefas.Find(5);
            Assert.Null(tarefaDeletada); 
        }

        [Fact]
        public void Delete_Post_TarefaInexistente_DeveRetornarNotFound()
        {

            using var context = new AppDbContext(_options);
            var controller = new TarefasController(context);

            var resultado = controller.Delete(99);

            Assert.IsType<NotFoundResult>(resultado);
        }
    }
}
