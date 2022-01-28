using LogElasticAPI.Domain.Entities;
using LogElasticAPI.Domain.Interfaces;
using LogElasticAPI.Infra.Data.Context;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<Log> where TEntity : BaseEntity
    {
        private IElasticClient _elasticClient;

        public BaseRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public void Insert(Log obj)
        {
            var response = _elasticClient.IndexAsync<Log>(obj, x => x.Index("centralizador-log"));
        }

        //public void Update(TEntity obj)
        //{
        //    _elasticSearchContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    _elasticSearchContext.SaveChanges();
        //}

        //public void Delete(string id)
        //{
        //    _elasticSearchContext.Set<TEntity>().Remove(Select(id));
        //    _elasticSearchContext.SaveChanges();
        //}

        //public IList<TEntity> Select() =>
        //    _elasticSearchContext.Set<TEntity>().ToList();

        //public TEntity Select(string id) =>
        //    _elasticSearchContext.Set<TEntity>().Find(id);

    }
}
