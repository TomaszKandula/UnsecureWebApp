# Unsecure WebApp

This NET Core application (using Razor Pages and EF Core) has been created for the article _SQL Injection_ published on Medium.com. Its purpose is only to show what SQL injection is and what not to do in your code, __ever__.

## Database connection

In our example, instead of ADO.NET, we use EF Core that can send raw SQL string for execution. Thus, to run this example, add a connection string to settings:

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

## End note

The presented application is not by any means application to follow in dealing with SQL and databases. More in a related article. For a clearer picture, check the opposite application example.
