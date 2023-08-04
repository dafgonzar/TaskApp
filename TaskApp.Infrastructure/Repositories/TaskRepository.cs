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

        public async Task<bool> Insert(TbTask task)
        {
            _context.Add(task);
            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }

        public async Task<TbTask> Get(int Id)
        {
            var task = await _context.tbTasks.FirstOrDefaultAsync(x => x.TaskId == Id);
            return (task);
        }

        public async Task<bool> Update(TbTask task)
        {
            var currentTask = await Get((int)task.TaskId);
            currentTask.Accion = task.Accion;
            currentTask.FinishStatus = task.FinishStatus;

            var regs = await _context.SaveChangesAsync();
            return (regs > 0);
        }
        public async Task<bool> Delete(int Id)
        {
            var currentTask = await Get(Id);
            _context.tbTasks.Remove(currentTask);
            var regs = await _context.SaveChangesAsync();

            return (regs > 0);
        }

    }
}
