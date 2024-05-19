using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Student_The_Standard.Models.Students;
using STX.EFxceptions.SqlServer;
using System.Threading.Tasks;

namespace Student_The_Standard.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        private async ValueTask<T> InsertAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);

            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return @object;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString("ApplicationConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
