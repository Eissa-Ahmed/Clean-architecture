namespace School.Infrastructure.Repository
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
