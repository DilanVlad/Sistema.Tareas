namespace Gestion.MVC.Models
{
    public class ReportesViewModel
    {
        public IEnumerable<Modelos.Tarea> Tareas { get; set; }
        public Dictionary<int, List<Modelos.Tarea>> TareasPorProyecto { get; set; }
        public Dictionary<int?, List<Modelos.Tarea>> TareasPorUsuario { get; set; }
        public string? EstadoFiltro { get; set; }
        public string? OrdenarPor { get; set; }
        public int? ProyectoId { get; set; }
        public int? UsuarioId { get; set; }
    }
}
