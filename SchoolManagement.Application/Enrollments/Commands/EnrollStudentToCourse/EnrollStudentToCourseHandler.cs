using System.Data;
using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Enrollments.Commands.EnrollStudentToCourse;

public class EnrollStudentToCourseHandler : IRequestHandler<EnrollStudentToCourseCommand, int>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IApplicationDbContext _context;

    public EnrollStudentToCourseHandler(IStudentRepository studentRepository, ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository, IApplicationDbContext context)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _enrollmentRepository = enrollmentRepository;
        _context = context;
    }
    
    public async Task<int> Handle(EnrollStudentToCourseCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId);
        if(student is null || !student.IsActive)
            throw new InvalidOperationException("Student does not exist or is inactive");

        var course = await _courseRepository.GetByIdAsync(request.CourseId);
        if(course is null)
            throw new InvalidOperationException("Course does not exist");

        var alreadyEnrolled = await _enrollmentRepository.ExistsAsync(request.StudentId, request.CourseId);
        if(alreadyEnrolled)
            throw new InvalidOperationException("Student is already enrolled in this course");
        
        var courentCount = (await _enrollmentRepository.GetByCourseIdAsync(request.CourseId)).Count;
        if (courentCount >= course.MaxStudents)
            throw new InvalidOperationException("Course is full");

        var enrollment = new Enrollment(
            request.StudentId,
            request.CourseId,
            request.StartDate,
            request.StartDate.AddMonths(6),
            EnrollmentStatus.Active);

        await _enrollmentRepository.AddAsync(enrollment);
        await _context.SaveChangesAsync(cancellationToken);
        return enrollment.Id;
    }
}