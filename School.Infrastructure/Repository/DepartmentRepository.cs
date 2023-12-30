namespace School.Infrastructure.Repository;

public class DepartmentRepository : BaseRepository<DepartmentEntity>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
