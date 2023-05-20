using System.ComponentModel.DataAnnotations;

namespace VacacionesEmpleados.Models;

public class Empleado
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(250)]
    public String? Nombre { get; set; }

    [MaxLength(250)]
    public String? FechaIngreso { get; set; }

    [MaxLength(250)]
    public String? CargoId { get; set; }

    [MaxLength(250)]
    public Disponibilidad Disponible { get; set; } 
    public enum Disponibilidad{
        disponible,
        nodisponible,
    }
    public virtual ICollection<Cargo> ?Cargos { get; set; }
    public virtual ICollection<Vacaciones> ?_Vacaciones { get; set; }
}