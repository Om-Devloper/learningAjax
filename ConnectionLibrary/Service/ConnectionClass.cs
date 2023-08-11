using ConnectionLibrary.Config;
using ConnectionLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConnectionLibrary.Service
{
    public class ConnectionClass : IConnectionClass
    {
        private readonly SqlConnection _connection;
        public ConnectionClass()
        {
            _connection = new SqlConnection(AppSettings.ConnectionStrings.Db);
            _connection.Open();
        }

        public DataTable Select(string strQuery)
        {
            var dt = new DataTable();
            try
            {
            
                if (ConnectionState.Closed == _connection.State)
                {
                    _connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(strQuery, _connection))
                {
                    var adapter = new SqlDataAdapter(cmd);
                    cmd.CommandTimeout = 999999;
                    adapter.Fill(dt);
                    
                }
                return dt;
            }
            catch (Exception ex)
            {
                _connection.Close();
                //LogManager.LogManager.ErrorInformation($"Method : Select cause Exception : {ex.Message} and Query is {strQuery}");
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public int Insert(string strQuery)
        {
            try
            {
                if (ConnectionState.Closed == _connection.State)
                {
                    _connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(strQuery, _connection))
                {
                    cmd.CommandTimeout = 99999;
                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
            catch (Exception ex)
            {
                //LogManager.LogManager.ErrorInformation($"Method : Insert cause Exception : {ex.Message}");
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool Update(string strQuery)
        {
            try
            {
                if (ConnectionState.Closed == _connection.State)
                {
                    _connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(strQuery, _connection))
                {
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                //LogManager.LogManager.ErrorInformation($"Method : Update cause Exception : {ex.Message}");
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
