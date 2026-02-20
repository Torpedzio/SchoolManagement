using FluentValidation;

namespace SchoolManagement.Application.Teachers.Command.CreateTeacher;

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public  CreateTeacherCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Instrument)
            .NotEmpty();
        
        RuleFor(x => x.HourlyRate)
            .GreaterThan(0);
    }
}