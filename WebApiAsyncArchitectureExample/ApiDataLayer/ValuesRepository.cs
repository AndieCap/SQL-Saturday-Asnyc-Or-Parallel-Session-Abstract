using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ApiDataLayer
{
  public class ValuesRepository
  {
    public static readonly string ConnectionString = @"Data Source=.\SQLSERVER2014;Initial Catalog=tempdb;Integrated Security=True";
    public static SqlConnection GetOpenConnection()
    {
      var connection = new SqlConnection(ConnectionString);
      connection.Open();
      return connection;
    }

    //Add Get Method
    public async Task<IEnumerable<string>> GetAsync()
    {
      using (var connection = GetOpenConnection())
      {
        return await connection.QueryAsync<string>("select 'abc' as [Value] union all select @txt", new { txt = "def" });
      }
    }
  }
}
