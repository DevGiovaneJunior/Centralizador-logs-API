using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string Stacktrace { get; set; }
    }
}
