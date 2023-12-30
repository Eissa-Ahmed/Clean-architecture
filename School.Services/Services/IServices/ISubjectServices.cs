namespace School.Services.Services.IServices;

public interface ISubjectServices
{
    public bool SubjectExist(int Id);
    public Task<bool> SubjectExistInDepartmentOfStudent(List<int> ListOfIdSubject, int IdStudent);
}
