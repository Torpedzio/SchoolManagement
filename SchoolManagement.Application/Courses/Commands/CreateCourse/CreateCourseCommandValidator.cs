using FluentValidation;

namespace SchoolManagement.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.CourseName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.PricePerHour)
            .GreaterThan(0);

        RuleFor(x => x.MaxStudents)
            .GreaterThan(0)
            .LessThan(30);

        RuleFor(x => x.TeacherId)
            .NotEmpty();
    }
}