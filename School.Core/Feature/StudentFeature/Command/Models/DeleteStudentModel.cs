namespace School.Core.Feature.StudentFeature.Command.Models
{
    public class DeleteStudentModel : IRequest<Response<string>>
    {
        public DeleteStudentModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
