namespace School.Data.Entities;

public class SubjectEntity
{
    public SubjectEntity()
    {
        DepartmentSubjectEntity = new HashSet<DepartmentSubjectEntity>();
        StudentSubjectEntity = new HashSet<StudentSubjectEntity>();

    }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Period { get; set; }
    [InverseProperty("SubjectEntity")]
    public virtual ICollection<DepartmentSubjectEntity> DepartmentSubjectEntity { get; set; }
    [InverseProperty("SubjectEntity")]
    public virtual ICollection<StudentSubjectEntity> StudentSubjectEntity { get; set; }

}
