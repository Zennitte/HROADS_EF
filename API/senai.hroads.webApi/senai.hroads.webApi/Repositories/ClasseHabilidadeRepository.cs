using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(short id, ClasseHabilidade classeHabilidadeAtualizada)
        {
            ClasseHabilidade classeHabilidadeBuscada = ctx.ClasseHabilidades.Find(id);

            if (classeHabilidadeAtualizada.IdClasse < 0 || classeHabilidadeAtualizada.IdHabilidade < 0)
            {
                classeHabilidadeBuscada.IdClasse = classeHabilidadeAtualizada.IdClasse;
                classeHabilidadeBuscada.IdHabilidade = classeHabilidadeAtualizada.IdHabilidade;

                ctx.ClasseHabilidades.Update(classeHabilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public void Atualizar(byte id, ClasseHabilidade classeHabilidadeAtualizada)
        {
            throw new NotImplementedException();
        }

        public ClasseHabilidade BuscarPorId(int id)
        {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).FirstOrDefault(ch => ch.IdClasseHabilidade == id);
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            ctx.ClasseHabilidades.Add(novaClasseHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.ClasseHabilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(short id)
        {
            throw new NotImplementedException();
        }

        public List<ClasseHabilidade> Listar()
        {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).ToList();
        }
    }
}
