
namespace School.Infrastructure.Repository
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<StudentEntity> GetByIdAsync(int id)
        {
            var student = await _dbContext.Students.Where(i => i.Id.Equals(id)).Include(i => i.StudentSubjectEntity).Include(i => i.DepartmentEntity).ThenInclude(i => i.DepartmentSubjectEntity).FirstOrDefaultAsync();
            return student;
        }
        public override async Task UpdateAsync(StudentEntity entity)
        {
            _dbContext.Students.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
