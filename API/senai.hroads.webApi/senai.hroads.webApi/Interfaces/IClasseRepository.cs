using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> Listar();
        Classe BuscarPorId(int id);
        void Cadastrar(Classe novaClasse);
        void Deletar(int id);
        void Atualizar(short id, Classe classeAtualizada);
    }
}
