using System;
using System.Collections.Generic;
using System.Linq;
using SarazaFlix.Domain;
using SarazaFlix.BLL.Strategies;

namespace SarazaFlix.BLL.Proxy
{
    public class ReproductorProxy : IReproductorVideo
    {
        private readonly IReproductorVideo _servidorReal;
        private readonly List<Contenido> _cacheDispositivo; // Guarda los últimos 5

        public ReproductorProxy()
        {
            _servidorReal = new ServidorRemotoVideo();
            _cacheDispositivo = new List<Contenido>();
        }

        public Reproduccion IniciarReproduccion(Usuario usuario, Contenido contenido, ICalidadReproduccionStrategy estrategia)
        {
            // 1. Control de Acceso (Protection Proxy)
            // En C#, los enums tienen un valor numérico (Basico=0, Estandar=1, Premium=2)
            if ((int)usuario.Plan < (int)contenido.PlanRequerido)
            {
                throw new UnauthorizedAccessException($"Plan insuficiente. El usuario {usuario.Nombre} tiene plan {usuario.Plan} y se requiere {contenido.PlanRequerido}.");
            }

            Reproduccion reproduccion;

            // 2. Control de Caché (Cache Proxy)
            // Buscamos si el contenido ya está en el dispositivo local
            if (_cacheDispositivo.Any(c => c.Id == contenido.Id))
            {
                // Servimos desde el caché local
                reproduccion = new Reproduccion
                {
                    Usuario = usuario,
                    Contenido = contenido,
                    Origen = OrigenContenido.DispositivoLocal,
                    IntentosRechazadosPorPlan = 0
                };
                reproduccion.CalidadesUtilizadas.Add(estrategia.ObtenerCalidad());
            }
            else
            {
                // No está en caché, delegamos al servidor real
                reproduccion = _servidorReal.IniciarReproduccion(usuario, contenido, estrategia);

                // Lo agregamos al caché local
                _cacheDispositivo.Add(contenido);

                // Mantenemos estrictamente los últimos 5
                if (_cacheDispositivo.Count > 5)
                {
                    _cacheDispositivo.RemoveAt(0); // Eliminamos el más antiguo (FIFO)
                }
            }

            return reproduccion;
        }
    }
}
