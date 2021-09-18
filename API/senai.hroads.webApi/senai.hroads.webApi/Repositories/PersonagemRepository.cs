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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(id);

            if (personagemAtualizado.IdClasse > 0 || personagemAtualizado.NomePersonagem != null || personagemAtualizado.VidaMax != null || personagemAtualizado.ManaMax != null || personagemAtualizado.DataCriacao < DateTime.Now || personagemAtualizado.DataAtualizacao < DateTime.Now )
            {
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
                personagemBuscado.VidaMax = personagemAtualizado.VidaMax;
                personagemBuscado.ManaMax = personagemAtualizado.ManaMax;
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;

                ctx.Personagems.Update(personagemBuscado);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novaPersonagem)
        {
            ctx.Personagems.Add(novaPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Personagems.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.ToList();
        }

        public List<Personagem> ListarComClasse()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
