using System;
using System.Collections.Generic;

namespace BE
{
    /// <summary>
    /// Entidad de Negocio (BE) para representar una Carrera.
    /// Contiene ÚNICAMENTE atributos y propiedades de datos.
    /// </summary>
    public class CarreraBE
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int DuracionTotalMs { get; set; }
        public string TipoCarrera { get; set; } = "Threads"; // "Threads" o "Tasks"
        public List<CaballoBE> Caballos { get; set; } = new List<CaballoBE>();
        public CaballoBE? Ganador { get; set; }

        public CarreraBE()
        {
        }

        public CarreraBE(int id, string tipoCarrera)
        {
            Id = id;
            TipoCarrera = tipoCarrera;
        }
    }
}
