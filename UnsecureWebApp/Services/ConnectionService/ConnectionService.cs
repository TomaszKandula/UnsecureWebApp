using Microsoft.Extensions.Configuration;

namespace UnsecureWebApp.Services.ConnectionService
{
    public sealed class ConnectionService : IConnectionService
    {
        private IConfiguration FConfiguration { get; }

        public ConnectionService(IConfiguration AConfiguration)
        {
            FConfiguration = AConfiguration;
        }

        /// <summary>
        /// Returns connection string for "ExampleAppDb" database. 
        /// </summary>
        /// <returns></returns>
        public string GetExampleDatabase()
        {
            return FConfiguration.GetConnectionString("DbConnect");
        }

        // Add more databases as required here...
    }
}
