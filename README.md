# QueryBuilders.NET
SQL query builders for the .NET framework

### Example

```csharp
string region = "RJ";
string city = "Rio de Janeiro";
bool readReportsTo = true;

SelectQueryBuilder builder = new SelectQueryBuilder();
builder.AddFrom("orders");
builder.AddField("orders.orderid");
builder.AddField("orders.customerid");
builder.AddField("orders.employeeid");
builder.Where.Add("orders.shipregion = {0}", region);
builder.Where.AddEqualsObject("orders.shipcity", city);
builder.AddOrderBy("orders.orderid", true);
if (readReportsTo)
{
    builder.AddJoin("employees").On.Add("orders.employeeid = employees.employeeid");
    builder.AddField("employees.reportsto");
}
Console.WriteLine(builder);
// SELECT orders.orderid, orders.customerid, orders.employeeid, employees.reportsto
// FROM orders
// INNER JOIN employees ON orders.employeeid = employees.employeeid
// WHERE orders.shipregion = @p_0 AND orders.shipcity = @p_1
// ORDER BY orders.orderid ASC

using (IDbCommand command = connection.CreateCommand())
{
    // Sets the CommandText property, as well as values for p_0 and p_1 parameters
    builder.PrepareDbCommand(command);
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            // Read rows...
        }
    }
}

// Also integrates with Dapper using the QueryBuildersDotNet.Dapper package
var results = connection.Query(builder);
```