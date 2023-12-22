namespace School.Infrastructure.DataAccessLayer;

public class ApplicationDbContext : DbContext
{
    //public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //new DepartmentConfiguration(modelBuilder.Entity<DepartmentEntity>());
        //new StudentConfiguration(modelBuilder.Entity<StudentEntity>());
        //modelBuilder.ApplyConfiguration(new DepartmentConfiguration(modelBuilder.Entity<DepartmentEntity>()));
        //modelBuilder.ApplyConfiguration(new StudentConfiguration(modelBuilder.Entity<StudentEntity>()));
        //modelBuilder.ApplyConfiguration(new SubjectConfiguration(modelBuilder.Entity<SubjectEntity>()));
        //modelBuilder.ApplyConfiguration(new DepartmentSubjectConfiguration(modelBuilder.Entity<DepartmentSubjectEntity>()));
        //modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration(modelBuilder.Entity<StudentSubjectEntity>()));
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<DepartmentSubjectEntity> DepartmentSubjects { get; set; }
    public DbSet<StudentSubjectEntity> StudentSubjects { get; set; }

}
