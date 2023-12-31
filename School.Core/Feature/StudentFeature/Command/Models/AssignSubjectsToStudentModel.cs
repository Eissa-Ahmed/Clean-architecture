namespace School.Core.Feature.StudentFeature.Command.Models;

public class AssignSubjectsToStudentModel : IRequest<Response<StudentWithSubjectsResult>>
{
    public AssignSubjectsToStudentModel()
    {
        subjects = new();
    }
    public Guid id { get; set; }
    public List<Guid> subjects { get; set; }
}
