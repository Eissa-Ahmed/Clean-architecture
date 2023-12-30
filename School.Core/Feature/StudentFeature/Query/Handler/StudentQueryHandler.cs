namespace School.Core.Feature.StudentFeature.Query.Handler;

public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetAllStudentModel, Response<List<StudentResult>>>
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
}
