namespace School.Services.Services.IServices;

public interface IStudentServices
{
    public Task<StudentEntity> CreateAsync(StudentEntity student);
    public Task<List<StudentEntity>> GetAllAsync();
    public Task<StudentEntity> GetByIdAsync();
    public Task<string> UpdateAsync(StudentEntity student);
    public Task<string> DeleteAsync(int id);
    public bool NameIsExist(string name);
    public bool NameIsExistExceptForHimself(string name, int id);
    public Task<(StudentEntity, List<SubjectEntity>)> AssignSubjectsToStudent(List<int> subjects, int id);
    public Task<string> DeleteSubjectsFromStudent(List<int> subjects, int id);
    public Task<string> AssignStudentToDepartment(int IdStudent, int IdDepartment);
    public Task<string> DeleteStudentFromDepartment(int IdStudent);
    public Task<List<SubjectEntity>> GetAllSubjectForStudent(int IdStudent);
    public bool StudentExist(int Id);
    public bool StudentExistInDepartment(int Id);
}
