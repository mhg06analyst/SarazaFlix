using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SarazaFlix.BLL.Strategies;

namespace SarazaFlix.BLL
{
    public class GestorConexion
    {
        // Mide la conexión y devuelve la estrategia correspondiente según las reglas del negocio.
        public ICalidadReproduccionStrategy DeterminarEstrategia(int velocidadMbps, bool modoAhorroDatos)
        {
            if (modoAhorroDatos)
            {
                return new ReproduccionBajaDefinicionStrategy();
            }

            if (velocidadMbps >= 25) // Buena conexión (ejemplo > 25Mbps)
            {
                return new Reproduccion4KStrategy();
            }
            else if (velocidadMbps >= 5) // Conexión media (ejemplo 5 - 24Mbps)
            {
                return new ReproduccionHDStrategy();
            }
            else // Conexión mala (ejemplo < 5Mbps)
            {
                return new ReproduccionBajaDefinicionStrategy();
            }
        }
    }
}
