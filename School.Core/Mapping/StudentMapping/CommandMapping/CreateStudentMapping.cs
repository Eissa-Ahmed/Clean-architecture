namespace School.Core.Mapping.StudentMapping;
public partial class StudentProfile
{
    public void ApplyCreateStudentMapping()
    {
        CreateMap<CreateStudentModel, StudentEntity>().ReverseMap();
    }
}
