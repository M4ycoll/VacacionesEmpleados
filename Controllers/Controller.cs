using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VacacionesEmpleados.Models;

namespace VacacionesEmpleados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly List<Empleado> _empleados;

        public EmpleadoController()
        {
            // Crear una lista de empleados para simular una fuente de datos
            _empleados = new List<Empleado>();

            // Agregar empleados de ejemplo
            _empleados.Add(new Empleado
            {
                Id = Guid.NewGuid(),
                Nombre = "Empleado 1",
                FechaIngreso = "2022-01-01",
                CargoId = "1",
                Disponible = Empleado.Disponibilidad.disponible
            });

            _empleados.Add(new Empleado
            {
                Id = Guid.NewGuid(),
                Nombre = "Empleado 2",
                FechaIngreso = "2021-05-01",
                CargoId = "2",
                Disponible = Empleado.Disponibilidad.nodisponible
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Devolver todos los empleados
            return Ok(_empleados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            // Buscar el empleado por su id
            var empleado = _empleados.FirstOrDefault(e => e.Id == id);

            if (empleado == null)
            {
                // Devolver un código de estado 404 (Not Found) si el empleado no existe
                return NotFound();
            }

            // Devolver el empleado encontrado
            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Empleado empleado)
        {
            // Generar un nuevo id para el empleado
            empleado.Id = Guid.NewGuid();

            // Agregar el empleado a la lista
            _empleados.Add(empleado);

            // Devolver un código de estado 201 (Created) con el empleado creado
            return CreatedAtAction(nameof(GetById), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Empleado empleado)
        {
            // Buscar el empleado por su id
            var empleadoExistente = _empleados.FirstOrDefault(e => e.Id == id);

            if (empleadoExistente == null)
            {
                // Devolver un código de estado 404 (Not Found) si el empleado no existe
                return NotFound();
            }

            // Actualizar los datos del empleado existente
            empleadoExistente.Nombre = empleado.Nombre;
            empleadoExistente.FechaIngreso = empleado.FechaIngreso;
            empleadoExistente.CargoId = empleado.CargoId;
            empleadoExistente.Disponible = empleado.Disponible;

            // Devolver un código de estado 204 (No Content) para indicar que la actualización fue exitosa
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // Buscar el empleado por su id
            var empleado = _empleados.FirstOrDefault(e => e.Id == id);

            if (empleado == null)
            {
                // Devolver un código de estado 404 (Not Found) si el empleado no existe
                return NotFound();
            }

            // Eliminar el empleado de la lista
            _empleados.Remove(empleado);

            // Devolver un código de estado 204 (No Content) para indicar que la eliminación fue exitosa
            return NoContent();
        }
    } 
}