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
}
