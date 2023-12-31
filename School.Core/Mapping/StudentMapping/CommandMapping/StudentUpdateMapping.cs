namespace School.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    private void ApplyStudentUpdateMapping()
    {
        CreateMap<StudentEntity, StudentUpdateModel>().ReverseMap();
    }
}
