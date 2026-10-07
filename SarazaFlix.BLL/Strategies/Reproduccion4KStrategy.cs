using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Strategies
{
    public class Reproduccion4KStrategy : ICalidadReproduccionStrategy
    {
        public CalidadReproduccion ObtenerCalidad() => CalidadReproduccion.CuatroK;

        public string Reproducir(Contenido contenido)
        {
            return $"Reproduciendo '{contenido.Titulo}' en deslumbrante 4K (Ultra HD).";
        }
    }
}
