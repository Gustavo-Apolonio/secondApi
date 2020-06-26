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
    }
}