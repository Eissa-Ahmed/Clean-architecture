namespace School.Data.Entities;

public class StudentEntity
{
    public StudentEntity()
    {
        DepartmentEntity = new();
        StudentSubjectEntity = new HashSet<StudentSubjectEntity>();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Adress { get; set; } = null;
    public string Phone { get; set; } = null!;
    public int? DepartmentId { get; set; }
    [InverseProperty("StudentEntity")]
    public virtual DepartmentEntity DepartmentEntity { get; set; }
    [InverseProperty("StudentEntity")]
    public virtual ICollection<StudentSubjectEntity> StudentSubjectEntity { get; set; }
}
