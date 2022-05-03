using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace CitasMedicas
{
    public partial class Form1 : Form
    {

        BDConnect bd = new BDConnect("Server=192.168.100.162;Database=CitasDB;User Id=sa;Password=0525;");
        CitasDBEntities _db = new CitasDBEntities();
        Citas objeto = new Citas();

        public Form1()
        {
            InitializeComponent();
            CitaCalendar.MaxSelectionCount = 1;
            ControlPaneles.SelectTab(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlPaneles.SelectTab(1);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PanelInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'citasDBDataSet.Citas' Puede moverla o quitarla según sea necesario.
            this.citasTableAdapter.Fill(this.citasDBDataSet.Citas);

        }

        private void ButtSaveCita_Click(object sender, EventArgs e)
        {
            try
            {
                objeto.FechaCita = CitaCalendar.SelectionRange.Start;
                objeto.NombreCita = textTipo.Text;
                objeto.NombreDoctor = textDoctor.Text;
                objeto.NombrePaciente = textPacient.Text;
                objeto.PrecioCita = decimal.Parse(textPrecio.Text);

                _db.Citas.Add(objeto);
                _db.SaveChanges();


                OperacionRealizada(ConexionLabel, true);

                Limpieza.Clean(textTipo, textDoctor, textPacient, textPrecio);
            }
            catch (Exception)
            {
                OperacionRealizada(ConexionLabel, false);
            }

            
        }

        public void limpiarTextsSave()
        {
            
        }

        private void PanelAdd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            objeto.idCita = int.Parse(textIDEdit.Text);
            objeto.FechaCita = CalendarioEdit.SelectionRange.Start;
            objeto.NombreCita = textNombreEdit.Text;
            objeto.NombreDoctor = textDoctorEdit.Text;
            objeto.NombrePaciente = textPacientEdit.Text;
            objeto.PrecioCita = decimal.Parse(textPrecioEdit.Text);

            _db.Entry(objeto).State = EntityState.Modified;
            _db.SaveChanges();
        }

        private void ButtBuscar_Click(object sender, EventArgs e)
        {
            GroupEdit.Enabled = true;
            objeto = _db.Citas.Find(int.Parse(textIDEdit.Text));

            textDoctorEdit.Text = objeto.NombreDoctor;
            textNombreEdit.Text = objeto.NombreCita;
            textPacientEdit.Text = objeto.NombrePaciente;
            textPrecioEdit.Text = objeto.PrecioCita.ToString();
            CalendarioEdit.SetDate((DateTime)objeto.FechaCita);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            ControlPaneles.SelectTab(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroupDelete.Enabled = true;
            objeto = _db.Citas.Find(int.Parse(textIdDelete.Text));

            labelCitaDelete.Text = "Tipo de Cita: " +  objeto.NombreCita;
            labelPacientDelete.Text = "Nombre Paciente: " + objeto.NombrePaciente;
            labelFechaDelete.Text = "Fecha de la Cita: " + objeto.FechaCita.ToShortDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControlPaneles.SelectTab(3);
        }

        private void OperacionRealizada(Label label, bool correct)
        {
            if(correct)
            {
                label.Text = $"Solicitud realizada = {correct}";
                label.BackColor = Color.Green;
            }
            else
            {
                label.Text = $"Solicitud realizada = {correct}";
                label.BackColor = Color.Red;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(textIdDelete.Text, out id))
            {
                var delete = _db.Citas.Find(id);
                _db.Citas.Remove(delete);
                _db.SaveChanges();
                GroupDelete.Enabled = false;

                Limpieza.Clean(textIdDelete);
                Limpieza.Clean(labelCitaDelete, labelFechaDelete, labelPacientDelete);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _db.Citas.Load();
            GridViewCitas.DataSource = _db.Citas.Local.ToBindingList();
            ControlPaneles.SelectTab(4);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPaneles.SelectTab(1);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPaneles.SelectTab(2);
        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
