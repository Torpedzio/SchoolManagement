using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;

namespace SchoolManagement.Application.Students.Queries.GetStudentById;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);

        if (student is null)
            throw new KeyNotFoundException($"Student with id {request.Id} not found");

        return new StudentDto(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            student.PhoneNumber,
            student.DateOfBirth,
            student.IsActive);
    }
}