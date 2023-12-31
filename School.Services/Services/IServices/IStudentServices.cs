namespace School.Services.Services.IServices;

public interface IStudentServices
{
    public Task<StudentEntity> CreateAsync(StudentEntity student);
    public Task<List<StudentEntity>> GetAllAsync();
    public Task<StudentEntity> GetByIdAsync(Guid Id);
    public Task<string> UpdateAsync(StudentEntity student);
    public Task<string> DeleteAsync(Guid id);
    public Task<bool> NameIsExist(string name);
    public Task<bool> NameIsExistExceptForHimself(string name, Guid id);
    public Task<(StudentEntity, List<SubjectEntity>)> AssignSubjectsToStudent(List<Guid> subjects, Guid id);
    public Task<string> DeleteSubjectsFromStudent(List<Guid> subjects, Guid id);
    public Task<string> AssignStudentToDepartment(Guid IdStudent, Guid IdDepartment);
    public Task<string> DeleteStudentFromDepartment(Guid IdStudent);
    public Task<List<SubjectEntity>> GetAllSubjectForStudent(Guid IdStudent);
    public bool StudentExist(Guid Id);
    public bool StudentExistInDepartment(Guid Id);
    public bool StudentExistInStudent(List<Guid> subjectsId, Guid id);
}
