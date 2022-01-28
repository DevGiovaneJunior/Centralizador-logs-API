using LogElasticAPI.Domain.Entities;
using LogElasticAPI.Domain.Interfaces;
using LogElasticAPI.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LogElasticAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private IBaseService<Log> _baseService;
        public LogController(IBaseService<Log> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        [Route("Add/")]
        public IActionResult Create([FromBody]Log log)
        {
            if (log == null)
                return BadRequest();

            return Execute(() => _baseService.Add<LogValidator>(log).ApplicationName);
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
