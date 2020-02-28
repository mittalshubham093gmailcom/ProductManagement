using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Connection
{
    public class DBOperations
    {

        private readonly IConnectSQL _connectSQL;
        public DBOperations(IConnectSQL connectSQL) {
            _connectSQL = connectSQL;
        }
        //private SqlConnection connection = new SqlConnection();
        public bool SqlOperationToAddAndDelete(string table, string proc, SqlParameter[] parameter)
        {
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            try
            {
                
                using (SqlConnection connection = new SqlConnection(_connectSQL.GetConnectionString()))
                {
                    ad = new SqlDataAdapter();
                    cmd = new SqlCommand(proc, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameter);
                    ad.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    ad.Fill(ds, table);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally {
                if (ad != null) {
                    ad.Dispose();
                }
                if (cmd != null) {
                    cmd.Dispose();
                    if (cmd.Parameters != null)
                    {
                        cmd.Parameters.Clear();
                    }
                }
            }
        }
        public DataTable SqlOperationToGetData(string proc, SqlParameter[] parameter = null)
        {
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectSQL.GetConnectionString()))
                {
                    ad = new SqlDataAdapter();
                    cmd = new SqlCommand(proc, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameter != null)
                    {
                        cmd.Parameters.AddRange(parameter);
                    }
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (ad != null)
                {
                    ad.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    if (cmd.Parameters != null)
                    {
                        cmd.Parameters.Clear();
                    }
                }
            }
        }
    }
}
