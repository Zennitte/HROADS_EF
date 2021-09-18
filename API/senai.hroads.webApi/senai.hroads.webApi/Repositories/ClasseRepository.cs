using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(byte id, Classe classeAtualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Classes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }
    }
}
