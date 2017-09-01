using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace QueryBuilders
{
    public class CompositeExpression : IBuildable
    {
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

        public void AddAny<T>(string field, IList<T> values, bool ignoreIfNull = true)
        {
            if (ignoreIfNull && values == null)
            {
                return;
            }
            Add(field + " = ANY({0})", values);
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
            var selectQueryBuilder = new SelectQueryBuilder(table, ParameterList);
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
            for (var i = 0; i < Entries.Count; i++)
            {
                var entry = Entries[i];
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
                if (i < Entries.Count - 1)
                {
                    builder.Append(' ');
                }
            }
        }
    }
}