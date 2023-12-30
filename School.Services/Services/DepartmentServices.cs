namespace School.Services.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<DepartmentEntity> CreateAsync(DepartmentEntity department)
        {
            try
            {
                var result = await _departmentRepository.AddAsync(department);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteAsync(Expression<Func<DepartmentEntity, bool>> filter)
        {
            try
            {
                await _departmentRepository.DeleteAsync(filter);
                return "Success";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DepartmentExist(int Id)
        {
            var department = _departmentRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
            return department is null ? false : true;
        }

        public async Task<List<DepartmentEntity>> GetAllAsync()
        {
            try
            {
                var result = await _departmentRepository.GetAllAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartmentEntity> GetByIdAsync(int id)
        {
            try
            {
                var result = await _departmentRepository.GetByIdAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NameIsExist(string name)
        {
            var department = _departmentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefault();
            return department is null ? false : true;
        }

        public bool NameIsExistExceptForHimself(string name, int id)
        {
            var department = _departmentRepository.GetTableNoTracking().Where(x => x.Name == name && x.Id != id).FirstOrDefault();
            return department is null ? false : true;
        }

        public async Task<string> UpdateAsync(DepartmentEntity department)
        {
            try
            {
                await _departmentRepository.UpdateAsync(department);
                return "Success";

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
