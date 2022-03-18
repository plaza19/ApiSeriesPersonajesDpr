using ApiSeriesPersonajesDpr.Data;
using ApiSeriesPersonajesDpr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesPersonajesDpr.Repositories
{
    public class SeriesRepository
    {

        private ApiSeriesContext context;
        private PersonajesRepository repo;

        public SeriesRepository(ApiSeriesContext context, PersonajesRepository repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public List<Serie> GetAllSeries()
        {
            var consulta = from data in this.context.Series select data;

            if (consulta.Count() == 0)
            {
                return null;
            }else
            {
                return consulta.ToList();
            }
        }

        public Serie GetSerieById(int idSerie)
        {
            var consulta = from data in this.context.Series where data.IdSerie == idSerie select data;

            return consulta.FirstOrDefault();
        }

        public List<Personaje> GetPersonajesFromSerie(int idSerie)
        {
            return this.repo.GetPersonajesBySerieId(idSerie);
        }

        public void DeleteSerie(int idSerie)
        {
            Serie s = this.GetSerieById(idSerie);
            this.context.Series.Remove(s);
            this.context.SaveChanges();
        }

        private int GetNewId()
        {
            int max = this.context.Series.Max(x => x.IdSerie);
            return max + 1;
        }

        public void InsertSerie(Serie s)
        {
            s.IdSerie = GetNewId();
            this.context.Series.Add(s);
            this.context.SaveChanges();

        }

        public void UpdateSerie(Serie s)
        {
            Serie aux = this.GetSerieById(s.IdSerie);
            aux.NombreSerie = s.NombreSerie;
            aux.Puntuacion = s.Puntuacion;
            aux.Imagen = s.Imagen;
            aux.Año = s.Año;

            context.SaveChanges();
        }



    }
}
