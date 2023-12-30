namespace School.Core.Feature.StudentFeature.Command.Validation;

public class DeleteStudentFromDepartmentValidation : AbstractValidator<DeleteStudentFromDepartmentModel>
{
    private readonly IStudentServices _studentServices;
    public DeleteStudentFromDepartmentValidation(IStudentServices studentServices)
    {
        _studentServices = studentServices;
        ApplyValidation();
    }
    private void ApplyValidation()
    {
        RuleFor(i => i.Id).Must((key) => _studentServices.StudentExist(key)).WithMessage("Id Is Not Valid");
    }
}
