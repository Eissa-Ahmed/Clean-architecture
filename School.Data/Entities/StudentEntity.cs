namespace School.Data.Entities;

public class StudentEntity
{
    public StudentEntity()
    {
        StudentSubjectEntity = new HashSet<StudentSubjectEntity>();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; } = null;
    public string Phone { get; set; } = null!;
    public int? DepartmentId { get; set; }
    [InverseProperty("StudentEntity")]
    public DepartmentEntity? DepartmentEntity { get; set; } = null;
    [InverseProperty("StudentEntity")]
    public virtual ICollection<StudentSubjectEntity>? StudentSubjectEntity { get; set; }
}
