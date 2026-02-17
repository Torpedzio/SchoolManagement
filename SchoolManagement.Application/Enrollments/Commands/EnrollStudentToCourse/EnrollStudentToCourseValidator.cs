using FluentValidation;

namespace SchoolManagement.Application.Enrollments.Commands.EnrollStudentToCourse;

public class EnrollStudentToCourseValidator : AbstractValidator<EnrollStudentToCourseCommand>
{
    public EnrollStudentToCourseValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0);
        
        RuleFor(x => x.CourseId)
            .GreaterThan(0);
        
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Today);
    }
}