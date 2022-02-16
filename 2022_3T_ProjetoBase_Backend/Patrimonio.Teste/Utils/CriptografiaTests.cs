using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Teste.Utils
{
    public class CriptografiaTests
    {

        [Fact]  // Descrição
        public void DeveRetornarHashEmBCrypt()
        {
            // Procedimento / Act
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento / Act
            // Vai verificar se essa linha está validada, IsMatch método nativo compara os 2 e retorna true ou false
            var retorno = regex.IsMatch(senha);

            // Resultado esperado / Assert
            Assert.True(retorno);
       
        }

        [Fact]  // Descrição
        public void DeveRetornarComparacaoValida()
        {
            // Pré-Condiçao
            var senha = "123456789";
            var hash = "$2a$11$fTQZgf9AE/v2W29xAacl9.fynTjcWShg.Q8a6OnyU1h4Ms8A8dvBe";

            // Procedimento 
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado esperado
            Assert.True(comparacao);
        }
    }
}
