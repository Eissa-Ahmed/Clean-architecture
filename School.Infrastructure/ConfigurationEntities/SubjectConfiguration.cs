namespace School.Infrastructure.ConfigurationEntities;

public class SubjectConfiguration : IEntityTypeConfiguration<SubjectEntity>
{
    //public SubjectConfiguration(EntityTypeBuilder<SubjectEntity> entity) => Configure(entity);
    public void Configure(EntityTypeBuilder<SubjectEntity> entity)
    {
        //Type
        entity.ToTable("Subjects");
        entity.HasKey(k => k.Id);
        entity.HasMany(m => m.DepartmentSubjectEntity)
              .WithOne(o => o.SubjectEntity)
              .HasForeignKey(f => f.SubjectId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(m => m.StudentSubjectEntity)
              .WithOne(o => o.SubjectEntity)
              .HasForeignKey(f => f.SubjectId)
              .OnDelete(DeleteBehavior.Cascade);

        //Properity
        entity.Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(50);
    }
}
