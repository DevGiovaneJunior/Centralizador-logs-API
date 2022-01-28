using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual string Id { get; set; }
    }
}
