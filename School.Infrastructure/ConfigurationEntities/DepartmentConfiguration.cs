namespace School.Infrastructure.ConfigurationEntities;

public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentEntity>
{
    // public DepartmentConfiguration(EntityTypeBuilder<DepartmentEntity> entity) => Configure(entity);
    public void Configure(EntityTypeBuilder<DepartmentEntity> entity)
    {
        //Type
        entity.ToTable("Departments");
        entity.HasKey(k => k.Id);

        entity.HasMany(m => m.StudentEntity)
                     .WithOne(o => o.DepartmentEntity)
                     .HasForeignKey(f => f.DepartmentId)
                     .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(m => m.DepartmentSubjectEntity)
              .WithOne(o => o.DepartmentEntity)
              .HasForeignKey(f => f.DepartmentId)
              .OnDelete(DeleteBehavior.Cascade);

        //Properity
        entity.Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(50);
    }
}
