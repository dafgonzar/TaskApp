using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Entities;

namespace TaskApp.Infrastructure.Data.Configurations
{
    class TaskConfigurations : IEntityTypeConfiguration<TbTask>
    {
        public void Configure(EntityTypeBuilder<TbTask> entity) 
        { 
            entity.HasKey(x => x.TaskId);
            entity.ToTable("Task");

            entity.Property(e => e.Accion)
                .IsRequired()
                .HasColumnName("Accion")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FinishStatus)
                .HasColumnType("Bit")
                .HasColumnName("FinishStatus");
        }
    }
}
