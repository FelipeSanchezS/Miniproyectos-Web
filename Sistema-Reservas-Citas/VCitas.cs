using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace clinicaApp
{
    public partial class VCitas : Form
    {
        public VCitas()
        {
            InitializeComponent();
            this.Load += new EventHandler(VCitas_Load);
        }

        // Al iniciar el formulario no se necesita cargar nada
        private void VCitas_Load(object sender, EventArgs e)
        {
            // Ya no se cargan ComboBox, se ingresan valores manuales
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=reservas;uid=root;pwd=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Base de la consulta sin filtro de fecha aún
                string query = @"
                SELECT 
                    Cita.id AS ID,
                    CONCAT(Paciente.nombre, ' ', Paciente.apellido) AS Paciente,
                    Medico.nombre AS Medico,
                    Especialidad.nombre AS Especialidad,
                    Cita.fecha_cita AS Fecha,
                    Cita.hora AS Hora,
                    Cita.motivo AS Motivo,
                    Cita.estado AS Estado
                FROM Cita
                    INNER JOIN Paciente ON Cita.id_paciente = Paciente.id
                    INNER JOIN Medico ON Cita.id_medico = Medico.id
                    INNER JOIN Especialidad ON Medico.especialidad_id = Especialidad.id
                WHERE
                    (Paciente.nombre LIKE @paciente OR @paciente = '')
                    AND (Medico.nombre LIKE @medico OR @medico = '')";

                // Si el usuario escribió una fecha válida, agregarla al WHERE
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    if (DateTime.TryParse(textBox3.Text.Trim(), out DateTime fecha))
                    {
                        query += " AND Cita.fecha_cita = @fecha";
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese una fecha válida en formato yyyy-MM-dd.");
                        return;
                    }
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@paciente", "%" + textBox2.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@medico", "%" + textBox1.Text.Trim() + "%");

                if (!string.IsNullOrWhiteSpace(textBox3.Text) && DateTime.TryParse(textBox3.Text.Trim(), out DateTime fechaFinal))
                {
                    cmd.Parameters.AddWithValue("@fecha", fechaFinal.Date);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario3 = new Form1();
            this.Hide(); // Oculta la ventana actual
            formulario3.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario3.Show();
        }
    }
}
