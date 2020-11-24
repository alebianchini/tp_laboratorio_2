using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PedidosDB
    {
        static SqlConnection sqlConnection;
        static string connectionString;

        /// <summary>
        /// Constructor estático, establece el connectionString y la sqlConnection con la Base de datos.
        /// </summary>
        static PedidosDB()
        {
            connectionString = "Server=localhost\\SQLEXPRESS;Database=Mensajeria;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Inserta un PedidoEntregado en la tabla de PedidosEntregados de la Base de Datos.
        /// </summary>
        /// <param name="auxPedido"></param>
        public static void AgregarPedidoDB(PedidoConfirmado auxPedido)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"INSERT INTO PedidosEntregados(Codigo, PrecioFinal, Delivery, Direccion) VALUES(@Codigo, @PrecioFinal, @Delivery, @Direccion)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Codigo", auxPedido.Codigo);
                sqlCommand.Parameters.AddWithValue("PrecioFinal", Convert.ToSingle(auxPedido.PrecioFinal));
                sqlCommand.Parameters.AddWithValue("Delivery", auxPedido.Delivery);
                sqlCommand.Parameters.AddWithValue("Direccion", auxPedido.Direccion);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void AgregarPendienteDB(PedidoConfirmado auxPedido)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"INSERT INTO PedidosPendientes(Codigo, PrecioFinal, Delivery, Direccion) VALUES(@Codigo, @PrecioFinal, @Delivery, @Direccion)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Codigo", auxPedido.Codigo);
                sqlCommand.Parameters.AddWithValue("PrecioFinal", Convert.ToSingle(auxPedido.PrecioFinal));
                sqlCommand.Parameters.AddWithValue("Delivery", auxPedido.Delivery);
                sqlCommand.Parameters.AddWithValue("Direccion", auxPedido.Direccion);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        ///// <summary>
        ///// Actualiza el stock de un Alimento en particular de la Tabla de Alimentos de la base de datos
        ///// </summary>
        ///// <param name="alimento">Alimento a actualizar</param>
        //public static void BorrarPendienteDB(PedidoConfirmado auxPedido)
        //{
        //    try
        //    {
        //        if (!(sqlConnection.State == System.Data.ConnectionState.Open))
        //        {
        //            sqlConnection.Open();
        //        }
        //        string command = $"DELETE PedidosPendientes WHERE ID = @Id";
        //        SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
        //        sqlCommand.Parameters.AddWithValue("Stock", alimento.Stock);
        //        sqlCommand.Parameters.AddWithValue("Id", alimento.Id);
        //        sqlCommand.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}
    }
}
