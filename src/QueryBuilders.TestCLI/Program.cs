using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using QueryBuilders.Builders;
using QueryBuilders.Models;

namespace QueryBuilders.TestCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleTest();
            ReadOrderEmployees(null, "Rio de Janeiro", true);
            Console.ReadLine();
        }

        private static void SimpleTest()
        {
            var qb = new SelectQueryBuilder();
            qb.AddField("1");
            Console.WriteLine(qb);
        }

        private static void ReadOrderEmployees(IDbConnection connection, string city, bool readReportsTo)
        {
            //string city = "Rio de Janeiro";

            SelectQueryBuilder builder = new SelectQueryBuilder();
            builder.AddFrom("orders");
            builder.AddField("orders.orderid");
            builder.AddField("orders.customerid");
            builder.AddField("orders.employeeid");
            builder.Where.Add("orders.shipregion = {0}", "RJ");
            builder.Where.AddEqualsObject("orders.shipcity", city);
            builder.AddOrderBy("orders.orderid", true);
            if (readReportsTo)
            {
                builder.AddJoin("employees").On.Add("orders.employeeid = employees.employeeid");
                builder.AddField("employees.reportsto");
            }
            Console.WriteLine(builder);

            /*using (IDbCommand command = connection.CreateCommand())
            {
                builder.PrepareDbCommand(command);
            }*/
        }
    }
}
