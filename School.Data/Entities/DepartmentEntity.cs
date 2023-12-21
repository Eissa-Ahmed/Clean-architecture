namespace School.Data.Entities;

public class DepartmentEntity
{
    public DepartmentEntity()
    {
        StudentEntity = new HashSet<StudentEntity>();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? StudentId { get; set; } = null;
    [InverseProperty("DepartmentEntity")]
    public virtual ICollection<StudentEntity> StudentEntity { get; set; }
}
