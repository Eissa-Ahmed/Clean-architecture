namespace School.Core.Feature.StudentFeature.Command.Models;

public class DeleteSubjectsFromStudentModel : IRequest<Response<string>>
{
    public DeleteSubjectsFromStudentModel(Guid id, List<Guid> subjects)
    {
        Id = id;
        this.subjects = subjects;
    }
    public Guid Id { get; set; }
    public List<Guid> subjects { get; set; }
}
