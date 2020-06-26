using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace secondApi.Business
{
    public class FilmeBusiness
    {
        Database.FilmeDatabase dbFilme = new Database.FilmeDatabase();
        public Models.TbFilme AdicionarFilme(Models.TbFilme filme)
        {
            if(filme.NmFilme == string.Empty)
                throw new ArgumentException("O nome do filme é obrigatório.");
            
            filme = dbFilme.AdicionarFilme(filme);
            return filme;
        }

        public List<Models.TbFilme> ConsultarFilmes()
        {
            List<Models.TbFilme> filmes = dbFilme.ConsultarFilmes();

            if(filmes.Count == 0)
                throw new ArgumentException("Não há filmes no Banco de Dados.");

            return filmes;
        }
    }
}