using FluentValidation;

namespace SchoolManagement.Application.Students.Commands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
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
        
        RuleFor(x => x.PhoneNumber)
            .MaximumLength(10);
        
        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today);
    }
}