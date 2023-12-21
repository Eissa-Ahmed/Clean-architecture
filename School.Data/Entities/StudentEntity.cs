namespace School.Data.Entities;

public class StudentEntity
{
    public StudentEntity()
    {
        DepartmentEntity = new();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Adress { get; set; } = null;
    public string Phone { get; set; } = null!;
    public string? DepartmentId { get; set; } = null;
    [InverseProperty("StudentEntity")]
    public virtual DepartmentEntity DepartmentEntity { get; set; }
}
