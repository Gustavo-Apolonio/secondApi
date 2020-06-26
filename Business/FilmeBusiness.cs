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

        public Models.TbFilme ConsultarFilme(int id)
        {
            if(id <= 0)
                throw new ArgumentException("O ID não pode ser menor ou igual a 0.");

            Models.TbFilme filme = dbFilme.ConsultarFilme(id);

            if(filme == null)
                throw new Exception("O filme não existe.");

            return filme;
        }

        public Models.TbFilme AlterarFilme(Models.TbFilme antigo, Models.TbFilme novo)
        {
            if(novo.NrDuracao <= 0)
                throw new ArgumentException("Duração Inválida.");

            Models.TbFilme filme = dbFilme.AlterarFilme(antigo, novo);
            return filme;
        }

        public void DeletarFilme(Models.TbFilme filme)
        {
            if(filme.IdFilme == 0)
                throw new ArgumentException("O filme não existe.");
                
            dbFilme.DeletarFilme(filme);
        }
    }
}