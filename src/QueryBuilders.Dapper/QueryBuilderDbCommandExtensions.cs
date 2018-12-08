// WARNING
// This file is auto generated.
// Please edit the code generator (.tt) file instead.

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using QueryBuilders.Interfaces;

using static Dapper.SqlMapper;

namespace QueryBuilders.Dapper
{
    public static class QueryBuilderDbCommandExtensions
    {
        public static int Execute(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Execute(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<int> ExecuteAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IDataReader ExecuteReader(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteReader(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IDataReader> ExecuteReaderAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteReaderAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object ExecuteScalar(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteScalar(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static T ExecuteScalar<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteScalar<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> ExecuteScalarAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteScalarAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<T> ExecuteScalarAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.ExecuteScalarAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type[] types, 
            Func<Object[], TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TReturn>(
                sql: sql, 
                types: types, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<object> Query(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<T> Query<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<object> Query(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TThird, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TThird, TFourth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<object>> QueryAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<T>> QueryAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<object>> QueryAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TThird, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                sql: sql, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<IEnumerable<TReturn>> QueryAsync<TReturn>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type[] types, 
            Func<Object[], TReturn> map, 
            IDbTransaction transaction = null, 
            bool buffered = true, 
            string splitOn = "Id", 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryAsync<TReturn>(
                sql: sql, 
                types: types, 
                map: map, 
                param: param, 
                transaction: transaction, 
                buffered: buffered, 
                splitOn: splitOn, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QueryFirst(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirst(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static T QueryFirst<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirst<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QueryFirst(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirst(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<T> QueryFirstAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QueryFirstAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QueryFirstAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstAsync(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QueryFirstOrDefault(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefault(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static T QueryFirstOrDefault<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefault<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QueryFirstOrDefault(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefault(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<T> QueryFirstOrDefaultAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefaultAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QueryFirstOrDefaultAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefaultAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QueryFirstOrDefaultAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryFirstOrDefaultAsync(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static GridReader QueryMultiple(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryMultiple(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<GridReader> QueryMultipleAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QueryMultipleAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QuerySingle(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingle(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static T QuerySingle<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingle<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QuerySingle(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingle(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<T> QuerySingleAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QuerySingleAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QuerySingleAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleAsync(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QuerySingleOrDefault(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefault(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static T QuerySingleOrDefault<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefault<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static object QuerySingleOrDefault(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefault(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<T> QuerySingleOrDefaultAsync<T>(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefaultAsync<T>(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QuerySingleOrDefaultAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefaultAsync(
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

        public static Task<object> QuerySingleOrDefaultAsync(
            this IDbConnection cnn,
            IQueryBuilder qb, 
            Type type, 
            IDbTransaction transaction = null, 
            int? commandTimeout = null, 
            CommandType? commandType = null
        )
        {
            var sql = qb.BuildQuery();
            var param = qb.GetParameterDictionary();
            return cnn.QuerySingleOrDefaultAsync(
                type: type, 
                sql: sql, 
                param: param, 
                transaction: transaction, 
                commandTimeout: commandTimeout, 
                commandType: commandType
            );
        }

    }
}
