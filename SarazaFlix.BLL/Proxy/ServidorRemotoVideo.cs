using SarazaFlix.BLL.Strategies;
using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Proxy
{
    public class ServidorRemotoVideo : IReproductorVideo
    {
        public Reproduccion IniciarReproduccion(Usuario usuario, Contenido contenido, ICalidadReproduccionStrategy estrategia)
        {
            // Como viene del servidor real, el origen siempre es "Servidor"
            var reproduccion = new Reproduccion
            {
                Usuario = usuario,
                Contenido = contenido,
                Origen = OrigenContenido.Servidor,
                IntentosRechazadosPorPlan = 0
            };

            reproduccion.CalidadesUtilizadas.Add(estrategia.ObtenerCalidad());

            return reproduccion;
        }
    }
}
