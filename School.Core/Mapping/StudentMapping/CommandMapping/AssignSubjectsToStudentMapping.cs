namespace School.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void ApplyAssignSubjectsToStudentMapping()
    {
        CreateMap<StudentEntity, StudentWithSubjectsResult>().ReverseMap();
        CreateMap<SubjectEntity, SubjectsForStudentResult>().ReverseMap();
    }
}
