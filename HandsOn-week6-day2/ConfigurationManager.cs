using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem5
{
    internal class ConfigurationManager
    {
        // 1. Static instance (only one object)
        private static ConfigurationManager instance;

        // 2. Lock object for thread safety (optional but good practice)
        private static readonly object lockObj = new object();

        // 3. Properties
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }

        // 4. Private Constructor (prevents object creation)
        private ConfigurationManager()
        {
            // Initialize default values
            ApplicationName = "Inventory System";
            Version = "1.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
        }

        // 5. GetInstance Method
        public static ConfigurationManager GetInstance()
        {
            // Thread-safe Singleton
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
            }
            return instance;
        }
    }
}
