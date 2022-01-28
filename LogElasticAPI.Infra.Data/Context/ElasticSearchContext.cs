using LogElasticAPI.Domain.Entities;
using LogElasticAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LogElasticAPI.Infra.Data.Context
{
    public class ElasticSearchContext : DbContext
    {
        IConfiguration _configuration;
        public ElasticSearchContext(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("ElastUrl");
        }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Log>(new LogMap().Configure);
        }

    }
}
