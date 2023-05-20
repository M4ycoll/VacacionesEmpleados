using System;
using System.Collections.Generic;
using System.Linq;
using VacacionesEmpleados.Models;

namespace VacacionesEmpleados.Services
{
    public class EmpleadoService
    {
        private List<Empleado> _empleados;

        public EmpleadoService()
        {
            _empleados = new List<Empleado>();
        }

        public IEnumerable<Empleado> GetAllEmpleados()
        {
            return _empleados ?? Enumerable.Empty<Empleado>();
        }

        public Empleado GetEmpleadoById(Guid id)
        {
            return _empleados.SingleOrDefault(e => e.Id == id);
        }

        public void CreateEmpleado(Empleado empleado)
        {
            empleado.Id = Guid.NewGuid();
            _empleados.Add(empleado);
        }

        public void UpdateEmpleado(Guid id, Empleado empleado)
        {
            var existingEmpleado = _empleados.SingleOrDefault(e => e.Id == id);

            if (existingEmpleado != null)
            {
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.FechaIngreso = empleado.FechaIngreso;
                existingEmpleado.CargoId = empleado.CargoId;
                existingEmpleado.Disponible = empleado.Disponible;
            }
        }

        public void DeleteEmpleado(Guid id)
        {
            var empleado = _empleados.SingleOrDefault(e => e.Id == id);

            if (empleado != null)
            {
                _empleados.Remove(empleado);
            }
        }
    }
}