namespace School.Core.Feature.StudentFeature.Command.Handler;

public class StudentCommandHandler : ResponseHandler,
    IRequestHandler<CreateStudentModel, Response<string>>,
    IRequestHandler<AssignStudentToDepartmentModel, Response<string>>,
    IRequestHandler<DeleteStudentModel, Response<string>>,
    IRequestHandler<DeleteStudentFromDepartmentModel, Response<string>>,
    IRequestHandler<DeleteSubjectsFromStudentModel, Response<string>>,
    IRequestHandler<StudentUpdateModel, Response<string>>,
    IRequestHandler<AssignSubjectsToStudentModel, Response<StudentWithSubjectsResult>>
{
    private readonly IMapper _mapper;
    private readonly IStudentServices _studentServices;
    public StudentCommandHandler(IMapper mapper, IStudentServices studentServices)
    {
        _mapper = mapper;
        _studentServices = studentServices;
    }
    public async Task<Response<string>> Handle(CreateStudentModel request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<StudentEntity>(request);
        var result = await _studentServices.CreateAsync(student);
        if (result is null)
            return BadRequest("Error When Save Student");

        return Success("Success Save Student");
    }

    public async Task<Response<string>> Handle(AssignStudentToDepartmentModel request, CancellationToken cancellationToken)
    {
        var result = await _studentServices.AssignStudentToDepartment(request.IdStudent, request.IdDepartment);
        return Success("Success Assign Student To Department");
    }

    public async Task<Response<StudentWithSubjectsResult>> Handle(AssignSubjectsToStudentModel request, CancellationToken cancellationToken)
    {
        var (student, subjects) = await _studentServices.AssignSubjectsToStudent(request.subjects, request.id);

        StudentWithSubjectsResult studentWithSubjectsResult = new();
        studentWithSubjectsResult = _mapper.Map(student, studentWithSubjectsResult);
        studentWithSubjectsResult.subjects = _mapper.Map(subjects, studentWithSubjectsResult.subjects);

        return Success("Success Add Subjects To Student", studentWithSubjectsResult);
    }

    public async Task<Response<string>> Handle(DeleteStudentModel request, CancellationToken cancellationToken)
    {
        await _studentServices.DeleteAsync(request.Id);
        return Success("Success Delete Student");
    }

    public async Task<Response<string>> Handle(DeleteStudentFromDepartmentModel request, CancellationToken cancellationToken)
    {
        var result = await _studentServices.DeleteStudentFromDepartment(request.Id);
        return Success("Success Delete Student From Department");
    }

    public async Task<Response<string>> Handle(DeleteSubjectsFromStudentModel request, CancellationToken cancellationToken)
    {
        var result = await _studentServices.DeleteSubjectsFromStudent(request.subjects, request.Id);
        return Success("Success Delete Subjects From Student");
    }

    public async Task<Response<string>> Handle(StudentUpdateModel request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<StudentEntity>(request);
        var result = await _studentServices.UpdateAsync(student);
        return Success("Success Update Student");
    }
}
