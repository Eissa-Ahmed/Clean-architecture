namespace School.Infrastructure.ConfigurationEntities;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    //public StudentConfiguration(EntityTypeBuilder<StudentEntity> entity) => Configure(entity);
    public void Configure(EntityTypeBuilder<StudentEntity> entity)
    {
        //Type
        entity.ToTable("Students");
        entity.HasKey(k => k.Id);

        entity.HasOne(o => o.DepartmentEntity)
            .WithMany(m => m.StudentEntity)
            .HasForeignKey(f => f.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(m => m.StudentSubjectEntity)
            .WithOne(o => o.StudentEntity)
            .HasForeignKey(f => f.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        //Properity
        entity.Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(50);
        entity.Property(p => p.Adress)
              .HasMaxLength(150);
        entity.Property(p => p.Phone)
              .HasMaxLength(15);
    }
}
