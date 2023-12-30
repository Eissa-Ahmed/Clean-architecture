namespace School.Core.Feature.StudentFeature.Command.Validation;

public class AssignSubjectsToStudentValidation : AbstractValidator<AssignSubjectsToStudentModel>
{
    private readonly IStudentServices _studentServices;
    private readonly ISubjectServices _subjectServices;
    public AssignSubjectsToStudentValidation(IStudentServices studentServices, ISubjectServices subjectServices)
    {
        _studentServices = studentServices;
        _subjectServices = subjectServices;
        ApplyValidation();

    }
    private void ApplyValidation()
    {
        RuleFor(i => i.id)
            .Must((key) => _studentServices.StudentExist(key)).WithMessage("Id Student Is Not Valid")
            .Must((key) => _studentServices.StudentExistInDepartment(key)).WithMessage("Student Is Not Assign In Any Department");
        RuleFor(i => i.subjects).Must(i => i.Count > 0).WithMessage("Must Be Send One Or More Id Of Subject");
        RuleForEach(i => i.subjects).ChildRules(subject =>
        {
            subject.RuleFor(i => i).Must((key) => _subjectServices.SubjectExist(key)).WithMessage("Subject Not Exist ");
        });
        RuleFor(i => i.subjects).MustAsync(async (model, key, cancellationToken) => await _subjectServices.SubjectExistInDepartmentOfStudent(key, model.id))
        .WithMessage("Subject Not Exist In Department Of Student");

    }
}
