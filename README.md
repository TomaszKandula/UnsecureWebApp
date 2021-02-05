# Unsecure WebApp

This NET Core application (using Razor Pages and EF Core) has been created for article _SQL Injection_ published on Medium.com. Its purpose is to only show what SQL injection is, and what not to do in your code, __ever__.

# Database connection

In our example, instead of ADO.NET, we use EF Core that have ability to send raw SQL string for execution. Thus, in order to run this example, add connection string to settings:

```
{  
  "ConnectionStrings": 
  {
    "DbConnect": "<your_connection_string_goes_here>"
  }
}
```

Open Package Manager Console (PMC) and execute following command:

`Update-Database -StartupProject UnsecureWebApp -Project UnsecureWebApp -Context DatabaseContext`

Please make sure your connection string points to example database that have user with those permissions:

1. db_datareader,
1. db_datawriter,
1. db_owner.

# End note

This is not by any means application to follow in terms of dealing with SQL and databases. More in related article. For clearer picture, check opposite application example.
