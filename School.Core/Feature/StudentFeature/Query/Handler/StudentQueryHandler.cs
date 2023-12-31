namespace School.Core.Feature.StudentFeature.Query.Handler;

public class StudentQueryHandler : ResponseHandler,
    IRequestHandler<GetAllStudentModel, Response<List<StudentResult>>>,
    IRequestHandler<GetAllSubjectForStudentModel, Response<List<GetAllSubjectForStudentResult>>>
{
    private readonly IStudentServices _studentServices;
    private readonly IMapper _mapper;
    public StudentQueryHandler(IStudentServices studentServices, IMapper mapper)
    {
        _studentServices = studentServices;
        _mapper = mapper;
    }
    public async Task<Response<List<StudentResult>>> Handle(GetAllStudentModel request, CancellationToken cancellationToken)
    {
        var students = await _studentServices.GetAllAsync();
        var result = _mapper.Map<List<StudentResult>>(students);
        return Success("Success Get All Student", result);
    }

    public async Task<Response<List<GetAllSubjectForStudentResult>>> Handle(GetAllSubjectForStudentModel request, CancellationToken cancellationToken)
    {
        var result = await _studentServices.GetAllSubjectForStudent(request.Id);
        var ListOfStudent = _mapper.Map<List<GetAllSubjectForStudentResult>>(result);
        return Success("Success Get All Subject For Student", ListOfStudent);
    }
}
