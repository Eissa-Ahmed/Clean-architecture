namespace School.Core.Feature.StudentFeature.Command.Models;

public class DeleteStudentFromDepartmentModel : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteStudentFromDepartmentModel(int id)
    {
        Id = id;
    }
}
