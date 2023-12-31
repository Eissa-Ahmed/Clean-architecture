namespace School.Core.Feature.StudentFeature.Query.Models;

public class GetAllSubjectForStudentModel : IRequest<Response<List<GetAllSubjectForStudentResult>>>
{
    public Guid Id { get; set; }
    public GetAllSubjectForStudentModel(Guid id)
    {
        Id = id;
    }
}
