using Microsoft.Extensions.Configuration;

namespace UnsecureWebApp.Services.ConnectionService
{
    public sealed class ConnectionService : IConnectionService
    {
        private IConfiguration Configuration { get; }

        public ConnectionService(IConfiguration AConfiguration)
            => Configuration = AConfiguration;

        /// <summary>
        /// Returns connection string for "ExampleAppDb" database. 
        /// </summary>
        /// <returns></returns>
        public string GetExampleDatabase()
            => Configuration.GetConnectionString("DbConnect");

        // Add more databases as required here...
    }
}
