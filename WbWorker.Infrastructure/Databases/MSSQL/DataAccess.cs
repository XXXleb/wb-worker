using Microsoft.Data.SqlClient;
using System.Data;

namespace WbWorker.Infrastructure.Databases.MSSQL;

public class DataAccess : IDataAccess
{
	private readonly DatabaseCredential _credential;

	public DataAccess(DatabaseCredential databaseCredential)
	{
		_credential = databaseCredential;
	}

	public async Task<DataSet> ExecProcedure(string command, params SqlParameter[] param)
	{
		DataSet ds = new();
		using (SqlConnection connection = new(_credential.ConnectionString))
		{
			SqlCommand sqlCommand = new(command, connection) { CommandType = CommandType.StoredProcedure };

			if (param != null)
			{
				sqlCommand.Parameters.AddRange(param);
			}

			SqlDataAdapter da = new(sqlCommand);
			connection.Open();
			da.Fill(ds);
			connection.Close();
		}
		return ds;
	}
}
