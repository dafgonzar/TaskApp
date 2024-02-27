using TaskApp.Core.Entities;
using TaskApp.Core.QueryFilters;

namespace TaskApp.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TbTask>> GetAllTasks(TaskQueryFilter filter);
        Task<bool> Insert(TbTask task);
        Task<TbTask> Get(int Id);
        Task<bool> Update(TbTask task);
        Task<bool> Delete(int Id);


    }
}
