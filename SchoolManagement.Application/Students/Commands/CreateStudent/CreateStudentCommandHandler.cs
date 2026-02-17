using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IStudentRepository studentRepository, IApplicationDbContext context)
    {
        _studentRepository = studentRepository;
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var exist = await _studentRepository.ExistsByEmailAsync(request.Email);
        if(exist)
            throw new InvalidOperationException("Student with this email already exists");
        
        var student = new Student(request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.DateOfBirth);
        
        await _studentRepository.AddAsync(student);
        await _context.SaveChangesAsync(cancellationToken);
        return student.Id;
    }
}