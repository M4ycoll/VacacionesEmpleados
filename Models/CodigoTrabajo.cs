using System.ComponentModel.DataAnnotations;

namespace VacacionesEmpleados.Models;

public class CodigoTrabajo
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(250)]
    public int? Antiguedad { get; set; }

    [MaxLength(250)]
    public int? DiasOtorgados { get; set; }

    [MaxLength(250)]
    public Vigencia Vigente { get; set; } 
    public enum Vigencia{
        si,
        no,
    }
}