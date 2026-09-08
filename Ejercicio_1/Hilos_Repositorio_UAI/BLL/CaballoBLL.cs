using System;
using System.Threading;
using System.Windows.Forms;
using BE;

namespace BLL
{
    /// <summary>
    /// Capa de Lógica de Negocio (BLL) para Caballo.
    /// NO POSEE ATRIBUTOS. Únicamente contiene métodos de negocio y procesamiento multihilo.
    /// </summary>
    public class CaballoBLL
    {
        /// <summary>
        /// Ejecuta la carrera individual del caballo en un Hilo secundario.
        /// Mide tiempos con Environment.TickCount y actualiza UI mediante Invoke.
        /// </summary>
        public void CorrerCaballo(CaballoBE caballo, Control parentForm, Action<int> onProgress, Action<string> onStatus)
        {
            // -------------------------------------------------------------
            // CONCEPTO 1: Environment.TickCount
            // Marca de tiempo inicial en milisegundos desde el arranque del SO.
            // -------------------------------------------------------------
            int inicioTick = Environment.TickCount;

            // Actualización segura de interfaz
            if (parentForm.IsHandleCreated)
            {
                parentForm.Invoke(new Action(() =>
                {
                    onProgress(0);
                    onStatus($"{caballo.Nombre}: Corriendo ({caballo.Prioridad})...");
                }));
            }

            // Recorrido de 100 metros/pasos
            for (int i = 1; i <= 100; i++)
            {
                HacerTrabajoSimuladoCPU();
                caballo.Posicion = i;

                if (parentForm.IsHandleCreated)
                {
                    int pasoActual = i;
                    parentForm.Invoke(new Action(() =>
                    {
                        onProgress(pasoActual);
                    }));
                }
            }

            // -------------------------------------------------------------
            // CONCEPTO 1 (Cálculo de Duración):
            // Duración en milisegundos = TickCount final - TickCount inicial
            // -------------------------------------------------------------
            caballo.TiempoTranscurridoMs = Environment.TickCount - inicioTick;
            caballo.Estado = "Llegó a la meta";

            if (parentForm.IsHandleCreated)
            {
                parentForm.Invoke(new Action(() =>
                {
                    onStatus($"¡LLEGÓ! Tiempo: {caballo.TiempoTranscurridoMs} ms");
                }));
            }
        }

        private void HacerTrabajoSimuladoCPU()
        {
            // Carga de trabajo intensiva en CPU.
            // Al hacer procesamiento real en CPU en lugar de estar dormido (Thread.Sleep largo),
            // el planificador del SO le otorgará más ráfagas de tiempo al hilo con ThreadPriority.Highest.
            double dummy = 0;
            for (int j = 0; j < 2_000_000; j++)
            {
                dummy += Math.Sqrt(j);
            }

            // Pausa mínima de 1ms para ceder el turno y no congelar la máquina
            Thread.Sleep(1);
        }
    }
}
