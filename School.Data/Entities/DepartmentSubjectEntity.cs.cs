namespace School.Data.Entities;

public class DepartmentSubjectEntity
{
    public DepartmentSubjectEntity()
    {
        DepartmentEntity = new();
        SubjectEntity = new();
    }
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int SubjectId { get; set; }
    [InverseProperty("DepartmentSubjectEntity")]
    public DepartmentEntity DepartmentEntity { get; set; }
    [InverseProperty("DepartmentSubjectEntity")]
    public SubjectEntity SubjectEntity { get; set; }
}
