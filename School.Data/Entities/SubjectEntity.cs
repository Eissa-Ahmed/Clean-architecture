namespace School.Data.Entities;

public class SubjectEntity
{
    public SubjectEntity()
    {

    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Period { get; set; }
}
