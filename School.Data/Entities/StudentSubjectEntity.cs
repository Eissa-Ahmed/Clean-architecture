namespace School.Data.Entities
{
    public class StudentSubjectEntity
    {
        public StudentSubjectEntity()
        {
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        [InverseProperty("StudentSubjectEntity")]
        public virtual StudentEntity? StudentEntity { get; set; }
        [InverseProperty("StudentSubjectEntity")]
        public virtual SubjectEntity? SubjectEntity { get; set; }
    }
}
