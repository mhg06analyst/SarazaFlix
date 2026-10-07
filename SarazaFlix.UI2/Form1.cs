using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SarazaFlix.BLL;
using SarazaFlix.Domain;

namespace SarazaFlix.UI2
{
    public partial class Form1 : Form
    {
        private readonly PlataformaService _servicio;
        private List<Usuario> _usuariosDePrueba;
        private List<Contenido> _contenidosDePrueba;

        public Form1()
        {
            InitializeComponent();
            _servicio = new PlataformaService();
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            // Creamos usuarios con distintos planes para someter a prueba el Protection Proxy
            _usuariosDePrueba = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Maximiliano", Plan = PlanSuscripcion.Basico },
                new Usuario { Id = 2, Nombre = "Lucía", Plan = PlanSuscripcion.Estandar },
                new Usuario { Id = 3, Nombre = "Roberto", Plan = PlanSuscripcion.Premium }
            };

            // Creamos contenidos con diferentes restricciones de plan
            _contenidosDePrueba = new List<Contenido>
            {
                new Contenido { Id = 101, Titulo = "Documental C# WinForms", PlanRequerido = PlanSuscripcion.Basico },
                new Contenido { Id = 102, Titulo = "Serie Patrones de Diseño", PlanRequerido = PlanSuscripcion.Estandar },
                new Contenido { Id = 103, Titulo = "Película Arquitectura en Capas", PlanRequerido = PlanSuscripcion.Premium }
            };

            // Vinculamos los datos a la interfaz gráfica
            cmbUsuarios.DataSource = _usuariosDePrueba;
            cmbUsuarios.DisplayMember = "Nombre";

            cmbContenidos.DataSource = _contenidosDePrueba;
            cmbContenidos.DisplayMember = "Titulo";
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            // 1. Extraemos el estado de la UI
            Usuario usuarioSeleccionado = (Usuario)cmbUsuarios.SelectedItem;
            Contenido contenidoSeleccionado = (Contenido)cmbContenidos.SelectedItem;
            int velocidad = (int)numVelocidad.Value;
            bool ahorroDatos = chkAhorroDatos.Checked;

            // 2. Ejecutamos la lógica central a través de la fachada
            string resultado = _servicio.ReproducirContenido(usuarioSeleccionado, contenidoSeleccionado, velocidad, ahorroDatos);

            // 3. Imprimimos el resultado en nuestra consola visual
            lstConsola.Items.Add($"[{DateTime.Now:HH:mm:ss}] {resultado}");
            lstConsola.TopIndex = lstConsola.Items.Count - 1; // Auto-scroll
        }

        private void btnExportarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                _servicio.ExportarListado(_usuariosDePrueba, "usuarios_exportados.csv");
                MessageBox.Show("Usuarios exportados a 'usuarios_exportados.csv' en la carpeta bin/Debug.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarContenidos_Click(object sender, EventArgs e)
        {
            try
            {
                _servicio.ExportarListado(_usuariosDePrueba, @"C:\Users\Outlet VL\Desktop\Facu\usuarios_exportados.csv");
                MessageBox.Show("Contenidos exportados a 'contenidos_exportados.csv' en la carpeta C:\\Users\\Outlet VL\\Desktop\\Facu\\usuarios_exportados.csv", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
