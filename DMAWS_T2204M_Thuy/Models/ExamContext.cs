using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2204M_Thuy.Models
{
    public partial class ExamContext : DbContext
    {
        public ExamContext() { }
        public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
