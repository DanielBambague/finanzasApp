using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finanzasApp
{
    public partial class FormGastos : Form
    {
        private string connectionString = @"Server=localhost; Initial Catalog=FinanzasPersonales; Integrated Security=True;";
        public FormGastos()
        {
            InitializeComponent();
        }

        // Evento para cargar los datos al abrir el formulario
        private void FormGastos_Load(object sender, EventArgs e)
        {
            CargarGastos();
        }

        // Método para registrar un gasto
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string mes = txtMes.Text;
                string descripcion = txtDescripcion.Text;
                decimal valor = decimal.Parse(txtValor.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AgregarGasto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Mes", mes);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@Valor", valor);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Gasto registrado correctamente.");
                    }
                }

                // Recargar los datos en el DataGridView
                CargarGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Método para cargar la tabla de gastos en el DataGridView
        private void CargarGastos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Gastos", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewGastos.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los gastos: {ex.Message}");
            }
        
             
        }

        private void btnEliminarGasto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya ingresado un ID válido
                if (int.TryParse(textEA.Text, out int idGasto))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("EliminarGasto", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@IdGasto", idGasto);

                            connection.Open();
                            command.ExecuteNonQuery();

                            MessageBox.Show("Gasto eliminado correctamente.");
                        }
                    }

                    // Recargar la tabla de gastos
                    CargarGastos();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID de gasto válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el gasto: {ex.Message}");
            }
        }


        // Botón para actualizar un gasto
        private void btnActualizarGasto_Click(object sender, EventArgs e)
        {
            if (dataGridViewGastos.SelectedRows.Count > 0)
            {
                int idGasto = Convert.ToInt32(dataGridViewGastos.SelectedRows[0].Cells["IdGasto"].Value);
                string mes = txtMes.Text;
                string descripcion = txtDescripcion.Text;
                decimal valor;

                if (decimal.TryParse(txtValor.Text, out valor))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Gastos SET Mes = @Mes, Descripcion = @Descripcion, Valor = @Valor WHERE IdGasto = @IdGasto";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IdGasto", idGasto);
                            command.Parameters.AddWithValue("@Mes", mes);
                            command.Parameters.AddWithValue("@Descripcion", descripcion);
                            command.Parameters.AddWithValue("@Valor", valor);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Gasto actualizado correctamente.");
                    CargarGastos(); // Recargar la tabla
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para el gasto.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un gasto para actualizar.");
            }
        }
    }

}



