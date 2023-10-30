using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        private EmpleadoBLL empleadoBLL;

        
        public Form1()
        {
            InitializeComponent();
            empleadoBLL = new EmpleadoBLL();
            nudSalario.Maximum = 100000000; // Aumenta el valor máximo permitido en el control NumericUpDown

        }

       

        private void btnCargarEmpleados_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView
            this.dgvEmpleado.Rows.Clear();

            // Obtener la lista de empleados
            List<Empleado> empleados = empleadoBLL.ObtenerEmpleados();

            // Llenar el DataGridView con los empleados
            foreach (Empleado empleado in empleados)
            {string[] row = { empleado.ID.ToString(), empleado.Nombre, empleado.Apellido, empleado.FechaNacimiento.ToString(), empleado.Departamento, empleado.Salario.ToString() };
                this.dgvEmpleado.Rows.Add(row);
            }


        }

        private void btnAgregarEmpleado_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string departamento = txtDepartamento.Text;
            decimal salario = nudSalario.Value;

            Empleado empleado = new Empleado(nombre, apellido, departamento, fechaNacimiento, salario);

            try
            {
                this.empleadoBLL.AgregarEmpleado(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                dtpFechaNacimiento.ResetText();
                txtDepartamento.Clear();
                nudSalario.ResetText();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarEmpleados_Click_1(object sender, EventArgs e)
        {
            // Obtener la lista de empleados
            List<Empleado> empleados = empleadoBLL.ObtenerEmpleados();

            // Crear un objeto DataTable y llenarlo con los datos de los empleados
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("FechaNacimiento", typeof(DateTime));
            dataTable.Columns.Add("Departamento", typeof(string));
            dataTable.Columns.Add("Salario", typeof(decimal));

            foreach (Empleado empleado in empleados)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = empleado.ID;
                row["Nombre"] = empleado.Nombre;
                row["Apellido"] = empleado.Apellido;
                row["FechaNacimiento"] = empleado.FechaNacimiento;
                row["Departamento"] = empleado.Departamento;
                row["Salario"] = empleado.Salario;
                dataTable.Rows.Add(row);
            }

            // Asignar el objeto DataTable al objeto DataSource del DataGridView
            dgvEmpleado.DataSource = dataTable;
        }
        }
}
