using System;
using System.Reflection;

using DbUp;

namespace DBI
{
    internal class Program
    {
        private static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Profiles;Trusted_Connection=True;";
            UpdateDatabase(connectionString);
        }

        public static void UpdateDatabase(string connectionString) {
            EnsureDatabase.For.SqlDatabase(connectionString); //Creates database if not exist

            var upgradeEngineBuilder = DeployChanges.To
                            .SqlDatabase(connectionString, null)
                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                            .WithTransaction()
                            .LogToConsole();

            var upgrader = upgradeEngineBuilder.Build();
            if (upgrader.IsUpgradeRequired()) {
                var result = upgrader.PerformUpgrade();
                if (!result.Successful) {
                    Console.Out.WriteLine("Failed to upgrade database");
                }
            }
        }
    }
}
