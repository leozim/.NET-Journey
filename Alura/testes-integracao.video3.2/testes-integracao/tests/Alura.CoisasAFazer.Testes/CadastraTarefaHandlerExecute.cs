using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            ////arrange
            //var comando = new CadastraTarefa("Estudar Xunit", new Categoria(100, "Estudo"), new DateTime(2019, 12, 31));

            //var options = new DbContextOptionsBuilder<DbTarefasContext>()
            //    .UseInMemoryDatabase("DbTarefasContext")
            //    .Options;
            //var contexto = new DbTarefasContext(options);
            //var repo = new RepositorioTarefa(contexto);

            //var handler = new CadastraTarefaHandler(repo);

            ////act
            //handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            ////assert
            //var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar Xunit").FirstOrDefault();
            //Assert.NotNull(tarefa);

            //arrange
            var commandTask = new CadastraTarefa("Passar veneno", new Categoria(1, "Para minha mãe"), new DateTime(2021, 02, 15));

            var _mock = new Mock<RepositorioFake>();
            _mock.Setup(fake => fake.IncluirTarefas(It.IsAny<Tarefa[]>()));

            var _mockRepository = _mock.Object;

            var handler = new CadastraTarefaHandler(_mockRepository);
            //act
            handler.Execute(commandTask); // SUT
            //assert

        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<IRepositorioTarefas>();

            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro na inclusão de tarefas"));

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExeccao()
        {
            //arrange
            //act
            //assert
        }
    }
}
