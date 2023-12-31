namespace School.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void ApplyGetAllSubjectForStudentMapping()
    {
        CreateMap<SubjectEntity, GetAllSubjectForStudentResult>().ReverseMap();
    }
}
