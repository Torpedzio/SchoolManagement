using MediatR;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Courses.Commands.CreateCourse;

public record CreateCourseCommand(
    string CourseName,
    string Description,
    decimal PricePerHour,
    int MaxStudents,
    CourseLevel CourseLevel,
    int TeacherId): IRequest<int>;