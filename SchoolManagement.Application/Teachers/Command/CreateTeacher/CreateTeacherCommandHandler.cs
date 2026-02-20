using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Teachers.Command.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IApplicationDbContext _context;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository, IApplicationDbContext context)
    {
        _teacherRepository = teacherRepository;
        _context = context;
    }

    public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var exist = await _teacherRepository.GetByEmailAsync(request.Email);
        if(exist is not null)
            throw new InvalidOperationException("Teacher already exists");
        
        var teacher = new Teacher(request.FirstName, request.LastName, request.Email, request.Instrument, request.HourlyRate);
        
        await _teacherRepository.AddAsync(teacher);
        await _context.SaveChangesAsync(cancellationToken);
        return teacher.Id;
    }
}