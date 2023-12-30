namespace School.Core.Feature.StudentFeature.Command.Validation;

public class DeleteStudentValidation : AbstractValidator<DeleteStudentModel>
{
    private readonly IStudentServices _studentServices;
    public DeleteStudentValidation(IStudentServices studentServices)
    {
        ApplyValidation();
        _studentServices = studentServices;
    }
    private void ApplyValidation()
    {
        RuleFor(i => i.Id).NotEmpty().NotNull().Must((key) => _studentServices.StudentExist(key)).WithMessage("Id Is Not Valid");
    }
}
