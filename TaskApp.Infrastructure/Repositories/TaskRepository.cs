using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;
        public TaskRepository() { }

        public TaskRepository(TaskContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<TbTask>> GetAllTasks() 
        {
            var tasks = await _context.tbTasks.ToListAsync();
            return tasks;
        
        }

    }
}
