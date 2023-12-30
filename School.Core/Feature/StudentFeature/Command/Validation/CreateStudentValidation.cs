namespace School.Core.Feature.StudentFeature.Command.Validation;

public class CreateStudentValidation : AbstractValidator<CreateStudentModel>
{
    public CreateStudentValidation()
    {
        ApplyValidation();
    }
    private void ApplyValidation()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().Length(3, 12);
    }
}
