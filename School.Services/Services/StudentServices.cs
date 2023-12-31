namespace School.Services.Services;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IStudentSubjectRepository _studentSubjectRepository;
    public StudentServices(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, ISubjectRepository subjectRepository, IStudentSubjectRepository studentSubjectRepository)
    {
        _studentRepository = studentRepository;
        _departmentRepository = departmentRepository;
        _subjectRepository = subjectRepository;
        _studentSubjectRepository = studentSubjectRepository;
    }

    public async Task<string> AssignStudentToDepartment(int IdStudent, int IdDepartment)
    {
        try
        {
            var department = await _departmentRepository.GetByIdAsync(IdDepartment);
            var student = await _studentRepository.GetByIdAsync(IdStudent);

            student.DepartmentEntity = department;
            await _studentRepository.UpdateAsync(student);

            return "Success";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<(StudentEntity, List<SubjectEntity>)> AssignSubjectsToStudent(List<int> subjects, int id)
    {
        try
        {
            var student = await _studentRepository.GetByIdAsync(id);
            List<StudentSubjectEntity> StudentSubjectEntity = new();
            List<SubjectEntity> subjectEntity = new();
            foreach (var subjectId in subjects)
            {
                if (student.StudentSubjectEntity!.Any(i => i.SubjectId.Equals(subjectId)))
                    throw new Exception("You Try Add Subject Already Assigned To Student");

                student.StudentSubjectEntity!.Add(new StudentSubjectEntity() { SubjectId = subjectId });
            }
            foreach (var studentSubject in student.StudentSubjectEntity!)
            {
                var subject = await _subjectRepository.GetTableNoTracking().FirstOrDefaultAsync(i => i.Id.Equals(studentSubject.SubjectId));
                subjectEntity.Add(subject);
            }
            await _studentRepository.UpdateAsync(student);
            return (student, subjectEntity);
        }
        catch (DbUpdateException ex)
        {
            throw ex;
        }
    }

    public async Task<StudentEntity> CreateAsync(StudentEntity student)
    {
        var result = await _studentRepository.AddAsync(student);
        return result;
    }

    public async Task<string> DeleteAsync(int id)
    {
        await _studentRepository.DeleteAsync(i => i.Id.Equals(id));
        return "Success";
    }

    public async Task<string> DeleteStudentFromDepartment(int IdStudent)
    {
        using (var transaction = _studentRepository.BeginTransaction())
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(IdStudent);
                student.DepartmentId = null;
                student.StudentSubjectEntity = null;
                await _studentRepository.UpdateAsync(student);

                _studentRepository.Commit();
                return "Success";
            }
            catch (Exception)
            {
                _studentRepository.RollBack();
                throw;
            }
        }
    }

    public async Task<string> DeleteSubjectsFromStudent(List<int> subjects, int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        foreach (var subjectId in subjects)
        {
            var item = student.StudentSubjectEntity!.Where(i => i.SubjectId.Equals(subjectId)).FirstOrDefault();
            student.StudentSubjectEntity!.Remove(item!);
        }
        await _studentRepository.UpdateAsync(student);
        return "Success";
    }

    public async Task<List<StudentEntity>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return students;
    }

    public async Task<List<SubjectEntity>> GetAllSubjectForStudent(int IdStudent)
    {
        List<SubjectEntity> entities = new List<SubjectEntity>();
        var studentSubjects = await _studentSubjectRepository.GetTableNoTracking().Where(i => i.StudentId.Equals(IdStudent)).Include(i => i.SubjectEntity).ToListAsync();
        foreach (var studentSubject in studentSubjects)
        {
            entities.Add(studentSubject.SubjectEntity!);
        }
        return entities;
    }

    public async Task<StudentEntity> GetByIdAsync(int Id)
    {
        var student = await _studentRepository.GetTableNoTracking().Where(i => i.Id.Equals(Id)).FirstOrDefaultAsync();
        return student;
    }

    public async Task<bool> NameIsExist(string name)
    {
        var student = await _studentRepository.GetTableNoTracking().Where(i => i.Name.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();
        return student is null ? false : true;
    }

    public async Task<bool> NameIsExistExceptForHimself(string name, int id)
    {
        var student = await _studentRepository.GetTableNoTracking().Where(i => i.Name.ToLower().Equals(name.ToLower()) && !i.Id.Equals(id)).FirstOrDefaultAsync();
        return student is null ? false : true;
    }

    public bool StudentExist(int Id)
    {
        var student = _studentRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
        return student is null ? false : true;
    }

    public bool StudentExistInDepartment(int Id)
    {
        var student = _studentRepository.GetTableNoTracking().FirstOrDefault(i => i.Id.Equals(Id));
        if (student is null)
            return false;

        return student.DepartmentId is null ? false : true;
    }

    public bool StudentExistInStudent(List<int> subjectsId, int id)
    {
        var student = _studentRepository.GetTableNoTracking().Where(i => i.Id.Equals(id)).Include(i => i.StudentSubjectEntity).FirstOrDefault();
        if (student is null)
            return false;

        foreach (var subjectId in subjectsId)
        {
            if (!student!.StudentSubjectEntity!.Any(i => i.SubjectId.Equals(subjectId)))
                return false;
        }
        return true;
    }

    public async Task<string> UpdateAsync(StudentEntity student)
    {
        await _studentRepository.UpdateAsync(student);
        return "Success";
    }
}
