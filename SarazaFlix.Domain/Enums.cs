using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.Domain
{
    public enum PlanSuscripcion
    {
        Basico,
        Estandar,
        Premium
    }

    public enum CalidadReproduccion
    {
        BajaDefinicion,
        HD,
        CuatroK
    }

    public enum OrigenContenido
    {
        Servidor,
        DispositivoLocal
    }
}
