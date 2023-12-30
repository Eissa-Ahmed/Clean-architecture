namespace School.Core.Mapping.StudentMapping;


public partial class StudentProfile
{
    public void ApplyGetAllStudentMapping()
    {
        CreateMap<StudentResult, StudentEntity>().ReverseMap();
    }
}
