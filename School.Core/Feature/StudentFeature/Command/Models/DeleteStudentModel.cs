namespace School.Core.Feature.StudentFeature.Command.Models
{
    public class DeleteStudentModel : IRequest<Response<string>>
    {
        public DeleteStudentModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
