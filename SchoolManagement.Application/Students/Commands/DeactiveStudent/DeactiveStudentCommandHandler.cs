using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Students.Commands.DeactiveStudent;

public class DeactiveStudentCommandHandler : IRequestHandler<DeactiveStudentCommand, Unit>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IApplicationDbContext _context;

    public DeactiveStudentCommandHandler(IStudentRepository studentRepository, IApplicationDbContext context)
    {
        _studentRepository = studentRepository;
        _context = context;
    }

    public async Task<Unit> Handle(DeactiveStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId);
        if (student is null)
            throw new InvalidOperationException($"Student with id {request.StudentId} not found");

        student.Deactivate();
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}