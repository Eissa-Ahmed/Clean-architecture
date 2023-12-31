namespace School.Data.Entities;

public class DepartmentEntity
{
    public DepartmentEntity()
    {
        StudentEntity = new HashSet<StudentEntity>();
        DepartmentSubjectEntity = new HashSet<DepartmentSubjectEntity>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    [InverseProperty("DepartmentEntity")]
    public virtual ICollection<StudentEntity> StudentEntity { get; set; }
    [InverseProperty("DepartmentEntity")]
    public virtual ICollection<DepartmentSubjectEntity> DepartmentSubjectEntity { get; set; }
}
