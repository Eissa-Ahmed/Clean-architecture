namespace School.Data.Entities
{
    public class StudentSubjectEntity
    {
        public StudentSubjectEntity()
        {
        }
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        [InverseProperty("StudentSubjectEntity")]
        public virtual StudentEntity? StudentEntity { get; set; }
        [InverseProperty("StudentSubjectEntity")]
        public virtual SubjectEntity? SubjectEntity { get; set; }
    }
}
