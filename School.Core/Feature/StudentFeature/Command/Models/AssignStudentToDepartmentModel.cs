namespace School.Core.Feature.StudentFeature.Command.Models
{
    public class AssignStudentToDepartmentModel : IRequest<Response<string>>
    {
        public AssignStudentToDepartmentModel(Guid idStudent, Guid idDepartment)
        {
            IdStudent = idStudent;
            IdDepartment = idDepartment;
        }
        public Guid IdStudent { get; set; }
        public Guid IdDepartment { get; set; }
    }
}
