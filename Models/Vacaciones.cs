using System.ComponentModel.DataAnnotations;

namespace VacacionesEmpleados.Models;

public class Vacaciones
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(250)]
    public DateOnly Fecha { get; set; }

    [Key]
    public Guid EmpleadoId { get; set; }


    public virtual ICollection<Empleado> ?Empleados { get; set; }
}