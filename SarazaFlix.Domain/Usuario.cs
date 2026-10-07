using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarazaFlix.Domain
{
   public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public PlanSuscripcion Plan { get; set; }
    }
}
