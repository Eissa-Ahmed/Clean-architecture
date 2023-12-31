namespace School.Core.Feature.StudentFeature.Command.Models;

public class DeleteStudentFromDepartmentModel : IRequest<Response<string>>
{
    public Guid Id { get; set; }
    public DeleteStudentFromDepartmentModel(Guid id)
    {
        Id = id;
    }
}
