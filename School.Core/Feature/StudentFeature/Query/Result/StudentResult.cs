namespace School.Core.Feature.StudentFeature.Query.Result
{
    public class StudentResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Adress { get; set; } = null;
        public string Phone { get; set; } = null!;
    }
}
