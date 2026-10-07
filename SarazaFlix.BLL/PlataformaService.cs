using System;
using System.Collections.Generic;
using SarazaFlix.Domain;
using SarazaFlix.BLL.Proxy;
using SarazaFlix.BLL.Strategies;
using SarazaFlix.BLL.Exportacion;
using SarazaFlix.DAL;

namespace SarazaFlix.BLL
{
    public class PlataformaService
    {
        private readonly IReproductorVideo _reproductor;
        private readonly GestorConexion _gestorConexion;
        private readonly ReproduccionRepository _repositorio;
        private readonly ExportadorGenerico _exportador;

        public PlataformaService()
        {
            _reproductor = new ReproductorProxy();
            _gestorConexion = new GestorConexion();
            _repositorio = new ReproduccionRepository();
            _exportador = new ExportadorGenerico();
        }

        public string ReproducirContenido(Usuario usuario, Contenido contenido, int velocidadMbps, bool ahorroDatos)
        {
            // 1. Determinar la estrategia de calidad según la conexión/ahorro
            ICalidadReproduccionStrategy estrategia = _gestorConexion.DeterminarEstrategia(velocidadMbps, ahorroDatos);

            try
            {
                // 2. Intentar reproducir a través del proxy (valida plan y caché)
                Reproduccion rep = _reproductor.IniciarReproduccion(usuario, contenido, estrategia);

                // 3. Persistir el registro exitoso en DAL
                _repositorio.Guardar(rep);

                // 4. Retornar mensaje de éxito simulando la reproducción en pantalla
                return estrategia.Reproducir(contenido) + $" (Fuente: {rep.Origen})";
            }
            catch (UnauthorizedAccessException ex)
            {
                // Manejo de rechazo por plan insuficiente
                var repFallida = new Reproduccion
                {
                    Usuario = usuario,
                    Contenido = contenido,
                    IntentosRechazadosPorPlan = 1
                };

                // Persistimos el intento rechazado como pide el requerimiento
                _repositorio.Guardar(repFallida);

                return $"ACCESO DENEGADO: {ex.Message}";
            }
        }

        // Exponemos el método de exportación para la UI
        public void ExportarListado<T>(List<T> lista, string rutaArchivo)
        {
            _exportador.ExportarATexto(lista, rutaArchivo);
        }
    }
}