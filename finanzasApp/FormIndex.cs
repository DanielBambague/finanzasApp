using System.Data;
using System.Data.SqlClient;

namespace finanzasApp
{
    public partial class FormIndex : Form
    {
        private string connectionString = @"Server=localhost; Initial Catalog=FinanzasPersonales; Integrated Security=True;";


        public FormIndex()
        {
            InitializeComponent();
        }

        private void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                string mes = textMes.Text;

                // Validar y convertir la cantidad de chaquetas a int
                if (!int.TryParse(txtCantidadChaquetas.Text, out int cantidadChaquetas))
                {
                    MessageBox.Show("Por favor, ingresa un valor válido para la cantidad de chaquetas.");
                    return;
                }

                // Validar y convertir el valor unitario a decimal
                if (!decimal.TryParse(txtValorUnitario.Text, out decimal valorUnitario))
                {
                    MessageBox.Show("Por favor, ingresa un valor válido para el valor unitario.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AgregarIngreso", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Mes", mes);
                        command.Parameters.AddWithValue("@CantidadChaquetas", cantidadChaquetas);
                        command.Parameters.AddWithValue("@ValorUnitario", valorUnitario);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ingreso agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnMostrarResumen_Click(object sender, EventArgs e)
        {
            MostrarResumen();
        }


        private void btnEliminarIngreso_Click(object sender, EventArgs e)
        {
            int idIngreso = int.Parse(txtIdIngreso.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("EliminarIngreso", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdIngreso", idIngreso);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ingreso eliminado correctamente.");
                }
            }
        }
        private void btnActualizarIngreso_Click(object sender, EventArgs e)
        {
            int idIngreso = int.Parse(txtIdIngreso.Text);
            string mes = textMes.Text;
            int cantidadChaquetas = int.Parse(txtCantidadChaquetas.Text);
            decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ActualizarIngreso", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdIngreso", idIngreso);
                    command.Parameters.AddWithValue("@Mes", mes);
                    command.Parameters.AddWithValue("@CantidadChaquetas", cantidadChaquetas);
                    command.Parameters.AddWithValue("@ValorUnitario", valorUnitario);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ingreso actualizado correctamente.");
                }
            }
        }

        private void BtnGastos_Click(object sender, EventArgs e)
        {
            FormGastos formGastos = new FormGastos();
            formGastos.ShowDialog();
        }

         private void Form1_Load(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                // Cerrar la aplicación si no se autentica
                Application.Exit();
            }
            CargarIngresos();
            // Asegúrate de que el DataGridView tenga columnas definidas antes de interactuar con él
            /* dataGridView1.Columns.Clear();  // Limpiar columnas previas si existen
             dataGridView1.Columns.Add("Mes", "Mes");
             dataGridView1.Columns.Add("TotalIngresos", "Total Ingresos");
             dataGridView1.Columns.Add("TotalGastos", "Total Gastos");
             dataGridView1.Columns.Add("SaldoRestante", "Saldo Restante");*/
        }



        // Mostrar todos los ingresos en el DataGridView
        private void BtnMostrarIngresos_Click(object sender, EventArgs e)
        {
            CargarIngresos();
        }



        private void CargarIngresos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Ingresos", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Mostrar grid de ingresos y ocultar el de resumen
                        dataGridIngresos.Visible = true;
                        dataGridResumen.Visible = false;
                        dataGridAhorros.Visible = false;

                        // Cargar datos en dataGridIngresos
                        dataGridIngresos.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los ingresos: {ex.Message}");
            }
        }

        private void MostrarResumen()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("ObtenerResumenMensual", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Mostrar grid de resumen y ocultar el de ingresos
                            dataGridResumen.Visible = true;
                            dataGridIngresos.Visible = false;
                            dataGridAhorros.Visible=false;

                            // Configurar columnas del resumen
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Mes");
                            dataTable.Columns.Add("TotalIngresos");
                            dataTable.Columns.Add("TotalGastos");
                            dataTable.Columns.Add("SaldoRestante");

                            while (reader.Read())
                            {
                                dataTable.Rows.Add(
                                    reader["Mes"],
                                    Convert.ToDecimal(reader["TotalIngresos"]).ToString("N0"),
                                    Convert.ToDecimal(reader["TotalGastos"]).ToString("N0"),
                                    Convert.ToDecimal(reader["SaldoRestante"]).ToString("N0")
                                );
                            }

                            // Cargar datos en dataGridResumen
                            dataGridResumen.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar el resumen: {ex.Message}");
            }
        }

        private void btnAhorros_Click(object sender, EventArgs e)
        {
            if (LoginForm.CedulaUsuario == "1022971006" || LoginForm.CedulaUsuario == "1023918163")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Ahorros";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridResumen.Visible = false;
                        dataGridIngresos.Visible = false;
                        dataGridAhorros.Visible = true;

                        // Mostrar la tabla en un DataGridView
                        dataGridAhorros.DataSource = table;
                    }
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para ver esta información.");
            }
        }
    }
}



