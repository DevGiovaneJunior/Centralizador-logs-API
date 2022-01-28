using FluentValidation;
using LogElasticAPI.Domain.Entities;
using LogElasticAPI.Domain.Interfaces;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        //public void Delete(string id) => _baseRepository.Delete(id);

        //public IList<TEntity> Get() => _baseRepository.Select();

        //public TEntity GetById(string id) => _baseRepository.Select(id);

        //public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        //{
        //    Validate(obj, Activator.CreateInstance<TValidator>());
        //    _baseRepository.Update(obj);
        //    return obj;
        //}




        //public LoggerService(ILogger<LoggerService> logger, IElasticClient elasticClient)
        //{
        //    _logger = logger;
        //    _elasticClient = elasticClient;
        //}
        //public async Task<string> LogInformation(Log request)
        //{
        //    var response = (dynamic)null;
        //    try
        //    {
        //        var date = DateTime.UtcNow;
        //        using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        //        using (LogContext.PushProperty("LogMessage", request.Message))
        //        using (LogContext.PushProperty("Date", date))
        //        {
        //            await Task.Run(() => _logger.LogInformation($"Log Level: Information ApplicationName:{request.ApplicationName} LogMessage:{request.Message} Data: {date}"));
        //            response = await _elasticClient.IndexAsync<LoggerRequest>(request, x => x.Index("giovane-index"));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return response.Index;
        //}

        //public async Task LogWarning(LoggerRequest request)
        //{
        //    var response = (dynamic)null;
        //    var date = DateTime.UtcNow;
        //    using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        //    using (LogContext.PushProperty("LogMessage", request.Message))
        //    using (LogContext.PushProperty("Date", date))
        //    {
        //        await Task.Run(() => _logger.LogInformation($"Log Level: Warning ApplicationName:{request.ApplicationName} LogMessage:{request.Message} Data: {date}"));
        //        response = await _elasticClient.IndexAsync<LoggerRequest>(request, x => x.Index("giovane-index"));
        //    }
        //}

        //public async Task LogError(LoggerRequest request)
        //{
        //    var response = (dynamic)null;
        //    var date = DateTime.UtcNow;
        //    using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
        //    using (LogContext.PushProperty("LogMessage", request.Message))
        //    using (LogContext.PushProperty("InnerMessage", request.InnerMessage))
        //    using (LogContext.PushProperty("StackMessage", request.Stacktrace))
        //    using (LogContext.PushProperty("Date", date))
        //    {
        //        await Task.Run(() => _logger.LogInformation($"Log Level: Error ApplicationName:{request.ApplicationName} LogMessage:{request.Message} Data: {date}" +
        //            $" InnerMessage:{request.InnerMessage} StackTrace:{request.Stacktrace}"));
        //        response = await _elasticClient.IndexAsync<LoggerRequest>(request, x => x.Index("giovane-index"));
        //    }
        //}
    }
}
