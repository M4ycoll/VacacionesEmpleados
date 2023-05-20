using System.ComponentModel.DataAnnotations;

namespace VacacionesEmpleados.Models;

public class Cargo
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(250)]
    public String? Nombre { get; set; }

    public virtual ICollection<Empleado> ?Empleados { get; set; }
}