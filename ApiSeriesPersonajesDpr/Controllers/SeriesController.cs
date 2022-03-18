using ApiSeriesPersonajesDpr.Models;
using ApiSeriesPersonajesDpr.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesPersonajesDpr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private SeriesRepository repo;
        public SeriesController(SeriesRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
       public ActionResult<List<Serie>> GetAllSeries()
        {
            return this.repo.GetAllSeries();
        } 

        [HttpGet]
        [Route("{idSerie}")]
        public ActionResult<Serie> GetSerieById(int idSerie)
        {
            return this.repo.GetSerieById(idSerie);
        }

        [HttpGet]
        [Route("PersonajesSerie/{idSerie}")]
        public ActionResult<List<Personaje>> GetPersonajesFromSerie(int idSerie)
        {
            return this.repo.GetPersonajesFromSerie(idSerie);
        }

        [HttpDelete]
        [Route("{idSerie}")]
        public ActionResult DeleteSerie(int idSerie)
        {
            this.repo.DeleteSerie(idSerie);

            return Ok();
        }

        [HttpPost]
        public ActionResult InsertSerie(Serie s)
        {
            this.repo.InsertSerie(s);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSerie(Serie s)
        {
            this.repo.UpdateSerie(s);

            return Ok();
        }
    }
}
