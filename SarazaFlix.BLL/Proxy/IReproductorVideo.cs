using SarazaFlix.BLL.Strategies;
using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Proxy
{
    public interface IReproductorVideo
    {
        Reproduccion IniciarReproduccion(Usuario usuario, Contenido contenido, ICalidadReproduccionStrategy estrategia);
    }
}
