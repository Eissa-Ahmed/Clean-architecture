namespace School.Services.Services.IServices;

public interface IStudentServices
{
    public Task<StudentEntity> CreateAsync(StudentEntity student);
    public Task<List<StudentEntity>> GetAllAsync();
}
