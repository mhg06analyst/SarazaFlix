using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SarazaFlix.BLL.Exportacion
{
    public class ExportadorGenerico
    {
        // El método es genérico <T> para aceptar List<Usuario>, List<Contenido>, etc.
        public void ExportarATexto<T>(List<T> lista, string rutaArchivo)
        {
            if (lista == null || !lista.Any())
            {
                throw new ArgumentException("La lista a exportar está vacía o es nula.");
            }

            // Obtenemos el tipo (la clase) de T usando reflexión
            Type tipo = typeof(T);

            // Obtenemos todas las propiedades públicas de esa clase
            PropertyInfo[] propiedades = tipo.GetProperties();

            StringBuilder sb = new StringBuilder();

            // 1. Armar los encabezados
            // Extraemos los nombres de las propiedades y los unimos con un separador (ej. punto y coma)
            string encabezados = string.Join(";", propiedades.Select(p => p.Name));
            sb.AppendLine(encabezados);

            // 2. Armar las filas con los datos
            foreach (T item in lista)
            {
                List<string> valoresFila = new List<string>();

                foreach (PropertyInfo prop in propiedades)
                {
                    // Obtenemos el valor de la propiedad para el objeto 'item' actual
                    object valor = prop.GetValue(item);

                    // Manejo especial si el valor es una lista (como CalidadesUtilizadas en Reproduccion)
                    if (valor != null && valor.GetType().IsGenericType && valor.GetType().GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Convertimos la lista a un string separado por comas para que no rompa el CSV
                        var enumerable = valor as System.Collections.IEnumerable;
                        if (enumerable != null)
                        {
                            var itemsLista = enumerable.Cast<object>().Select(x => x.ToString());
                            valoresFila.Add(string.Join(",", itemsLista));
                        }
                        else
                        {
                            valoresFila.Add(string.Empty);
                        }
                    }
                    else
                    {
                        // Si es un tipo simple o enum, lo convertimos a string
                        valoresFila.Add(valor != null ? valor.ToString() : string.Empty);
                    }
                }

                // Unimos los valores de la fila y los agregamos al StringBuilder
                sb.AppendLine(string.Join(";", valoresFila));
            }

            // 3. Escribir el archivo físico
            File.WriteAllText(rutaArchivo, sb.ToString());
        }
    }
}