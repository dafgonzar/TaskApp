using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;
using TaskApp.Core.QueryFilters;

namespace TaskApp.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TbTask>> GetAllTasks(TaskQueryFilter filter);
    }
}
