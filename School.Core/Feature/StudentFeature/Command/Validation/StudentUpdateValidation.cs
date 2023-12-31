namespace School.Core.Feature.StudentFeature.Command.Validation;

public class StudentUpdateValidation : AbstractValidator<StudentUpdateModel>
{
    private readonly IStudentServices _studentServices;
    public StudentUpdateValidation(IStudentServices studentServices)
    {
        ApplyValidation();
        _studentServices = studentServices;
    }
    private void ApplyValidation()
    {
        RuleFor(i => i.Id).NotEmpty().NotNull().Must((key) => _studentServices.StudentExist(key))
            .WithMessage("Id Not Valid");
        RuleFor(i => i.Name).NotNull().NotEmpty()
            .MustAsync(async (model, key, cancellationToken) => !await _studentServices.NameIsExistExceptForHimself(model.Name, model.Id))
            .WithMessage("Name Is Exist");
        RuleFor(i => i.Phone).NotEmpty().NotNull();
        RuleFor(i => i.Address).MaximumLength(50).When(i => !i.Address.IsNullOrEmpty());
    }
}
