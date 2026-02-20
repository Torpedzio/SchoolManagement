using SchoolManagement.Domain.Enums;
using MediatR;

namespace SchoolManagement.Application.Teachers.Command.CreateTeacher;

public record CreateTeacherCommand(
    string FirstName,
    string LastName,
    string Email,
    Instrument Instrument,
    decimal HourlyRate): IRequest<int>;
