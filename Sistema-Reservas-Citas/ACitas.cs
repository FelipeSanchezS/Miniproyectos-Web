using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClinicaApp;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace clinicaApp
{
    public partial class ACitas : Form
    {
        private string pacienteIdSeleccionado;
        public ACitas()
        {
            InitializeComponent();
            this.Load += new EventHandler(ACitas_Load);
        }

        //Función principal que carga las demás funciones creadas
        private void ACitas_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            CargarMedicos();
            CargarEstados();
            CargarDatos();
        }

        //Función para limpiar datos de los campos
        private void Limpieza()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        //Función para que los datos se actualizen automáticamente en el griddataview
        private void CargarDatos()
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT * FROM cita";

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

        //Función para agregar una nueva cita
        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    string sql = "INSERT INTO cita (id_paciente, id_medico, fecha_cita, hora, motivo, estado) " +
                                 "VALUES (@id_paciente, @id_medico, @fecha_cita, @hora, @motivo, @estado)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Validar fecha
                    if (!DateTime.TryParseExact(textBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaCita))
                    {
                        MessageBox.Show("Por favor, ingrese una fecha válida en formato DD/MM/YYYY.");
                        return;
                    }

                    // Obtener valores seleccionados
                    int idPaciente = ((KeyValuePair<int, int>)comboBox1.SelectedItem).Key;
                    int idMedico = ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;
                    string estado = comboBox3.SelectedItem.ToString();

                    // Parámetros
                    cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                    cmd.Parameters.AddWithValue("@id_medico", idMedico);
                    cmd.Parameters.AddWithValue("@fecha_cita", fechaCita.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@hora", textBox3.Text);
                    cmd.Parameters.AddWithValue("@motivo", textBox1.Text);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita agregada exitosamente.");

                    CargarDatos();
                    Limpieza();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cita: " + ex.Message);
                }
            }
        }

        //Función para cargar la lista despegable de los pacientes
        private void CargarPacientes()
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT id FROM Paciente";
            

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                Dictionary<int, int> pacientes = new Dictionary<int, int>();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    pacientes.Add(id, id);
                }

                comboBox1.DataSource = new BindingSource(pacientes, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
        }

        //Función para cargar la lista despegable de medicos
        private void CargarMedicos()
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            string query = "SELECT id, nombre FROM Medico";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                Dictionary<int, string> medicos = new Dictionary<int, string>();
                while (reader.Read())
                {
                    medicos.Add(reader.GetInt32("id"), reader.GetString("nombre"));
                }
                
                comboBox2.DataSource = new BindingSource(medicos, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
                
            }
        }

        //Función para cargar la lista despegable de los estados de la cita
        private void CargarEstados()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(" ");
            comboBox3.Items.Add("pendiente");
            comboBox3.Items.Add("atendida");
            comboBox3.Items.Add("cancelada");
            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario4 = new Form1();
            this.Hide(); // Oculta la ventana actual
            formulario4.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario4.Show();
        }

        //Función para capturar los datos
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Guarda el ID seleccionado
                string id = row.Cells["id"].Value.ToString();
                pacienteIdSeleccionado = id;
                textBox4.Text = id;

                comboBox1.SelectedValue = Convert.ToInt32(row.Cells["id_paciente"].Value);
                comboBox2.SelectedValue = Convert.ToInt32(row.Cells["id_medico"].Value);
                //comboBox1.Text = row.Cells["id_paciente"].Value.ToString();
                //comboBox2.Text = row.Cells["id_medico"].Value.ToString();
                textBox2.Text = row.Cells["fecha_cita"].Value.ToString();
                textBox3.Text = row.Cells["hora"].Value.ToString();
                comboBox3.Text = row.Cells["estado"].Value.ToString();
                textBox1.Text = row.Cells["motivo"].Value.ToString();

            }
        }

        //Función para actualizar los registros
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una cita a modificar.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int citaId = Convert.ToInt32(selectedRow.Cells["id"].Value);

            using (var conn = DB.GetConnection())
            {
                try
                {
                    string sql = @"UPDATE cita 
                           SET id_paciente = @id_paciente, 
                               id_medico = @id_medico, 
                               fecha_cita = @fecha_cita, 
                               hora = @hora, 
                               motivo = @motivo, 
                               estado = @estado 
                           WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Validar fecha
                    if (!DateTime.TryParseExact(textBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaCita))
                    {
                        MessageBox.Show("Por favor, ingrese una fecha válida en formato DD/MM/YYYY.");
                        return;
                    }

                    // Obtener valores seleccionados
                    int idPaciente = ((KeyValuePair<int, int>)comboBox1.SelectedItem).Key;
                    int idMedico = ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;
                    string estado = comboBox3.SelectedItem.ToString();

                    // Asignar parámetros
                    cmd.Parameters.AddWithValue("@id", citaId);
                    cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                    cmd.Parameters.AddWithValue("@id_medico", idMedico);
                    cmd.Parameters.AddWithValue("@fecha_cita", fechaCita.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@hora", textBox3.Text);
                    cmd.Parameters.AddWithValue("@motivo", textBox1.Text);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita actualizada exitosamente.");

                    CargarDatos();
                    Limpieza();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cita: " + ex.Message);
                }
            }
        }



    }
}
