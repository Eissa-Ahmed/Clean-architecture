namespace School.Services.Services;

public class SubjectServices : ISubjectServices
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IStudentRepository _studentRepository;
    public SubjectServices(ISubjectRepository subjectRepository, IStudentRepository studentRepository)
    {
        _subjectRepository = subjectRepository;
        _studentRepository = studentRepository;
    }
    public bool SubjectExist(int Id)
    {
        var subject = _subjectRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
        return subject is null ? false : true;
    }

    public async Task<bool> SubjectExistInDepartmentOfStudent(List<int> ListOfIdSubject, int IdStudent)
    {
        var student = await _studentRepository.GetByIdAsync(IdStudent);
        if (student is null || student.DepartmentEntity is null)
            return false;

        foreach (var id in ListOfIdSubject)
        {
            var subject = _subjectRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(id));

            if (subject is null)
                return false;

            if (!student!.DepartmentEntity!.DepartmentSubjectEntity.Any(i => i.SubjectId.Equals(id)))
                return false;
        }

        return true;
    }
}
