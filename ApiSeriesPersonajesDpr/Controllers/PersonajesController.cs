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
    public class PersonajesController : ControllerBase
    {

        private PersonajesRepository repo;
        
        public PersonajesController(PersonajesRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetAllPersonajes()
        {
            return this.repo.GetAllPersonajes();
        }

        [HttpGet]
        [Route("{idSerie}")]
        public ActionResult<List<Personaje>> GetPersonajeBySerieId(int idSerie)
        {
            List<Personaje> p = this.repo.GetPersonajesBySerieId(idSerie);

            if (p == null)
            {
                return BadRequest();
            }else
            {
                return p;
            }
        }

        [HttpPost]
        public ActionResult InsertPersonaje(Personaje p)
        {
            this.repo.InsertPersonaje(p);
            return Ok();
        }
        
        [HttpDelete]
        [Route("{idPersonaje}")]
        public ActionResult DeletePersonaje(int idPersonaje)
        {
            this.repo.DeletePersonaje(idPersonaje);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdatePersonaje(Personaje p)
        {
            this.repo.UpdatePersonaje(p);
            return Ok();
        }

        [HttpPut]
        [Route("{idPersonaje}/{idSerie}")]
        public ActionResult UpdateSeriePersonaje(int idPersonaje, int idSerie)
        {
            this.repo.UpdateSeriePersonaje(idPersonaje, idSerie);
            return Ok();
        }

    }
}
