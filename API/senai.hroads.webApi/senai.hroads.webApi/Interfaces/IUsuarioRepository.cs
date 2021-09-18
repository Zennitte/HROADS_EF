using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario novoUsuario);
        void Deletar(int id);
        void Atualizar(int id, Usuario usuarioAtualizado);
        Usuario Login(string senha, string email);
        List<Usuario> ListarComTipo();
    }
}
