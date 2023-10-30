using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Empleado
    {
        public Empleado() { }

        public Empleado(int id, string nombre, string apellido, string departamento, DateTime fechaNacimiento, decimal salario)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Departamento = departamento;
            this.FechaNacimiento = fechaNacimiento;
            this.Salario = salario;
        }

        public Empleado(string nombre, string apellido, string departamento, DateTime fechaNacimiento, decimal salario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Departamento = departamento;
            this.FechaNacimiento = fechaNacimiento;
            this.Salario = salario;
          
        }

        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Departamento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Decimal Salario { get; set; }
    }
}
