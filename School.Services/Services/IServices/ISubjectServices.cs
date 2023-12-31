namespace School.Services.Services.IServices;

public interface ISubjectServices
{
    public bool SubjectExist(Guid Id);
    public Task<bool> SubjectExistInDepartmentOfStudent(List<Guid> ListOfIdSubject, Guid IdStudent);
}
