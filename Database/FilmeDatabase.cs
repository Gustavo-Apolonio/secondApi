using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace secondApi.Database
{
    public class FilmeDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbFilme AdicionarFilme(Models.TbFilme filme)
        {
            ctx.Add(filme);
            ctx.SaveChanges();

            return filme;
        }   

        public List<Models.TbFilme> ConsultarFilmes()
        {
            List<Models.TbFilme> filmes = ctx.TbFilme.ToList();

            return filmes;
        }

        public Models.TbFilme ConsultarFilme(int id)
        {
            Models.TbFilme filme = ctx.TbFilme.First(x => x.IdFilme == id);
            return filme;
        }

        public Models.TbFilme AlterarFilme(Models.TbFilme antigo, Models.TbFilme novo)
        {
            antigo.NmFilme = novo.NmFilme;
            antigo.DsGenero = novo.DsGenero;
            antigo.NrDuracao = novo.NrDuracao;
            antigo.VlAvaliacao = novo.VlAvaliacao;
            antigo.BtDisponivel = novo.BtDisponivel;
            antigo.DtLancamento = novo.DtLancamento;

            ctx.SaveChanges();
            return antigo;
        }

        public void DeletarFilme(Models.TbFilme filme)
        {
            ctx.Remove(filme);
            ctx.SaveChanges();   
        }
    }
}