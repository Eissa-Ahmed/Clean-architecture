namespace School.Core.Feature.StudentFeature.Command.Models;

public class DeleteSubjectsFromStudentModel : IRequest<Response<string>>
{
    public DeleteSubjectsFromStudentModel(int id, List<int> subjects)
    {
        Id = id;
        this.subjects = subjects;
    }
    public int Id { get; set; }
    public List<int> subjects { get; set; }
}
