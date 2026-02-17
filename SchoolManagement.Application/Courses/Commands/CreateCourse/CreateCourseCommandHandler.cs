using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IApplicationDbContext _context;

    public CreateCourseCommandHandler(ICourseRepository courseRepository, ITeacherRepository teacherRepository, IApplicationDbContext context)
    {
        _courseRepository = courseRepository;
        _teacherRepository = teacherRepository;
        _context = context;
    }

    public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
        if (teacher is null || !teacher.IsActive)
            throw new InvalidOperationException("Teacher does not exist or is inactive");
        
        var course = new Course(
            request.CourseName, 
            request.Description, 
            request.PricePerHour, 
            request.MaxStudents, 
            request.CourseLevel, 
            request.TeacherId);
        
        await _courseRepository.AddAsync(course);
        await _context.SaveChangesAsync(cancellationToken);
        return course.Id;
    }
}