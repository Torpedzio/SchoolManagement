using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Enrollments.Commands.CompleteEnrollment;

public class CompleteEnrollmentCommandHandler : IRequestHandler<CompleteEnrollmentCommand, Unit>
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IApplicationDbContext _context;

    public CompleteEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IApplicationDbContext context)
    {
        _enrollmentRepository = enrollmentRepository;
        _context = context;
    }

    public async Task<Unit> Handle(CompleteEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(request.EnrollmentId);
        if (enrollment is null)
            throw new KeyNotFoundException("Enrollment not found");
        
        if (enrollment.EnrollmentStatus != EnrollmentStatus.Active)
            throw new InvalidOperationException("Enrollment is not active");
        
        enrollment.Complete();
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}