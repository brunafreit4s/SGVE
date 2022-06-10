using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SGVE_api
{
    public class ConnectionMySql
    {
        private MySqlConnection cn = new MySqlConnection("Server=127.0.0.1;Database=SGVEC;UID=root;PWD=root123");

        public DataSet ExecuteQuery(int TypeCommand, string CommandText, params MySqlParameter[] oParametro)
        {
            try
            {
                cn.Open();

                if (cn != null)
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(CommandText, cn);

                    if (TypeCommand == 1) da.SelectCommand.CommandType = CommandType.Text;
                    else da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.CommandText = CommandText;

                    foreach (MySqlParameter item in oParametro)
                    {
                        if ((item.Direction == ParameterDirection.InputOutput) && (item.Value == null))
                        {
                            item.Value = DBNull.Value;
                        }

                        da.SelectCommand.Parameters.Add(item);
                    }

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    da.Dispose();
                    return ds;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
    }
}
