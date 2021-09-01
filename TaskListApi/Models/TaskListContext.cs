using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaskListApi.Models
{
    public partial class TaskListContext : DbContext
    {
        public TaskListContext()
        {
        }

        public TaskListContext(DbContextOptions<TaskListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskList> TaskLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("TaskListConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.ToTable("Task_List");

                entity.Property(e => e.TaskListId)
                    .ValueGeneratedNever()
                    .HasColumnName("Task_List_Id");

                entity.Property(e => e.AssigneeName)
                    .HasMaxLength(50)
                    .HasColumnName("Assignee_Name");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.TaskListDetails)
                    .HasMaxLength(4000)
                    .HasColumnName("Task_List_Details");

                entity.Property(e => e.TaskListTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Task_List_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
