using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;
using TaskApp.Infrastructure.Data.Configurations;

namespace TaskApp.Infrastructure.Data
{
    public partial class TaskContext : DbContext
    {
        public TaskContext()
        {

        }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) 
        {            
        }

        public virtual DbSet<TbTask> tbTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfigurations());
        }

    }
}
