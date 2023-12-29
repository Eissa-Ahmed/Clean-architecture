namespace School.Core.Feature.StudentFeature.Command.Models;

public class CreateStudentModel : IRequest<Response<string>>
{
    public string Name { get; set; } = null!;
    public string? Adress { get; set; } = null;
    public string Phone { get; set; } = null!;
}
