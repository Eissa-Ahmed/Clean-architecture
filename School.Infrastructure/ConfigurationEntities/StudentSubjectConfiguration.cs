namespace School.Infrastructure.ConfigurationEntities;

public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubjectEntity>
{
    //public StudentSubjectConfiguration(EntityTypeBuilder<StudentSubjectEntity> entity) => Configure(entity);

    public void Configure(EntityTypeBuilder<StudentSubjectEntity> entity)
    {
        //Type
        entity.ToTable("StudentSubjects");
        entity.HasKey(k => k.Id);
        entity.HasOne(m => m.StudentEntity)
              .WithMany(o => o.StudentSubjectEntity)
              .HasForeignKey(f => f.StudentId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(m => m.SubjectEntity)
              .WithMany(o => o.StudentSubjectEntity)
              .HasForeignKey(f => f.SubjectId)
              .OnDelete(DeleteBehavior.Cascade);

        //Properity
        entity.Property(p => p.SubjectId)
              .IsRequired();
        entity.Property(p => p.StudentId)
              .IsRequired();
    }
}
