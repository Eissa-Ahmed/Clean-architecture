namespace School.Core.Feature.StudentFeature.Command.Models
{
    public class AssignStudentToDepartmentModel : IRequest<Response<string>>
    {
        public AssignStudentToDepartmentModel(int idStudent, int idDepartment)
        {
            IdStudent = idStudent;
            IdDepartment = idDepartment;
        }
        public int IdStudent { get; set; }
        public int IdDepartment { get; set; }
    }
}
