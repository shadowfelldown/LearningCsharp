using System;

namespace Extensability
{
    public class DBMigrator
    {
        private readonly ILogger logger;

        public DBMigrator(ILogger logger)
        {
            this.logger = logger;
        }
        public void Migrate()
        {
            this.logger.LogInfo("Migrating started at" + DateTime.Now);

            // Details of migrating the database

            this.logger.LogInfo("Migrating finished at" + DateTime.Now);

        }
    }
}
