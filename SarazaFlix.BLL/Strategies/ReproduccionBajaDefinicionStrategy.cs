using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Strategies
{
    public class ReproduccionBajaDefinicionStrategy : ICalidadReproduccionStrategy
    {
        public CalidadReproduccion ObtenerCalidad() => CalidadReproduccion.BajaDefinicion;

        public string Reproducir(Contenido contenido)
        {
            return $"Reproduciendo '{contenido.Titulo}' en Baja Definición (SD).";
        }
    }
}
