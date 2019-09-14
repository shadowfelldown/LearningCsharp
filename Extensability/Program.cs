using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensability
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DBMigrator(new FileLogger("C:\\Projects\\log.txt"));
            dbMigrator.Migrate();

        }
    }
}
