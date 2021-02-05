namespace UnsecureWebApp.Services.ConnectionService
{
    public interface IConnectionService
    {
        /// <summary>
        /// Returns connection string for "ExampleAppDb" database.
        /// </summary>
        /// <returns></returns>
        string GetExampleDatabase();
    }
}
