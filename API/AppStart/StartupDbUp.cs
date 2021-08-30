using DbUp;
using DbUp.Engine;
using Serilog;
using System.IO;

namespace API.AppStart
{
    public static class StartupDbUp
    {
        public static void Configure(string connectionString, ILogger logger)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            string path = Directory.GetCurrentDirectory();

            UpgradeEngine dbUpgradeEngine = DeployChanges
                .To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem($"{path}\\DbupScripts")
                .LogToAutodetectedLog()
                .Build();

            var result = dbUpgradeEngine.PerformUpgrade();

            if (!result.Successful)
            {
                logger.Error(result.Error.StackTrace);
            }

            logger.Information("Success!");
        }
    }
}
