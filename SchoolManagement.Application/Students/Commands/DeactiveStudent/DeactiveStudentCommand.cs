using MediatR;

namespace SchoolManagement.Application.Students.Commands.DeactiveStudent;

public record DeactiveStudentCommand(int StudentId): IRequest<Unit>;