using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class EmpleadoDAL
    {
        public bool GuardarEmpleado(Empleado empleado)
        {
            // Convertir la fecha de nacimiento a una cadena en el formato correcto para SQL
            string fechaNacimientoString = empleado.FechaNacimiento.ToString("yyyy-MM-dd");


            string query = $"INSERT INTO Empleados(Nombre, Apellido, FechaNacimiento, Departamento, Salario) VALUES( '{empleado.Nombre}','{empleado.Apellido}','{empleado.FechaNacimiento}','{empleado.Departamento}','{empleado.Salario}')";
            int rows = DatabaseHelper.Instance.ExecuteNonQuery(query);
            if (rows==0)
            {
                return false;
            }
            return true;
        }
        public List<Empleado> ObtenerEmpleados()
        {
            string query = "SELECT * FROM empleados";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(query);
            List<Empleado> empleados = new List<Empleado>();
            foreach (DataRow row in dt.Rows)
            {
                Empleado e = new Empleado();
                e.ID = int.Parse(row["id"].ToString());
                e.Nombre = row["nombre"].ToString();
                e.Apellido = row["apellido"].ToString();
                e.FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString());
                e.Departamento = row["departamento"].ToString();
                e.Salario = Decimal.Parse(row["salario"].ToString());
                empleados.Add(e);
            }
            return empleados;
        }
    }
}
