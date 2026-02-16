using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities;

public class Enrollment : BaseEntity
{
    public int StudentId { get; private set; }
    public Student Student { get; private set; }
    public int CourseId { get; private set; }
    public Course Course { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public EnrollmentStatus EnrollmentStatus { get; private set; }
    
    private Enrollment() {}

    public Enrollment(int studentId, int courseId, DateTime startDate, DateTime endDate, EnrollmentStatus enrollmentStatus)
    {
        StudentId = studentId;
        CourseId = courseId;
        StartDate = startDate;
        SetEndDate(endDate);
        EnrollmentStatus = enrollmentStatus;
        
        SetCreated();
    }
    
    public void Complete()
    {
        EnrollmentStatus = EnrollmentStatus.Completed;
        Touch();
    }
    
    private void SetEndDate(DateTime endDate)
    {
        if (endDate < StartDate)
            throw  new ArgumentException("EndDate must be after StartDate");
        EndDate = endDate;
    }
}
