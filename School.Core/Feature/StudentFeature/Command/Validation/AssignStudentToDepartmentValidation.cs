namespace School.Core.Feature.StudentFeature.Command.Validation;

public class AssignStudentToDepartmentValidation : AbstractValidator<AssignStudentToDepartmentModel>
{
    private readonly IStudentServices _studentServices;
    private readonly IDepartmentServices _departmentServices;
    public AssignStudentToDepartmentValidation(IStudentServices studentServices, IDepartmentServices departmentServices)
    {
        ApplyValidation();
        _studentServices = studentServices;
        _departmentServices = departmentServices;
    }
    private void ApplyValidation()
    {
        RuleFor(p => p.IdStudent).Must((key) => _studentServices.StudentExist(key)).WithMessage("Please Check Id Student Again");
        RuleFor(p => p.IdDepartment).Must((key) => _departmentServices.DepartmentExist(key)).WithMessage("Please Check Id Department Again");
    }
}
