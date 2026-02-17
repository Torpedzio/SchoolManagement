using MediatR;

namespace SchoolManagement.Application.Courses.Queries.GetCourseWithAvailabeSlots;

public record GetCourseWithAvailabeSlotsQuery(): IRequest<List<CoursesWithAvailabeSlotsDto>>;