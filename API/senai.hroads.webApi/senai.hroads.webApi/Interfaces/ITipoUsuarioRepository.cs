using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(int id);
        void Cadastrar(TipoUsuario novoTipoUsuario);
        void Deletar(int id);
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);
    }
}
