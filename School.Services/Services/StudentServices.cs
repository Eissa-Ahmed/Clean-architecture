namespace School.Services.Services;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    public StudentServices(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentEntity> CreateAsync(StudentEntity student)
    {
        var result = await _studentRepository.AddAsync(student);
        return result;
    }
}
