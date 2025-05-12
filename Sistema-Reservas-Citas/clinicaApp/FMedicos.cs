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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace clinicaApp
{
    public partial class FMedicos : Form
    {
        private string pacienteIdSeleccionado;
        public FMedicos()
        {
            InitializeComponent();
            //Agregamos evento para que cargue las especialidades
            this.Load += new EventHandler(Especialidades_cargar);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Función para limpiar datos de los campos
        private void Limpieza()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        //Función de insertar datos
        private void button1_Click(object sender, EventArgs e)
        {
            EspecialidadAux especialidadSeleccionada = (EspecialidadAux)comboBox1.SelectedItem;
            int especialidadId = especialidadSeleccionada.Id;

            

            using (var conn = DB.GetConnection())
            {
                try
                {
                    string sql = "INSERT INTO medico (nombre, especialidad_id, email, telefono, consultorio) " +
                                 "VALUES (@nombre, @especialidad_id, @email, @telefono, @consultorio)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                    cmd.Parameters.AddWithValue("@especialidad_id", especialidadId);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@telefono", textBox5.Text);
                    cmd.Parameters.AddWithValue("@consultorio", textBox6.Text);
                    cmd.Parameters.AddWithValue("@id", textBox7.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medico agregado exitosamente.");

                    // Refrescar datos y limpiar campos
                    CargarDatos();
                    Limpieza();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar Medico: " + ex.Message);
                }
            }
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //Lista desplegable de especialidad, va conectada a una CLASE especialidadAux,
        //es la función para elegir especialidad
        private void Especialidades_cargar(object sender, EventArgs e)
        {
            comboBox1.Items.Add(new EspecialidadAux { Id = 1, Nombre = "Medicina General" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 2, Nombre = "Pediatría" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 3, Nombre = "Cardiología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 4, Nombre = "Infectología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 5, Nombre = "Medicina Interna" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 6, Nombre = "Dermatología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 7, Nombre = "Neumología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 8, Nombre = "Oncología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 9, Nombre = "Reumatología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 10, Nombre = "Ginecología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 11, Nombre = "Traumatología" });
            comboBox1.Items.Add(new EspecialidadAux { Id = 12, Nombre = "Neurología" });
            comboBox1.SelectedIndex = 0;
        }

        //Función para que sean visibles los registros de la tabla Medico
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT * FROM Medico";

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

        //Funcion para capturar los datos del datagridview
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
                comboBox1.Text = row.Cells["especialidad_id"].Value.ToString();
                textBox4.Text = row.Cells["email"].Value.ToString();
                textBox5.Text = row.Cells["telefono"].Value.ToString();
                textBox6.Text = row.Cells["consultorio"].Value.ToString();
                textBox6.MaxLength = 4;
            }
        }


        //Función para que los datos se actializen automáticamente en el griddataview
        private void CargarDatos()
        {
            
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT * FROM Medico";

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

        //Función para actualizar los registros
        private void button2_Click(object sender, EventArgs e)
        {
            //Llamamos la función para la lista desplegable
            EspecialidadAux especialidadSeleccionada = (EspecialidadAux)comboBox1.SelectedItem;
            int especialidadId = especialidadSeleccionada.Id;

            if (string.IsNullOrWhiteSpace(pacienteIdSeleccionado))
            {
                MessageBox.Show("Debe seleccionar un paciente para actualizar.");
                return;
            }

            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = @"UPDATE Medico
                     SET nombre = @nombre, 
                         especialidad_id = @especialidad_id, 
                         email = @email, 
                         telefono = @telefono, 
                         consultorio = @consultorio 
                     WHERE id = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);


                    command.Parameters.AddWithValue("@id", pacienteIdSeleccionado);
                    command.Parameters.AddWithValue("@nombre", textBox1.Text);
                    command.Parameters.AddWithValue("@especialidad_id", especialidadId);
                    command.Parameters.AddWithValue("@email", textBox4.Text);
                    command.Parameters.AddWithValue("@telefono", textBox5.Text);
                    command.Parameters.AddWithValue("@consultorio", textBox6.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form formulario5 = new Form1();
            this.Hide(); // Oculta la ventana actual
            formulario5.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario5.Show();
        }
    }
}
