using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EmpleadoBLL
    {
        private EmpleadoDAL empleadoDAL;

        public EmpleadoBLL()
        {
            empleadoDAL = new EmpleadoDAL();
        }
        


     public void AgregarEmpleado(Empleado empleado)
     {
            // Comprueba si todos los campos obligatorios están completos
            if (string.IsNullOrEmpty(empleado.Nombre) && string.IsNullOrEmpty(empleado.Apellido) && string.IsNullOrEmpty(empleado.Departamento) && empleado.Salario <= 0)
            {
                throw new Exception("Todos los campos son obligatorios.");
            }

            // Comprueba si el empleado ya existe en la base de datos
            Empleado existeEmpleado = ObtenerEmpleados().FirstOrDefault(f => f.Nombre.Equals(empleado.Nombre) && f.Apellido.Equals(empleado.Apellido) && f.Departamento.Equals(empleado.Departamento) && f.Salario == empleado.Salario);

            if (existeEmpleado != null)
            {
                throw new Exception("El empleado ya fue ingresado");
            }

            // Comprueba si el campo del nombre está vacío
            if (string.IsNullOrEmpty(empleado.Nombre))
            {
                throw new Exception("El campo del nombre es obligatorio.");
            }

            // Comprueba si el campo del apellido está vacío
            if (string.IsNullOrEmpty(empleado.Apellido))
            {
                throw new Exception("El campo del apellido es obligatorio.");
            }

            // Comprueba si el campo del departamento está vacío
            if (string.IsNullOrEmpty(empleado.Departamento))
            {
                throw new Exception("El campo del departamento es obligatorio.");
            }

            // Comprueba si el salario es menor o igual a cero
            if (empleado.Salario <= 0)
            {
                throw new Exception("El salario del empleado debe ser mayor que cero.");
            }

            // Si todo está bien, agrega el empleado a la base de datos
            if (empleadoDAL.GuardarEmpleado(empleado))
            {
                Console.WriteLine("El empleado se ha creado con éxito.");
            }
            else
            {
                Console.WriteLine("No se ha podido guardar el empleado.");
            }


        }
        
           

            

            
        






        public List<Empleado> ObtenerEmpleados()
        {
            return empleadoDAL.ObtenerEmpleados();
        }

        
    }
}
