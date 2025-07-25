using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Modelos
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        

        // Relacion
        public int ProyectoId { get; set; } 
        public int UsuarioId { get; set; } 

        // Navegacion
        public Proyecto? Proyecto { get; set; } 
        public Usuario? Usuario { get; set; } 

    }
}
