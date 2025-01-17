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
    public partial class LoginForm : Form
    {
        public static string CedulaUsuario { get; private set; }
        private string connectionString = @"Server=localhost; Initial Catalog=FinanzasPersonales; Integrated Security=True;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cedula = textLogin.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Cedula = @Cedula";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cedula", cedula);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        CedulaUsuario = cedula;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Cédula no registrada. Intente de nuevo.");
                    }
                }
            }
        }
    }
}

