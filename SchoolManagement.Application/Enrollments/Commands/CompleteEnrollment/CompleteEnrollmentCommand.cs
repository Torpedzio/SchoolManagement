using MediatR;

namespace SchoolManagement.Application.Enrollments.Commands.CompleteEnrollment;

public record CompleteEnrollmentCommand(int EnrollmentId) : IRequest<Unit>;