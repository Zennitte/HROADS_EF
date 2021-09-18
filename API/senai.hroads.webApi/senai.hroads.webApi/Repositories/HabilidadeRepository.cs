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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if (habilidadeAtualizada.NomeHabilidade != null || habilidadeAtualizada.IdTipoHabilidade > 0)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
                habilidadeBuscada.IdTipoHabilidade = habilidadeAtualizada.IdTipoHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public void Atualizar(byte id, Habilidade habilidadeAtualizada)
        {
            throw new NotImplementedException();
        }

        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Habilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            throw new NotImplementedException();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        public List<Habilidade> ListarComTipo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
