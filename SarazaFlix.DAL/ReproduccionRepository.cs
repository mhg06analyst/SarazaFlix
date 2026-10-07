using System;
using System.IO;
using SarazaFlix.Domain;

namespace SarazaFlix.DAL
{
    public class ReproduccionRepository
    {
        // Ruta absoluta apuntando a tu carpeta en el escritorio
        private readonly string _rutaArchivo = @"C:\Users\Outlet VL\Desktop\Facu\reproducciones_log.txt";

        public void Guardar(Reproduccion reproduccion)
        {
            // Creamos un formato personalizado separado por el caracter pipe (|)
            string calidades = string.Join(",", reproduccion.CalidadesUtilizadas);

            // Validamos nulos por si es un intento rechazado
            string nombreUsuario = reproduccion.Usuario != null ? reproduccion.Usuario.Nombre : "Desconocido";
            string tituloContenido = reproduccion.Contenido != null ? reproduccion.Contenido.Titulo : "Desconocido";

            string linea = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|" +
                           $"Usuario:{nombreUsuario}|" +
                           $"Contenido:{tituloContenido}|" +
                           $"Calidades:[{calidades}]|" +
                           $"Origen:{reproduccion.Origen}|" +
                           $"Rechazos:{reproduccion.IntentosRechazadosPorPlan}";

            // AppendAllText crea el archivo si no existe, o agrega la línea al final si ya existe.
            File.AppendAllText(_rutaArchivo, linea + Environment.NewLine);
        }
    }
}