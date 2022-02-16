using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using Xunit;

namespace Patrimonio.Teste.Controllers
{

    public class EquipamentoControllerTests
    {

        //[Fact]
        //public void DeveRetornarOsEquipamentos()
        //{
        //    var RepositoryFalso = new Mock<IEquipamentoRepository>();

        //    // Pré-Condição
        //    var equipamentoFake = new Equipamento();
        //    equipamentoFake.Id = 1;
        //    equipamentoFake.NomePatrimonio = "Computador";
        //    equipamentoFake.DataCadastro = DateTime.Now;
        //    equipamentoFake.Ativo = true;
        //    equipamentoFake.Descricao = "Computador Gamer, o melhor do mundo";
        //    equipamentoFake.Imagem = "";

        //    RepositoryFalso.Setup(x => x.Listar()).Returns(equipamentoFake);
        //    var controller = new EquipamentosController(RepositoryFalso.Object);

        //    // Procedimento
        //    var resultado = controller.GetEquipamentos();
        //    // Resultado Esperado
        //    Assert.IsType<OkObjectResult>(resultado);
        //}

        //[Fact]
        //public void DeveCadastrarEquipamentos()
        //{
        //    var RepositoryFalso = new Mock<IEquipamentoRepository>();

        //    var equipamento = new Equipamento();

        //    equipamento.DataCadastro = DateTime.Now;
        //    RepositoryFalso.Setup(x => x.Cadastrar(equipamento));

            


        //}

    }
}
