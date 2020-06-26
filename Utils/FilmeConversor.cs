using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace secondApi.Utils
{
    public class FilmeConversor
    {
        
        public Models.TbFilme ToTableConversor(Models.Request.FilmeRequest req)
        {
            Models.TbFilme filme = new Models.TbFilme();
            filme.NmFilme = req.Filme;
            filme.DsGenero = req.Genero;
            filme.NrDuracao = req.Duracao;
            filme.VlAvaliacao = req.Avaliacao;
            filme.BtDisponivel = req.Disponivel;
            filme.DtLancamento = req.Lancamento;

            return filme;
        }

        public Models.Response.FilmeResponse ToResponseConversor(Models.TbFilme filme)
        {
            Models.Response.FilmeResponse resp = new Models.Response.FilmeResponse();
            resp.Id = filme.IdFilme;
            resp.Filme = filme.NmFilme;
            resp.Genero = filme.DsGenero;
            resp.Duracao = filme.NrDuracao;
            resp.Avaliacao = filme.VlAvaliacao;
            resp.Disponivel = filme.BtDisponivel;
            resp.Lancamento = filme.DtLancamento;

            return resp;
        }
    }
}