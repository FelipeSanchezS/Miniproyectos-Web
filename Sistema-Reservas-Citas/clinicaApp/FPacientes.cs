using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaApp;
using MySql.Data.MySqlClient;
//using System;
//using System.Data;
//using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace clinicaApp

{
    public partial class FPacientes : Form
    {
        private string pacienteIdSeleccionado;

        public FPacientes()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Sección para agregar pacientes en la tabla
        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    string sql = "INSERT INTO paciente (nombre, apellido, documento, email, telefono, fecha_nacimiento) " +
                                 "VALUES (@nombre, @apellido, @documento, @email, @telefono, @fecha_nacimiento)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Validar y convertir la fecha
                    DateTime fechaNacimiento;
                    if (!DateTime.TryParseExact(textBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                    {
                        MessageBox.Show("Por favor, ingrese una fecha válida en el formato DD/MM/YYYY.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                    cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
                    cmd.Parameters.AddWithValue("@documento", textBox3.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@telefono", textBox5.Text);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente agregado exitosamente.");

                    // Refrescar datos y limpiar campos
                    CargarDatos();
                    Limpieza();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar paciente: " + ex.Message);
                }
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            //string query = "SELECT * FROM Paciente";

            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();
            //        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            //        DataTable table = new DataTable();
            //        adapter.Fill(table);
            //        dataGridView1.DataSource = table;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: " + ex.Message);
            //    }
            //}
        }
        //Función para que sean visibles los registros de la tabla Paciente
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT * FROM Paciente";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Función para que los datos se actializen automáticamente en el griddataview
        private void CargarDatos()
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT * FROM Paciente";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        //Función para limpiar datos de los campos
        private void Limpieza()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        //Función para modificar datos
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Guarda el ID seleccionado
                string id = row.Cells["id"].Value.ToString();
                pacienteIdSeleccionado = id;
                textBox7.Text = id;

                textBox1.Text = row.Cells["nombre"].Value.ToString();
                textBox2.Text = row.Cells["apellido"].Value.ToString();
                textBox3.Text = row.Cells["documento"].Value.ToString();
                textBox4.Text = row.Cells["email"].Value.ToString();
                textBox5.Text = row.Cells["telefono"].Value.ToString();
                textBox6.Text = row.Cells["fecha_nacimiento"].Value.ToString();
                textBox6.MaxLength = 10;
            }

        }
        //---
        //Función para actualizar los registros
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pacienteIdSeleccionado))
            {
                MessageBox.Show("Debe seleccionar un paciente para actualizar.");
                return;
            }

            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = @"UPDATE Paciente 
                     SET nombre = @nombre, 
                         apellido = @apellido, 
                         documento = @documento, 
                         email = @email, 
                         telefono = @telefono, 
                         fecha_nacimiento = @fecha_nacimiento 
                     WHERE id = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Validar y convertir la fecha
                    DateTime fechaNacimiento;
                    if (!DateTime.TryParseExact(textBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                    {
                        MessageBox.Show("Por favor, ingrese una fecha válida en el formato DD/MM/YYYY.");
                        return;
                    }

                    command.Parameters.AddWithValue("@id", pacienteIdSeleccionado);
                    command.Parameters.AddWithValue("@nombre", textBox1.Text);
                    command.Parameters.AddWithValue("@apellido", textBox2.Text);
                    command.Parameters.AddWithValue("@documento", textBox3.Text);
                    command.Parameters.AddWithValue("@email", textBox4.Text);
                    command.Parameters.AddWithValue("@telefono", textBox5.Text);
                    command.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                    textBox6.MaxLength = 10;

                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro actualizado correctamente.");

                    // Refrescar datos y limpiar campos
                    CargarDatos();
                    Limpieza();
                    pacienteIdSeleccionado = ""; // Limpiar variable de selección
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 10;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formulario5 = new Form1();
            this.Hide(); // Oculta la ventana actual
            formulario5.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario5.Show();
        }
    }
}
