namespace School.Infrastructure.Repository;

public class SubjectRepository : BaseRepository<SubjectEntity>, ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
