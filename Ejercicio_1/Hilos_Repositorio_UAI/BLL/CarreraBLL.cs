using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa de Lógica de Negocio (BLL) para Carrera.
    /// NO POSEE ATRIBUTOS. Únicamente contiene métodos de coordinación y reglas de negocio.
    /// </summary>
    public class CarreraBLL
    {
        private readonly CaballoBLL _caballoBLL = new CaballoBLL();
        private readonly CarreraDAL _carreraDAL = new CarreraDAL();

        // =========================================================================
        // MODO 1: Threads (ta, tb, tc, td) con ThreadPriority (Highest, Lowest, etc.)
        // =========================================================================
        public void IniciarCarreraConThreads(CarreraBE carrera, Control parentForm, Action<int, int> updateProgressUI, Action<int, string> updateStatusUI, Action<string> logUI)
        {
            logUI("=== [BLL] INICIANDO CARRERA CON THREADS (ta, tb, tc, td) ===");
            carrera.TipoCarrera = "Threads";

            if (carrera.Caballos.Count < 4)
            {
                logUI("Error BLL: Se requieren 4 caballos para iniciar la carrera.");
                return;
            }

            // ---------------------------------------------------------------------
            // CONCEPTO 2: Instanciación de hilos ta, tb, tc, td
            // ---------------------------------------------------------------------
            Thread ta = new Thread(() => _caballoBLL.CorrerCaballo(carrera.Caballos[0], parentForm, p => updateProgressUI(0, p), s => updateStatusUI(0, s)));
            Thread tb = new Thread(() => _caballoBLL.CorrerCaballo(carrera.Caballos[1], parentForm, p => updateProgressUI(1, p), s => updateStatusUI(1, s)));
            Thread tc = new Thread(() => _caballoBLL.CorrerCaballo(carrera.Caballos[2], parentForm, p => updateProgressUI(2, p), s => updateStatusUI(2, s)));
            Thread td = new Thread(() => _caballoBLL.CorrerCaballo(carrera.Caballos[3], parentForm, p => updateProgressUI(3, p), s => updateStatusUI(3, s)));

            ta.Name = "Hilo_Caballo_A";
            tb.Name = "Hilo_Caballo_B";
            tc.Name = "Hilo_Caballo_C";
            td.Name = "Hilo_Caballo_D";

            // ---------------------------------------------------------------------
            // CONCEPTO 3: ThreadPriority (Highest y Lowest y sus variantes)
            // ---------------------------------------------------------------------
            ta.Priority = carrera.Caballos[0].Prioridad; // ThreadPriority.Highest
            tb.Priority = carrera.Caballos[1].Prioridad; // ThreadPriority.AboveNormal
            tc.Priority = carrera.Caballos[2].Prioridad; // ThreadPriority.BelowNormal
            td.Priority = carrera.Caballos[3].Prioridad; // ThreadPriority.Lowest

            logUI($"Prioridades configuradas:");
            logUI($" - {carrera.Caballos[0].Nombre}: {ta.Priority}");
            logUI($" - {carrera.Caballos[1].Nombre}: {tb.Priority}");
            logUI($" - {carrera.Caballos[2].Nombre}: {tc.Priority}");
            logUI($" - {carrera.Caballos[3].Nombre}: {td.Priority}");

            // ---------------------------------------------------------------------
            // CONCEPTO 1: Environment.TickCount para marcar inicio global
            // ---------------------------------------------------------------------
            int inicioCarreraTick = Environment.TickCount;

            // ---------------------------------------------------------------------
            // CONCEPTO 2 (Start): Lanzamos la ejecución en paralelo
            // ---------------------------------------------------------------------
            ta.Start();
            tb.Start();
            tc.Start();
            td.Start();

            // Hilo supervisor para aguardar la llegada de los 4 hilos sin congelar la UI
            Thread supervisor = new Thread(() =>
            {
                ta.Join();
                tb.Join();
                tc.Join();
                td.Join();

                carrera.DuracionTotalMs = Environment.TickCount - inicioCarreraTick;

                // Persistencia a través de la DAL con SqlTransaction
                _carreraDAL.GuardarCarreraConTransaccion(carrera);

                if (parentForm.IsHandleCreated)
                {
                    parentForm.Invoke(new Action(() =>
                    {
                        logUI($"¡CARRERA FINALIZADA! Duración Total: {carrera.DuracionTotalMs} ms");
                    }));
                }
            });
            supervisor.Start();
        }

        // =========================================================================
        // MODO 2: Uso de Task.WaitAll(new Task[] { taskA, taskB, taskC, taskD })
        // =========================================================================
        public void IniciarCarreraConTasksWaitAll(CarreraBE carrera, Control parentForm, Action<int, int> updateProgressUI, Action<int, string> updateStatusUI, Action<string> logUI)
        {
            logUI("=== [BLL] INICIANDO CARRERA CON TASK.WAITALL ===");
            carrera.TipoCarrera = "Tasks";

            int inicioCarreraTick = Environment.TickCount;

            Task.Run(() =>
            {
                // -----------------------------------------------------------------
                // CONCEPTO 4: Task.WaitAll(new Task[] { taskA, taskB, taskC, taskD })
                // -----------------------------------------------------------------
                Task taskA = Task.Run(() => _caballoBLL.CorrerCaballo(carrera.Caballos[0], parentForm, p => updateProgressUI(0, p), s => updateStatusUI(0, s)));
                Task taskB = Task.Run(() => _caballoBLL.CorrerCaballo(carrera.Caballos[1], parentForm, p => updateProgressUI(1, p), s => updateStatusUI(1, s)));
                Task taskC = Task.Run(() => _caballoBLL.CorrerCaballo(carrera.Caballos[2], parentForm, p => updateProgressUI(2, p), s => updateStatusUI(2, s)));
                Task taskD = Task.Run(() => _caballoBLL.CorrerCaballo(carrera.Caballos[3], parentForm, p => updateProgressUI(3, p), s => updateStatusUI(3, s)));

                // Bloquea el hilo actual HASTA QUE TODAS LAS TASKS TERMINEN
                Task.WaitAll(new Task[] { taskA, taskB, taskC, taskD });

                carrera.DuracionTotalMs = Environment.TickCount - inicioCarreraTick;

                // Persistencia a través de la DAL con SqlTransaction
                _carreraDAL.GuardarCarreraConTransaccion(carrera);

                if (parentForm.IsHandleCreated)
                {
                    parentForm.Invoke(new Action(() =>
                    {
                        logUI($"¡CARRERA CON TASK.WAITALL FINALIZADA! Duración Total: {carrera.DuracionTotalMs} ms");
                    }));
                }
            });
        }
    }
}
