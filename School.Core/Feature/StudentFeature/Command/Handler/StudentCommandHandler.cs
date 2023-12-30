﻿using School.Core.Feature.StudentFeature.Command.Validation;

namespace School.Core.Feature.StudentFeature.Command.Handler;

public class StudentCommandHandler : ResponseHandler, IRequestHandler<CreateStudentModel, Response<string>>
{
    private readonly IMapper _mapper;
    private readonly IStudentServices _studentServices;
    public StudentCommandHandler(IMapper mapper, IStudentServices studentServices)
    {
        _mapper = mapper;
        _studentServices = studentServices;
    }
    public async Task<Response<string>> Handle(CreateStudentModel request, CancellationToken cancellationToken)
    {

        try
        {
            CreateStudentValidation validator = new CreateStudentValidation();
            /*ValidationResult resultValidator =*/
            validator.ValidateAndThrow(request);
            /*if (!resultValidator.IsValid)
                return BadRequest(resultValidator.ToString("||"));*/

            var student = _mapper.Map<StudentEntity>(request);
            var result = await _studentServices.CreateAsync(student);
            if (result is null)
                return BadRequest("Error When Save Student");

            return Success("Success Save Student");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}
