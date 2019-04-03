using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilders.Models;

namespace QueryBuilders.Buildables
{
    public class ExplainStatement : IBuildable
    {
        public bool IsEmpty => false;

        public bool Explain { get; set; }
        public bool? Analyze { get; set; }
        public bool? Verbose { get; set; }
        public bool? Costs { get; set; }
        public bool? Buffers { get; set; }
        public bool? Timing { get; set; }
        public ExplainFormat? Format { get; set; }

        public void BuildInto(StringBuilder builder)
        {
            if (!Explain)
            {
                return;
            }

            builder.Append("EXPLAIN");

            var options = new List<string>();
            AddIfHasValue(options, "ANALYZE", Analyze);
            AddIfHasValue(options, "VERBOSE", Verbose);
            AddIfHasValue(options, "COSTS", Costs);
            AddIfHasValue(options, "BUFFERS", Buffers);
            AddIfHasValue(options, "TIMING", Timing);
            if (Format.HasValue)
            {
                switch (Format.Value)
                {
                    case ExplainFormat.Text:
                        options.Add("FORMAT TEXT");
                        break;
                    case ExplainFormat.Xml:
                        options.Add("FORMAT XML");
                        break;
                    case ExplainFormat.Json:
                        options.Add("FORMAT JSON");
                        break;
                    case ExplainFormat.Yaml:
                        options.Add("FORMAT YAML");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Format), Format.Value, null);
                }
            }

            if (options.Count == 0)
            {
                return;
            }

            builder.Append(" (");
            for (var i = 0; i < options.Count; i++)
            {
                builder.Append(options[i]);
                if (i != options.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(")");
        }

        private void AddIfHasValue(IList<string> options, string optionName, bool? option)
        {
            if (!option.HasValue)
            {
                return;
            }
            options.Add(optionName + " " + (option.Value ? "TRUE" : "FALSE"));
        }
    }
}