namespace School.Services.Services.IServices;

public interface IUserServices
{
    public Task<ApplicationUser> CreateAsync();
    public Task<List<ApplicationUser>> GetAllAsync();
    public Task<string> DeleteAsync(string Id);
    public Task<string> UpdateAsync(ApplicationUser user);
}
