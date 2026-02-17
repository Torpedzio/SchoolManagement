using MediatR;

namespace SchoolManagement.Application.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(int Id) : IRequest<StudentDto>;