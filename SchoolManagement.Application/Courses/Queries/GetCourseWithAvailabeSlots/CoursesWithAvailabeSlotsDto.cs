using MediatR;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Courses.Queries.GetCourseWithAvailabeSlots;

public record CoursesWithAvailabeSlotsDto(
    int CourseId,
    string CourseName,
    string CourseDescription,
    CourseLevel CourseLevel,
    int MaxStudents,
    int CurrentStudents,
    int AvailableSlots) : IRequest<int>;