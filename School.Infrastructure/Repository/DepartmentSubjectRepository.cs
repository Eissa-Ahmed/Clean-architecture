namespace School.Infrastructure.Repository;

public class DepartmentSubjectRepository : BaseRepository<DepartmentSubjectEntity>, IDepartmentSubjectRepository
{
    public DepartmentSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
