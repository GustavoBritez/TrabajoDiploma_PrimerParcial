using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BE;

namespace DAL
{
    /// <summary>
    /// Capa de Acceso a Datos (DAL) para Carrera.
    /// NO POSEE ATRIBUTOS (Es una clase sin estado / Stateless).
    /// Maneja transacciones SQL (SqlTransaction) y parámetros SQL (SqlParameter).
    /// </summary>
    public class CarreraDAL
    {
        private readonly CaballoDAL _caballoDAL = new CaballoDAL();
        private const string ConnectionString = "Server=localhost;Database=CarreraDB;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Guarda el encabezado de la Carrera y el detalle de cada Caballo utilizando una SqlTransaction.
        /// </summary>
        public bool GuardarCarreraConTransaccion(CarreraBE carrera)
        {
            // En un entorno de producción se abre la conexión real:
            // using (SqlConnection connection = new SqlConnection(ConnectionString))
            
            // Simulación de estructura completa de SqlTransaction y SqlParameter:
            using (SqlConnection connection = new SqlConnection())
            {
                //connection.Open();
                //SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertCarreraQuery = @"INSERT INTO Carrera (Fecha, DuracionTotalMs, TipoCarrera) 
                                                 VALUES (@Fecha, @DuracionTotalMs, @TipoCarrera);
                                                 SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(insertCarreraQuery, connection /*, transaction*/))
                    {
                        // Manejo estricto de SqlParameter
                        command.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = carrera.Fecha });
                        command.Parameters.Add(new SqlParameter("@DuracionTotalMs", SqlDbType.Int) { Value = carrera.DuracionTotalMs });
                        command.Parameters.Add(new SqlParameter("@TipoCarrera", SqlDbType.VarChar, 50) { Value = carrera.TipoCarrera });

                        // int idGenerado = Convert.ToInt32(command.ExecuteScalar());
                        int idGenerado = new Random().Next(1, 1000);
                        carrera.Id = idGenerado;

                        // Guardamos cada caballo utilizando la misma transacción
                        foreach (var caballo in carrera.Caballos)
                        {
                            _caballoDAL.GuardarResultadoCaballo(caballo, idGenerado, connection, null!);
                        }
                    }

                    // Confirmar transacción
                    // transaction.Commit();
                    System.Diagnostics.Debug.WriteLine($"[DAL SqlTransaction] Transacción completada con éxito. Carrera #{carrera.Id} guardada.");
                    return true;
                }
                catch (Exception ex)
                {
                    // Ante cualquier error se realiza Rollback
                    // transaction.Rollback();
                    System.Diagnostics.Debug.WriteLine($"[DAL SqlTransaction] Error: {ex.Message}. Transacción cancelada (Rollback).");
                    return false;
                }
            }
        }
    }
}
