namespace School.Core.Feature.StudentFeature.Command.Validation;

public class DeleteSubjectsFromStudentValidation : AbstractValidator<DeleteSubjectsFromStudentModel>
{
    private readonly IStudentServices _studentServices;
    private readonly ISubjectServices _subjectServices;
    public DeleteSubjectsFromStudentValidation(IStudentServices studentServices, ISubjectServices subjectServices)
    {
        ApplyValidation();
        _studentServices = studentServices;
        _subjectServices = subjectServices;
    }
    private void ApplyValidation()
    {
        RuleFor(i => i.Id).NotEmpty().NotNull().Must((key) => _studentServices.StudentExist(key))
            .WithMessage("Student Not Exist");
        RuleForEach(i => i.subjects).ChildRules(child =>
        {
            child.RuleFor(i => i).Must((key) => _subjectServices.SubjectExist(key))
            .WithMessage("Inputs Not Correct, Subject Not Exist");
        });
        RuleFor(i => i.subjects).Must((model, key) => _studentServices.StudentExistInStudent(model.subjects, model.Id))
            .WithMessage("Some Of Subject Not Assign To Student");
    }
}
