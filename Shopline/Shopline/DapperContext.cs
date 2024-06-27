using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DapperContext : IDisposable
{
    private readonly IDbConnection _dbConnection;

    public DapperContext()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        _dbConnection = new SqlConnection(connectionString);
    }

    public IDbConnection GetConnection()
    {
        if (_dbConnection.State != ConnectionState.Open)
        {
            _dbConnection.Open();
        }
        return _dbConnection;
    }

    public void Dispose()
    {
        if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
        {
            _dbConnection.Close();
        }
    }
}
