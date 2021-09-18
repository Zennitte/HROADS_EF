using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClasseHabilidade> Listar();
        ClasseHabilidade BuscarPorId(int id);
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);
        void Deletar(short id);
        void Atualizar(short id, ClasseHabilidade classeHabilidadeAtualizada);
    }
}
