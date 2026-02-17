using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Courses.Queries.GetCourseWithAvailabeSlots;

public class GetCoursesWithAvailabeSlotsQueryHandler : IRequestHandler<GetCourseWithAvailabeSlotsQuery, List<CoursesWithAvailabeSlotsDto>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public GetCoursesWithAvailabeSlotsQueryHandler(ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
    {
        _courseRepository = courseRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<List<CoursesWithAvailabeSlotsDto>> Handle(GetCourseWithAvailabeSlotsQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAllAsync();
        var result = new List<CoursesWithAvailabeSlotsDto>();

        foreach (var course in courses)
        {
            var currnetStudents = await _enrollmentRepository.GetByCourseIdAsync(course.Id);
            
            var count = currnetStudents.Count;
            
            if (count >= course.MaxStudents)    continue;
            
            result.Add(new CoursesWithAvailabeSlotsDto
            (
                course.Id,
                course.CourseName,
                course.Description,
                course.CourseLevel,
                course.MaxStudents,
                count,
                course.MaxStudents - count
            ));
        }
        return result;
    }
}