namespace School.Core.Feature.StudentFeature.Command.Result
{
    public class StudentWithSubjectsResult
    {
        public StudentWithSubjectsResult()
        {
            subjects = new();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<SubjectsForStudentResult> subjects { get; set; }
    }
    public class SubjectsForStudentResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
