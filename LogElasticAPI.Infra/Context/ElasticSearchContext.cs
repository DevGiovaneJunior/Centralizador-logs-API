using LogElasticAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Infra.Data.Context
{
    public class ElasticSearchContext : DbContext
    {
        IConfiguration _configuration;
        public ElasticSearchContext(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("ElastUrl");
        }


    }
}
