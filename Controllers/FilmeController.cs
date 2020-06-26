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
            catch (System.Exception e)
            {
                return NotFound(
                    new Models.Response.ErrorResponse(404, e.Message)
                );
            }
        }
    }
}