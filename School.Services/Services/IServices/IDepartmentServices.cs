namespace School.Services.Services.IServices;

public interface IDepartmentServices
{
    public Task<DepartmentEntity> CreateAsync(DepartmentEntity department);
    public Task<List<DepartmentEntity>> GetAllAsync();
    public Task<DepartmentEntity> GetByIdAsync(int id);
    public Task<string> UpdateAsync(DepartmentEntity department);
    public Task<string> DeleteAsync(Expression<Func<DepartmentEntity, bool>> filter);
    public bool NameIsExist(string name);
    public bool NameIsExistExceptForHimself(string name, int id);
    public bool DepartmentExist(int Id);


}
