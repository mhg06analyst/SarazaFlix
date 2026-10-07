using SarazaFlix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.BLL.Strategies
{
    public interface ICalidadReproduccionStrategy
    {
        // Devuelve el enum para que el reproductor pueda registrar qué calidad se usó.
        CalidadReproduccion ObtenerCalidad();

        // Simula la acción de reproducir devolviendo un mensaje para la UI.
        string Reproducir(Contenido contenido);
    }
}
