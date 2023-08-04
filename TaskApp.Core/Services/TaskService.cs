using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces;
using TaskApp.Core.QueryFilters;

namespace TaskApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService() { }
        public TaskService(ITaskRepository taskRepository) 
        { 
            _taskRepository= taskRepository;
        }
        public async Task<IEnumerable<TbTask>> GetAllTasks(TaskQueryFilter filter)
        {
            var tasks = await _taskRepository.GetAllTasks();
            if (filter.Accion != null)
            {
                tasks = tasks.Where(x => x.Accion.Contains(filter.Accion)); 
            }
            return tasks;
        }
    }
}
