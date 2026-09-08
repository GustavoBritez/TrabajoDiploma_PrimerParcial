using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using BE;
using BLL;

namespace Ejercicio_1
{
    /// <summary>
    /// Capa de Presentación (UI / Windows Forms).
    /// Contiene ÚNICAMENTE la lógica de la interfaz de usuario.
    /// Interactúa con la BLL y utiliza las entidades BE.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly CarreraBLL _carreraBLL = new CarreraBLL();
        private CarreraBE _carreraBE = new CarreraBE();
        private List<ProgressBar> _progressBars = new List<ProgressBar>();
        private List<Label> _labelsEstado = new List<Label>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _progressBars = new List<ProgressBar> { pbCaballo1, pbCaballo2, pbCaballo3, pbCaballo4 };
            _labelsEstado = new List<Label> { lblEstado1, lblEstado2, lblEstado3, lblEstado4 };

            InicializarEntidadesCarrera();
        }

        private void InicializarEntidadesCarrera()
        {
            _carreraBE = new CarreraBE
            {
                Id = 1,
                Fecha = DateTime.Now,
                Caballos = new List<CaballoBE>
                {
                    new CaballoBE(1, "Caballo A (Rayo)", ThreadPriority.Highest),
                    new CaballoBE(2, "Caballo B (Tornado)", ThreadPriority.AboveNormal),
                    new CaballoBE(3, "Caballo C (Cometa)", ThreadPriority.BelowNormal),
                    new CaballoBE(4, "Caballo D (Trueno)", ThreadPriority.Lowest)
                }
            };
        }

        private void btnCarreraThreads_Click(object sender, EventArgs e)
        {
            btnCarreraThreads.Enabled = false;
            btnCarreraTasks.Enabled = false;
            InicializarEntidadesCarrera();

            _carreraBLL.IniciarCarreraConThreads(
                _carreraBE,
                this,
                ActualizarProgresoUI,
                ActualizarEstadoUI,
                LogMensaje
            );

            HabilitarBotonesDiferido();
        }

        private void btnCarreraTasks_Click(object sender, EventArgs e)
        {
            btnCarreraThreads.Enabled = false;
            btnCarreraTasks.Enabled = false;
            InicializarEntidadesCarrera();

            _carreraBLL.IniciarCarreraConTasksWaitAll(
                _carreraBE,
                this,
                ActualizarProgresoUI,
                ActualizarEstadoUI,
                LogMensaje
            );

            HabilitarBotonesDiferido();
        }

        private void ActualizarProgresoUI(int indiceCaballo, int valorProgreso)
        {
            if (indiceCaballo >= 0 && indiceCaballo < _progressBars.Count)
            {
                _progressBars[indiceCaballo].Value = valorProgreso;
            }
        }

        private void ActualizarEstadoUI(int indiceCaballo, string estado)
        {
            if (indiceCaballo >= 0 && indiceCaballo < _labelsEstado.Count)
            {
                _labelsEstado[indiceCaballo].Text = estado;
            }
        }

        private void LogMensaje(string mensaje)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => LogMensaje(mensaje)));
                return;
            }

            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {mensaje}\r\n");
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void HabilitarBotonesDiferido()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += (s, ev) =>
            {
                btnCarreraThreads.Enabled = true;
                btnCarreraTasks.Enabled = true;
                t.Stop();
            };
            t.Start();
        }
    }
}
