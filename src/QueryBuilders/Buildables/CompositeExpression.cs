using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using QueryBuilders.Builders;
using QueryBuilders.Models;
using QueryBuilders.Services;

namespace QueryBuilders.Buildables
{

    public class CompositeExpression : IBuildable
    {
        public bool IsEmpty => Entries.All(e => e.Buildable.IsEmpty);

        private IParameterList ParameterList { get; }
        public QueryLogicOperator DefaultChildrenOperator { get; }
        public IList<ICompositeEntry<IBuildable>> Entries { get; }

        public CompositeExpression(IParameterList parameterList, QueryLogicOperator defaultChildrenOperator = QueryLogicOperator.And)
        {
            ParameterList = parameterList;
            DefaultChildrenOperator = defaultChildrenOperator;
            Entries = new List<ICompositeEntry<IBuildable>>();
        }

        [StringFormatMethod("statement")]
        public StringExpression Add(string statement, params object[] parameters)
        {
            var stringExpression = new StringExpression(ParameterList, statement, parameters);
            var compositeEntry = new CompositeEntry<StringExpression>(stringExpression);
            Entries.Add(compositeEntry);
            return stringExpression;
        }

        public void AddEqualsObject(string field, object value, bool ignoreIfNull = true)
        {
            if (value == null)
            {
                if (ignoreIfNull)
                {
                    return;
                }
                else
                {
                    AddIsNull(field);
                }
            }
            Add(field + " = {0}", value);
        }

        public void AddIsNull(string field)
        {
            Add(field + " IS NULL");
        }

        public void AddLike(string field, string likeValue, bool caseInsensitive = true, bool ignoreIfNull = true)
        {
            if (ignoreIfNull && string.IsNullOrEmpty(likeValue))
            {
                return;
            }
            var likeWord = caseInsensitive ? "ILIKE" : "LIKE";
            var value = '%' + likeValue + '%';
            Add(field + ' ' + likeWord + " {0}", value);
        }

        public void AddAny<T>(string field, IList<T> values, bool ignoreIfNull = true, bool unnest = false, bool useIn = false)
        {
            if (ignoreIfNull && values == null)
            {
                return;
            }
            if (!unnest && useIn)
            {
                throw new ArgumentException("Must unnest when using IN statement.", nameof(unnest));
            }
            if (!unnest || values.Count == 0)
            {
                Add(field + " = ANY({0})", values);
                return;
            }
            var sb = new StringBuilder();
            sb.Append(field);
            sb.Append(useIn ? " IN (" : " = ANY(array[");
            for (var i = 0; i < values.Count; i++)
            {
                sb.Append("{");
                sb.Append(i);
                sb.Append("}");
                if (i != values.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(useIn ? ")" : "])");
            var str = sb.ToString();
            var valuesArr = values.Cast<object>().ToArray();
            Add(str, valuesArr);
        }

        public CompositeExpression AddGroup(QueryLogicOperator op)
        {
            var innerExpression = new CompositeExpression(ParameterList, op);
            var compositeEntry = new CompositeEntry<CompositeExpression>(innerExpression);
            compositeEntry.AddParentheses = true;
            Entries.Add(compositeEntry);
            return innerExpression;
        }

        public SelectQueryBuilder AddSelect(string table = null)
        {
            var selectQueryBuilder = new SelectQueryBuilder();
            selectQueryBuilder.ParameterList = ParameterList;
            selectQueryBuilder.AddFrom(table);
            var compositeEntry = new CompositeEntry<SelectQueryBuilder>(selectQueryBuilder);
            compositeEntry.AddParentheses = true;
            Entries.Add(compositeEntry);
            return selectQueryBuilder;
        }

        private string QueryLogicOperatorToString(QueryLogicOperator op)
        {
            string operatorStr;
            switch (op)
            {
                case QueryLogicOperator.And:
                    operatorStr = "AND";
                    break;
                case QueryLogicOperator.Or:
                    operatorStr = "OR";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(DefaultChildrenOperator), DefaultChildrenOperator, null);
            }
            return operatorStr;
        }

        public virtual void BuildInto(StringBuilder builder)
        {
            var defaultOperatorStr = QueryLogicOperatorToString(DefaultChildrenOperator);
            var nonEmptyEntries = Entries.Where(e => !e.Buildable.IsEmpty).ToList();
            for (var i = 0; i < nonEmptyEntries.Count; i++)
            {
                var entry = nonEmptyEntries[i];
                if (i != 0)
                {
                    var forcedOperatorStr = entry.ForcedOperator.HasValue ? QueryLogicOperatorToString(entry.ForcedOperator.Value) : null;
                    var operatorStr = forcedOperatorStr ?? defaultOperatorStr;
                    builder.Append(operatorStr);
                    builder.Append(' ');
                }
                if (entry.AddParentheses)
                {
                    builder.Append('(');
                }
                entry.Buildable.BuildInto(builder);
                if (entry.AddParentheses)
                {
                    builder.Append(')');
                }
                if (i < nonEmptyEntries.Count - 1)
                {
                    builder.Append(' ');
                }
            }
        }
    }
}