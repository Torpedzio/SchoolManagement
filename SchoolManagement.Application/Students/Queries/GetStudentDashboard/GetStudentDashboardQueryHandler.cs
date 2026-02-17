using System.Linq;
using MediatR;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Students.Queries.GetStudentDashboard;

public class GetStudentDashboardQueryHandler : IRequestHandler<GetStudentDashboardQuery, StudentDashboardDto>
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IPaymentRepository _paymentRepository;

    public GetStudentDashboardQueryHandler(IEnrollmentRepository enrollmentRepository,
        IStudentRepository studentRepository, IPaymentRepository paymentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _studentRepository = studentRepository;
        _paymentRepository = paymentRepository;
    }

    public async Task<StudentDashboardDto> Handle(GetStudentDashboardQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId);
        if (student is null)
            throw new KeyNotFoundException("Student not found");

        var enrollments = await _enrollmentRepository.GetByStudentIdAsync(request.StudentId);
        var activeEnrollments = enrollments
            .Where(e => e.EnrollmentStatus == EnrollmentStatus.Active)
            .Select(e => new StudentEnrollmentDto(
                e.CourseId,
                e.Course.CourseName,
                e.EnrollmentStatus,
                e.StartDate)).ToList();

        var payments = await _paymentRepository.GetByStudentIdAsync(request.StudentId);
        var unpaidPayments = payments
            .Where(p => p.PaymentStatus != PaymentStatus.Paid)
            .ToList();

        var outstandingTotal = unpaidPayments.Sum(p => p.Amount);
        
        return new StudentDashboardDto(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            student.IsActive,
            activeEnrollments,
            outstandingTotal,
            unpaidPayments.Count
        );
    }
}
