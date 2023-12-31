namespace School.Data.Entities;

public class DepartmentSubjectEntity
{
    public DepartmentSubjectEntity()
    {
        DepartmentEntity = new();
        SubjectEntity = new();
    }
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid SubjectId { get; set; }
    [InverseProperty("DepartmentSubjectEntity")]
    public DepartmentEntity DepartmentEntity { get; set; }
    [InverseProperty("DepartmentSubjectEntity")]
    public SubjectEntity SubjectEntity { get; set; }
}
