using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Students.Queries.GetStudentDashboard;

public record StudentDashboardDto(
    int StudentId,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive,
    List<StudentEnrollmentDto> Enrollments,
    decimal OutstandingPaymentstotal,
    int UnpaidPaymentsCount);
    
    public record StudentEnrollmentDto(
        int CourseId,
        string CourseName,
        EnrollmentStatus EnrollmentStatus,
        DateTime StartDate);