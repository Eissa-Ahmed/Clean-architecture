namespace School.Infrastructure.Repository;

public class StudentSubjectRepository : BaseRepository<StudentSubjectEntity>, IStudentSubjectRepository
{
    public StudentSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
