using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using Dapper;
using QueryBuilders.Interfaces;

namespace QueryBuilders.Dapper
{
    public static class QueryBuilderDapperExtensions
    {
        public static IDictionary<string, object> GetParameterDictionary(this IQueryBuilder queryBuilder)
        {
            return queryBuilder.ParameterList.ToDictionary(param => param.Key, param => param.Value.Value);
        }

        public static CommandDefinition GetCommandDefinition(
            this IQueryBuilder queryBuilder,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CommandFlags flags = CommandFlags.Buffered,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = queryBuilder.BuildQuery();
            var parameters = queryBuilder.GetParameterDictionary();
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                transaction: transaction,
                commandTimeout: commandTimeout,
                commandType: commandType,
                flags: flags,
                cancellationToken: cancellationToken);
            return commandDefinition;
        }
    }
}
