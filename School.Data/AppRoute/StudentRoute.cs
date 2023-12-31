namespace School.Data.AppRoute
{
    public static class StudentRoute
    {
        private const string Base = "api/Student/";
        public const string CreateStudent = Base + "CreateStudent";
        public const string GetAllStudent = Base + "GetAllStudent";
        public const string AssignStudentToDepartment = Base + "AssignStudentToDepartment";
        public const string AssignSubjectsToStudent = Base + "AssignSubjectsToStudent";
        public const string DeleteAsync = Base + "DeleteAsync/{id}";
        public const string DeleteStudentFromDepartment = Base + "DeleteStudentFromDepartment/{id}";
        public const string DeleteSubjectsFromStudent = Base + "DeleteSubjectsFromStudent";
        public const string GetAllSubjectForStudent = Base + "GetAllSubjectForStudent";
        public const string StudentUpdate = Base + "StudentUpdate";
    }
}
