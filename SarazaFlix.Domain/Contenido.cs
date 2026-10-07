using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.Domain
{
    public class Contenido
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        // Fundamental para que el Proxy sepa si el usuario tiene permiso de verlo
        public PlanSuscripcion PlanRequerido { get; set; }
    }
}
