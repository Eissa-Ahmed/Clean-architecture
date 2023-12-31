namespace School.API.Controllers;

[ApiController]
public class StudentController : BaseController
{
    [HttpPost(StudentRoute.CreateStudent)]
    public async Task<IActionResult> CreateAsync(CreateStudentModel model)
    {
        var result = await Mediator.Send(model);
        return NewResult(result);
    }
    [HttpGet(StudentRoute.GetAllStudent)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await Mediator.Send(new GetAllStudentModel());
        return NewResult(result);
    }
    [HttpGet(StudentRoute.GetAllSubjectForStudent)]
    public async Task<IActionResult> GetAllSubjectForStulldent(Guid id)
    {
        var result = await Mediator.Send(new GetAllSubjectForStudentModel(id));
        return NewResult(result);
    }
    [HttpPost(StudentRoute.AssignStudentToDepartment)]
    public async Task<IActionResult> AssignStudentToDepartment(AssignStudentToDepartmentModel model)
    {
        var result = await Mediator.Send(model);
        return NewResult(result);
    }
    [HttpPost(StudentRoute.AssignSubjectsToStudent)]
    public async Task<IActionResult> AssignSubjectsToStudent(AssignSubjectsToStudentModel model)
    {
        var result = await Mediator.Send(model);
        return NewResult(result);
    }
    [HttpDelete(StudentRoute.DeleteAsync)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await Mediator.Send(new DeleteStudentModel(id));
        return NewResult(result);
    }
    [HttpDelete(StudentRoute.DeleteStudentFromDepartment)]
    public async Task<IActionResult> DeleteStudentFromDepartment(Guid id)
    {
        var result = await Mediator.Send(new DeleteStudentFromDepartmentModel(id));
        return NewResult(result);
    }
    [HttpPost(StudentRoute.DeleteSubjectsFromStudent)]
    public async Task<IActionResult> DeleteSubjectsFromStudent(DeleteSubjectsFromStudentModel model)
    {
        var result = await Mediator.Send(model);
        return NewResult(result);
    }
    [HttpPut(StudentRoute.StudentUpdate)]
    public async Task<IActionResult> StudentUpdate(StudentUpdateModel model)
    {
        var result = await Mediator.Send(model);
        return NewResult(result);
    }
}
