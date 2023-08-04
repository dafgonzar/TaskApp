using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TbTask>> GetAllTasks();
        Task<bool> Insert(TbTask task);
        Task<TbTask> Get(int Id);
        Task<bool> Update(TbTask task);
        Task<bool> Delete(int Id);
    }
}
