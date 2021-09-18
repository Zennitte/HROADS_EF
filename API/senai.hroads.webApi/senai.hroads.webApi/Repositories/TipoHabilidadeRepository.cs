using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            TipoHabilidade tipoHabilidadeBuscado = ctx.TipoHabilidades.Find(id);

            if (tipoHabilidadeAtualizado.NomeTipo != null)
            {
                tipoHabilidadeBuscado.NomeTipo = tipoHabilidadeAtualizado.NomeTipo;

                ctx.TipoHabilidades.Update(tipoHabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(th => th.IdTipoHabilidade == id);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }

        public List<TipoHabilidade> ListarComHabilidade()
        {
            throw new NotImplementedException();
        }
    }
}
