using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.Domain
{
    public class Reproduccion
    {
        public Usuario Usuario { get; set; }
        public Contenido Contenido { get; set; }

        // El enunciado pide registrar "calidades utilizadas durante la reproducción" 
        // ya que pueden cambiar en plena reproducción.
        public List<CalidadReproduccion> CalidadesUtilizadas { get; set; } = new List<CalidadReproduccion>();

        public OrigenContenido Origen { get; set; }
        public int IntentosRechazadosPorPlan { get; set; }

        public Reproduccion()
        {
            CalidadesUtilizadas = new List<CalidadReproduccion>();
        }
    }
}
