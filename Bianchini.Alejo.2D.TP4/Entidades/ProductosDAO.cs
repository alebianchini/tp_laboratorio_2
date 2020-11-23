using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ProductosDAO
    {
        static SqlConnection sqlConnection;
        static string connectionString;

        /// <summary>
        /// Constructor estático, establece el connectionString y la sqlConnection con la Base de datos.
        /// </summary>
        static ProductosDAO()
        {
            connectionString = "Server=localhost\\SQLEXPRESS;Database=ProductosDB;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Obtiene la lista de Alimentos guardada en la Base de datos.
        /// </summary>
        /// <returns>Retorna la lista encontrada</returns>
        public static List<Alimento> ObtenerListaAlimentos()
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = "SELECT * FROM Alimentos";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Alimento> lista = new List<Alimento>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string descripción = reader["Nombre"].ToString();
                    int stock = (int)reader["Stock"];
                    double precioU = Convert.ToDouble(reader["PrecioUnit"]);
                    string tipoAux = reader["Tipo"].ToString();

                    Alimento alimento = new Alimento(id, descripción, stock, precioU, tipoAux);
                    lista.Add(alimento);
                }

                return lista;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene la lista de Indumentaria guardada en la Base de datos.
        /// </summary>
        /// <returns>Retorna la lista encontrada</returns>
        public static List<Indumentaria> ObtenerListaIndumentaria()
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = "SELECT * FROM Indumentaria";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Indumentaria> lista = new List<Indumentaria>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string descripción = reader["Nombre"].ToString();
                    int stock = (int)reader["Stock"];
                    string color = reader["Color"].ToString();
                    double precioU = Convert.ToDouble(reader["PrecioUnit"]);
                    string talleAux = reader["Talle"].ToString();

                    Indumentaria indumentaria = new Indumentaria(id, descripción, stock, color, precioU, talleAux);
                    lista.Add(indumentaria);
                }

                return lista;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Inserta un Alimento en la tabla de Alimentos de la Base de Datos.
        /// </summary>
        /// <param name="alimento"></param>
        public static void AgregarAlimentoDB(Alimento alimento)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"INSERT INTO Alimentos(Nombre, Stock, PrecioUnit, Tipo) VALUES(@Nombre, @Stock, @PrecioUnit, @Tipo)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Nombre", alimento.Descripcion);
                sqlCommand.Parameters.AddWithValue("Stock", alimento.Stock);
                sqlCommand.Parameters.AddWithValue("PrecioUnit", Convert.ToSingle(alimento.PrecioUnitario));
                sqlCommand.Parameters.AddWithValue("Tipo", alimento.Tipo.ToString());
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

        /// <summary>
        /// Inserta una Indumentaria en la tabla de Indumentaria de la Base de Datos.
        /// </summary>
        /// <param name="prenda"></param>
        public static void AgregarIndumentariaDB(Indumentaria prenda)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"INSERT INTO Indumentaria(Nombre, Color, Stock, PrecioUnit, Talle) VALUES(@Nombre, @Color, @Stock, @PrecioUnit, @Talle)";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Nombre", prenda.Descripcion);
                sqlCommand.Parameters.AddWithValue("Color", prenda.Color);
                sqlCommand.Parameters.AddWithValue("Stock", prenda.Stock);
                sqlCommand.Parameters.AddWithValue("PrecioUnit", Convert.ToSingle(prenda.PrecioUnitario));
                sqlCommand.Parameters.AddWithValue("Talle", prenda.Talle.ToString());
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

        /// <summary>
        /// Actualiza el stock de un Alimento en particular de la Tabla de Alimentos de la base de datos
        /// </summary>
        /// <param name="alimento">Alimento a actualizar</param>
        public static void ActualizarStockAlimentoDB(Alimento alimento)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"UPDATE Alimentos SET Stock = @Stock WHERE ID = @Id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Stock", alimento.Stock);
                sqlCommand.Parameters.AddWithValue("Id", alimento.Id);
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

        /// <summary>
        /// Actualiza el stock de una Indumentaria en particular de la Tabla de Indumentaria de la base de datos
        /// </summary>
        /// <param name="prenda">Indumentaria a actualizar</param>
        public static void ActualizarStockIndumentariaDB(Indumentaria prenda)
        {
            try
            {
                if (!(sqlConnection.State == System.Data.ConnectionState.Open))
                {
                    sqlConnection.Open();
                }
                string command = $"UPDATE Indumentaria SET Stock = @Stock WHERE ID = @Id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Stock", prenda.Stock);
                sqlCommand.Parameters.AddWithValue("Id", prenda.Id);
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
    }
}
