# Unsecure WebApp

This NET Core application (with Razor Pages and EF Core) that has been created for article _SQL Injection_ published on Medium.com. Its purpose is to only show what SQL injection is, and what not to do in your code, __ever__.

# Database connection

In our example, instead of ADO.NET, we use EF Core that have ability to send raw SQL string for execution. Thus, in order to run this example:

I. Add connection string to your User Secrets:

```
{
  
  "ConnectionStrings": 
  {
    "DbConnect": "<your_connection_string_goes_here>"
  }

}
```

II. Run SQL script to add example tables with some data: SqlScripts/CreateTables.sql. This is because I have already scaffolded my database example and this would be the fastest thing to do.

# End note

This is not by any means application to follow in terms of dealing with SQL and databases. More in related article. For clearer picture, there will be opposite application available soon.
