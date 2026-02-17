using MediatR;

namespace SchoolManagement.Application.Students.Queries.GetStudentDashboard;

public record GetStudentDashboardQuery(int StudentId) : IRequest<StudentDashboardDto>;