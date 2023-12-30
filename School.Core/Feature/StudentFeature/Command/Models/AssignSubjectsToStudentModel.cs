namespace School.Core.Feature.StudentFeature.Command.Models;

public class AssignSubjectsToStudentModel : IRequest<Response<StudentWithSubjectsResult>>
{
    public AssignSubjectsToStudentModel()
    {
        subjects = new();
    }
    public int id { get; set; }
    public List<int> subjects { get; set; }
}
