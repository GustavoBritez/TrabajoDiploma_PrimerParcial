using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BE;

namespace DAL
{
    /// <summary>
    /// Capa de Acceso a Datos (DAL) para Caballo.
    /// NO POSEE ATRIBUTOS (Es una clase sin estado / Stateless).
    /// Contiene exclusivamente métodos de persistencia con SqlParameter y SqlTransaction.
    /// </summary>
    public class CaballoDAL
    {
        /// <summary>
        /// Guarda el resultado individual de un caballo dentro de una transacción SQL compartida.
        /// </summary>
        public void GuardarResultadoCaballo(CaballoBE caballo, int idCarrera, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"INSERT INTO ResultadoCaballo (IdCarrera, NombreCaballo, Prioridad, TiempoMs, PosicionFinal) 
                             VALUES (@IdCarrera, @NombreCaballo, @Prioridad, @TiempoMs, @PosicionFinal)";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                // Configuración explícita con SqlParams
                command.Parameters.Add(new SqlParameter("@IdCarrera", SqlDbType.Int) { Value = idCarrera });
                command.Parameters.Add(new SqlParameter("@NombreCaballo", SqlDbType.VarChar, 100) { Value = caballo.Nombre });
                command.Parameters.Add(new SqlParameter("@Prioridad", SqlDbType.VarChar, 50) { Value = caballo.Prioridad.ToString() });
                command.Parameters.Add(new SqlParameter("@TiempoMs", SqlDbType.Int) { Value = caballo.TiempoTranscurridoMs });
                command.Parameters.Add(new SqlParameter("@PosicionFinal", SqlDbType.Int) { Value = caballo.Posicion });

                // Nota: En una BD real conectada, se ejecutaría: command.ExecuteNonQuery();
                // Simulación para fines educativos de la arquitectura:
                System.Diagnostics.Debug.WriteLine($"[DAL SQL Param] Insertado caballo {caballo.Nombre} en Carrera #{idCarrera} con Transacción.");
            }
        }
    }
}
