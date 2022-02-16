using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio.Teste.Controllers
{
    public class LoginControllerTest
    {
        // Aqui estamos criando um repositório mocado

        // Aqui o teste deve dar certo caso um usuário seja inválido
        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {

            // Pré-Condição
            var FakeRepository = new Mock<IUsuarioRepository>();

            // O Setup é um parâmetro da biblioteca "Moq" que detrmina qual método que irá simular
            FakeRepository
            .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
            .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();
         

            // Esse "Fake.Repoistory.Object" faz com que não utilizamos o banco de dados
            var controller = new LoginController(FakeRepository.Object);

            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado Esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }


        // Aqui o teste deve dar certo caso um usuário seja válido
        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            // Pré-Condição
            var usuarioFake = new Usuario();
            usuarioFake.Email = "paulo@email.com";
            usuarioFake.Senha = "$2a$11$fTQZgf9AE/v2W29xAacl9.fynTjcWShg.Q8a6OnyU1h4Ms8A8dvBe";

            // O Setup é um parâmetro da biblioteca "Moq" que detrmina qual método que irá simular
            var FakeRepository = new Mock<IUsuarioRepository>();
            FakeRepository
            .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();
           
            // Esse "Fake.Repoistory.Object" faz com que não utilizamos o banco de dados
            var controller = new LoginController(FakeRepository.Object);

            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado Esperado
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
