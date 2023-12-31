﻿using System;
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
            if (filter.FinishStatus != null) 
            {
                tasks = tasks.Where(x => x.FinishStatus == filter.FinishStatus);
            }
            return tasks;
        }

        public async Task<bool> Insert (TbTask task)
        {
            return await _taskRepository.Insert(task);
        }

        public async Task<bool> Update(TbTask task)
        {
            return await _taskRepository.Update(task);
        }
        public async Task<bool> Delete(int Id)
        {
            return await _taskRepository.Delete(Id);
        }

        public async Task<TbTask> Get(int Id)
        {
            return await _taskRepository.Get(Id);
        }

    }
}
