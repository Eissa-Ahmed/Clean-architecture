using Microsoft.EntityFrameworkCore;

namespace School.Services.Services;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ISubjectRepository _subjectRepository;
    public StudentServices(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, ISubjectRepository subjectRepository)
    {
        _studentRepository = studentRepository;
        _departmentRepository = departmentRepository;
        _subjectRepository = subjectRepository;
    }

    public async Task<string> AssignStudentToDepartment(int IdStudent, int IdDepartment)
    {
        try
        {
            var department = await _departmentRepository.GetByIdAsync(IdDepartment);
            var student = await _studentRepository.GetByIdAsync(IdStudent);

            student.DepartmentEntity = department;
            await _studentRepository.UpdateAsync(student);

            return "Success";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<(StudentEntity, List<SubjectEntity>)> AssignSubjectsToStudent(List<int> subjects, int id)
    {
        try
        {
            var student = await _studentRepository.GetByIdAsync(id);
            List<StudentSubjectEntity> StudentSubjectEntity = new();
            List<SubjectEntity> subjectEntity = new();
            foreach (var subjectId in subjects)
            {
                StudentSubjectEntity.Add(new StudentSubjectEntity() { SubjectId = subjectId });
                var subject = await _subjectRepository.GetTableNoTracking().FirstOrDefaultAsync(i => i.Id.Equals(subjectId));
                subjectEntity.Add(subject);
            }
            student.StudentSubjectEntity = StudentSubjectEntity;
            await _studentRepository.UpdateAsync(student);
            return (student, subjectEntity);
        }
        catch (DbUpdateException ex)
        {
            throw ex;
        }
    }

    public async Task<StudentEntity> CreateAsync(StudentEntity student)
    {
        var result = await _studentRepository.AddAsync(student);
        return result;
    }

    public Task<string> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteStudentFromDepartment(int IdStudent, int IdDepartment)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteSubjectsFromStudent(List<int> subjects, int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentEntity> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public bool NameIsExist(string name)
    {
        throw new NotImplementedException();
    }

    public bool NameIsExistExceptForHimself(string name, int id)
    {
        throw new NotImplementedException();
    }

    public bool StudentExist(int Id)
    {
        var student = _studentRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
        return student is null ? false : true;
    }

    public bool StudentExistInDepartment(int Id)
    {
        var student = _studentRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
        if (student is null)
            return false;

        return student.DepartmentId is null ? false : true;
    }

    public Task<string> UpdateAsync(StudentEntity student)
    {
        throw new NotImplementedException();
    }
}
