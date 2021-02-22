using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FeeManagement.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<TEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<TEntity> _baseService;
        #endregion
        #region CONTRUCTOR
        public BasesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion
        #region METHODS
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseService.GetData();
            var datas = (List<TEntity>)result.Data;
            if (datas.Count == 0)
            {
                return StatusCode(204, result.Data);
            }

            return StatusCode(200, result.Data);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _baseService.Post(entity);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }
        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity, [FromQuery] string entityCode = null)
        {
            var result = _baseService.Put(entity, entityCode);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] string entityId)
        {
            var result = _baseService.Delete(entityId);
            if ((int)result.Data > 0)
                return StatusCode(200, result.Data);
            return StatusCode(204, result.Data);
        }
        #endregion
    }
}
