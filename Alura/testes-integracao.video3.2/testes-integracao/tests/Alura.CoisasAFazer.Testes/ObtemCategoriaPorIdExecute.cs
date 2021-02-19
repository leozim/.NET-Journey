using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Moq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class ObtemCategoriaPorIdExecute
    {
        [Fact]
        public void QuandoForChamadoDeveInvocarObtemCategoriaPorIdNoRepositorio()
        {
            //arrange
            var idCategoria = 20;

            var mock = new Mock<IRepositorioTarefas>();
            var repositorioTarefasMockObject = mock.Object;

            var comando = new ObtemCategoriaPorId(idCategoria);
            var handler = new ObtemCategoriaPorIdHandler(repositorioTarefasMockObject);
            //act
            handler.Execute(comando);
            //assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}