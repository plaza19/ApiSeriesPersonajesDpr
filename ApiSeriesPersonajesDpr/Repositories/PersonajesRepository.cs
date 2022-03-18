using ApiSeriesPersonajesDpr.Data;
using ApiSeriesPersonajesDpr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesPersonajesDpr.Repositories
{
    public class PersonajesRepository
    {
        private ApiSeriesContext context;

        public PersonajesRepository(ApiSeriesContext context)
        {
            this.context = context;
        }

        public List<Personaje> GetAllPersonajes()
        {
            var consulta = from data in this.context.Personajes select data;

            if (consulta.Count() == 0)
            {
                return null;
            }else
            {
                return consulta.ToList();
            }
        }

        public Personaje GetPersonajeById(int idPersonaje)
        {
            Personaje p;
            var consulta = from data in this.context.Personajes where data.IdPersonaje == idPersonaje select data;

            return consulta.FirstOrDefault();
        }

        private int GetNewId()
        {
            int max = this.context.Personajes.Max(x => x.IdPersonaje);
            return max + 1;
        }

        public void InsertPersonaje(Personaje p)
        {
            p.IdPersonaje = this.GetNewId();
            this.context.Personajes.Add(p);
            this.context.SaveChanges();
        }

        public void DeletePersonaje(int idPersonaje)
        {
            Personaje p = this.GetPersonajeById(idPersonaje);
            this.context.Personajes.Remove(p);
            this.context.SaveChanges();
        }

        public void UpdatePersonaje(Personaje p)
        {
            Personaje aux = this.GetPersonajeById(p.IdPersonaje);

            aux.Imagen = p.Imagen;
            aux.NombrePersonaje = p.NombrePersonaje;

            this.context.SaveChanges();
        }

        public void UpdateSeriePersonaje(int idPersonaje, int idSerie)
        {
            Personaje p = this.GetPersonajeById(idPersonaje);
            p.IdSerie = idSerie;

            this.context.SaveChanges();
        }

        public List<Personaje> GetPersonajesBySerieId(int idSerie)
        {
            var consulta = from data in this.context.Personajes where data.IdSerie == idSerie select data;

            if (consulta.Count() == 0)
            {
                return null;
            }else
            {
                return consulta.ToList();
            }
            
        }
    }
}
