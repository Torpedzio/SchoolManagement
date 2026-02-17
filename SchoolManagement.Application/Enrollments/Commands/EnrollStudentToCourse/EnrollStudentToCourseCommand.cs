using MediatR;

namespace SchoolManagement.Application.Enrollments.Commands.EnrollStudentToCourse;

public record EnrollStudentToCourseCommand(
    int StudentId,
    int CourseId,
    DateTime StartDate):IRequest<int>;