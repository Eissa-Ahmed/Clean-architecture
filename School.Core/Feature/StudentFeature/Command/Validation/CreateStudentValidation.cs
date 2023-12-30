using Microsoft.IdentityModel.Tokens;

namespace School.Core.Feature.StudentFeature.Command.Validation;

public class CreateStudentValidation : AbstractValidator<CreateStudentModel>
{
    private readonly IStudentServices _studentServices;
    public CreateStudentValidation(IStudentServices studentServices)
    {
        ApplyValidation();
        _studentServices = studentServices;
    }
    private void ApplyValidation()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().Length(3, 12)
            .Must((model, key, cancellationToken) => !_studentServices.NameIsExist(key)).WithMessage("already Exist");

        RuleFor(p => p.Adress).Length(10, 120).When(p => !p.Adress.IsNullOrEmpty());
    }
}
