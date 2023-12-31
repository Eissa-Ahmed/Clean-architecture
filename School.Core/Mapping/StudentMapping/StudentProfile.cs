﻿namespace School.Core.Mapping.StudentMapping;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        ApplyCreateStudentMapping();
        ApplyGetAllStudentMapping();
        ApplyAssignSubjectsToStudentMapping();
        ApplyGetAllSubjectForStudentMapping();
        ApplyStudentUpdateMapping();
    }
}
