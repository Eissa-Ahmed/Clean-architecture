namespace School.Core.Feature.StudentFeature.Query.Models;

public class GetAllSubjectForStudentModel : IRequest<Response<List<GetAllSubjectForStudentResult>>>
{
    public int Id { get; set; }
    public GetAllSubjectForStudentModel(int id)
    {
        Id = id;
    }
}
