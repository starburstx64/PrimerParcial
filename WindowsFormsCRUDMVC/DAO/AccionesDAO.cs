using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

using WindowsFormsCRUDMVC.DTO;
using System.Windows.Forms;

namespace WindowsFormsCRUDMVC.DAO
{
    class AccionesDAO
    {
        private MySqlConnection connection;

        public AccionesDAO()
        {
            connection = Connection.Instance.SqlConnection;
        }

        public DataSet SelectAll()
        {
            var output = new DataSet();

            try
            {
                connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select * from acciones;", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.Fill(output);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
            return output;
        }

        public void Insert(Acciones acciones)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "accionInsert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_id", acciones.Id);
                cmd.Parameters["@_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_fecha", acciones.Fecha);
                cmd.Parameters["@_fecha"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_precioAccion", acciones.PrecioAccion);
                cmd.Parameters["@_precioAccion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_dineroInvertido", acciones.DineroInvertido);
                cmd.Parameters["@_dineroInvertido"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_accionesOperadas", acciones.AccionesOperadas);
                cmd.Parameters["@_accionesOperadas"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        public void Update(Acciones acciones)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "accionUpdate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_id", acciones.Id);
                cmd.Parameters["@_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_fecha", acciones.Fecha);
                cmd.Parameters["@_fecha"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_precioAccion", acciones.PrecioAccion);
                cmd.Parameters["@_precioAccion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_dineroInvertido", acciones.DineroInvertido);
                cmd.Parameters["@_dineroInvertido"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_accionesOperadas", acciones.AccionesOperadas);
                cmd.Parameters["@_accionesOperadas"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        public void Delete(int id)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "accionDeleteByID";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_id", id);
                cmd.Parameters["@_id"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }
    }
}
