using MediatR;

namespace SchoolManagement.Application.Students.Commands.CreateStudent;

public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    DateTime DateOfBirth):IRequest<int>;