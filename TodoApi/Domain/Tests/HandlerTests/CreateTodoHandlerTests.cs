using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Domain.Commands;
using TodoApi.Domain.Handlers;
using TodoApi.Domain.Tests.Repositories;

namespace TodoApi.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título tarefa", "leozim123", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests() { }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {

            Assert.Fail();
        }

        [TestMethod]
        public void Dado_um_comando_válido_deve_criar_a_tarefa()
        {
            Assert.Fail();
        }
    }
}
