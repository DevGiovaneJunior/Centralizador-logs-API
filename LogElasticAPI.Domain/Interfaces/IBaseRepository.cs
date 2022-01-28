using LogElasticAPI.Domain.Entities;
using System.Collections.Generic;

namespace LogElasticAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        //void Update(TEntity obj);

        //void Delete(string id);

        //IList<TEntity> Select();

        //TEntity Select(string id);
    }
}
