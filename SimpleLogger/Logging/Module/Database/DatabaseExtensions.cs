using System;
using System.Data;

namespace SimpleLogger.Logging.Module.Database
{
    internal static class DatabaseExtensions
    {
        internal static void ExecuteMultipleNonQuery(this IDbCommand dbCommand)
        {
            var sqlStatementArray = dbCommand.CommandText
                                             .Split(new[] { ";" },
                                                    StringSplitOptions.RemoveEmptyEntries);

            foreach (string sqlStatement in sqlStatementArray)
            {
                dbCommand.CommandText = sqlStatement;
                dbCommand.ExecuteNonQuery();
            }
        }
    }
}
