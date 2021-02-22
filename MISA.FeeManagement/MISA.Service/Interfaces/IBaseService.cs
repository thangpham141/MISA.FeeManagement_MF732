using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        ServiceResult GetData();
        ServiceResult Post(TEntity entity);
        ServiceResult Delete(string entityId);
        ServiceResult Put(TEntity entity, string entityCode = null);
    }
}
