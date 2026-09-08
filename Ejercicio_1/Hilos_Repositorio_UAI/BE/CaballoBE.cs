using System;
using System.Threading;

namespace BE
{
    /// <summary>
    /// Entidad de Negocio (BE) para representar un Caballo.
    /// Contiene ÚNICAMENTE atributos y propiedades de datos.
    /// </summary>
    public class CaballoBE
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public ThreadPriority Prioridad { get; set; } = ThreadPriority.Normal;
        public int TiempoTranscurridoMs { get; set; }
        public int Posicion { get; set; }
        public string Estado { get; set; } = "Listo";

        public CaballoBE()
        {
        }

        public CaballoBE(int id, string nombre, ThreadPriority prioridad)
        {
            Id = id;
            Nombre = nombre;
            Prioridad = prioridad;
        }
    }
}
