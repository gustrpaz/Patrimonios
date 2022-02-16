using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario != null)
            {
                if (usuario.Senha.Length < 32)
                {
                    string novaSenha = Criptografia.GerarHash(usuario.Senha);
                    usuario.Senha = novaSenha;

                    ctx.Update(usuario);
                    ctx.SaveChanges();
                }
                
                // Com o usuário encontrado, temos a Hash do banco para poder comparar
                // com a senha vindo do formulário

                bool comparado = Criptografia.Comparar(senha, usuario.Senha);
                if (comparado)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
