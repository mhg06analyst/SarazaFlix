using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Strategies
{
    public class ReproduccionHDStrategy : ICalidadReproduccionStrategy
    {
        public CalidadReproduccion ObtenerCalidad() => CalidadReproduccion.HD;

        public string Reproducir(Contenido contenido)
        {
            return $"Reproduciendo '{contenido.Titulo}' en HD (Alta Definición).";
        }
    }
}
