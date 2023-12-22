namespace School.Infrastructure.ConfigurationEntities;

public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubjectEntity>
{
    //public DepartmentSubjectConfiguration(EntityTypeBuilder<DepartmentSubjectEntity> entity) => Configure(entity);

    public void Configure(EntityTypeBuilder<DepartmentSubjectEntity> entity)
    {
        //Type
        entity.ToTable("DepartmentSubjects");
        entity.HasKey(k => k.Id);
        entity.HasOne(m => m.SubjectEntity)
              .WithMany(o => o.DepartmentSubjectEntity)
              .HasForeignKey(f => f.SubjectId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(m => m.DepartmentEntity)
              .WithMany(o => o.DepartmentSubjectEntity)
              .HasForeignKey(f => f.DepartmentId)
              .OnDelete(DeleteBehavior.Cascade);

        //Properity
        entity.Property(p => p.SubjectId)
              .IsRequired();
        entity.Property(p => p.DepartmentId)
              .IsRequired();
    }
}
