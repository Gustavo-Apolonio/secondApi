using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace secondApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        Utils.FilmeConversor filmeConversor = new Utils.FilmeConversor();
        Business.FilmeBusiness filmeBusiness = new Business.FilmeBusiness();
        // 1)
        [HttpPost]
        public ActionResult<Models.Response.FilmeResponse> AdicionarFilme(Models.Request.FilmeRequest filmeReq)
        {
            try
            {
                Models.TbFilme filme = filmeConversor.ToTableConversor(filmeReq);

                filme = filmeBusiness.AdicionarFilme(filme);

                Models.Response.FilmeResponse filmeResp = filmeConversor.ToResponseConversor(filme);

                return filmeResp;
            }
            catch(System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErrorResponse(400, e.Message)
                );
            }
        }

        // 2)
        [HttpGet]
        public ActionResult<List<Models.Response.FilmeResponse>> ConsultarFilmes()
        {
            try
            {
                List<Models.TbFilme> filmes = filmeBusiness.ConsultarFilmes();
                List<Models.Response.FilmeResponse> filmes2 = filmes.Select(x => filmeConversor.ToResponseConversor(x)).ToList();

                return filmes2;
            }
            catch
            {
                return NotFound(
                    new List<Models.Response.FilmeResponse>(){}
                );
            }
        }

        // 3)
        [HttpPut("{id}")]
        public ActionResult AlterarFilme(Models.Request.FilmeRequest novo, int id)
        {
            try
            {
                Models.TbFilme antigo = filmeBusiness.ConsultarFilme(id);

                Models.TbFilme atual = filmeConversor.ToTableConversor(novo);

                atual = filmeBusiness.AlterarFilme(antigo, atual);

                return NoContent();
            }
            catch (System.Exception e)
            {
                return BadRequest(
                    new Models.Response.ErrorResponse(400, e.Message)
                );
            }
        }

        // 4)
        [HttpGet("{id}")]
        public ActionResult<Models.Response.FilmeResponse> ConsultarFilme(int id)
        {
            try
            {
                Models.TbFilme filme = filmeBusiness.ConsultarFilme(id);

                Models.Response.FilmeResponse filme1 = filmeConversor.ToResponseConversor(filme);
                
                return filme1;
            }
            catch
            {
                return NotFound(null);
            }
        }

        // 5)
        [HttpDelete("{id}")]
        public ActionResult DeletarFilme(int id)
        {
            try
            {
                Models.TbFilme filme = filmeBusiness.ConsultarFilme(id);

                filmeBusiness.DeletarFilme(filme);

                return Ok(null);
            }
            catch
            {
                return NotFound(null);
            }
        }

        // 6)
        [HttpGet("filtrar")]
        public ActionResult<List<Models.Response.FilmeResponse>> ConsultarFilmesFiltro(string nome,
                                                                                       string genero)
        {
            try
            {
                List<Models.TbFilme> filmes = filmeBusiness.ConsultarFilmesFiltro(nome, genero);

                List<Models.Response.FilmeResponse> filmeResponses = filmes.Select(
                    x => filmeConversor.ToResponseConversor(x)
                    ).ToList();

                return filmeResponses;
            }
            catch
            {
                return NotFound(
                    new List<Models.Response.FilmeResponse>(){}
                );
            }
        }
    }
}