using System;
using System.Text;
using QueryBuilders.Builders;

namespace QueryBuilders.TestCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleTest();
            Console.ReadLine();
        }

        private static void SimpleTest()
        {
            var qb = new SelectQueryBuilder();
            var sb = new StringBuilder();
            qb.AddField("1");
            qb.BuildInto(sb);
            var str = sb.ToString();
            Console.WriteLine(str);
        }
    }
}
