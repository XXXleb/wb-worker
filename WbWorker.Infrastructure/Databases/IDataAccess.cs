using Microsoft.Data.SqlClient;
using System.Data;

namespace WbWorker.Infrastructure.Databases;

public interface IDataAccess
{
    public Task<DataSet> ExecProcedure(string command, params SqlParameter[] param);
}
