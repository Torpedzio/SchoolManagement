using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities;

public class Course :  BaseEntity
{ 
    public string CourseName { get; private set; } = null!;
    public string Description { get; private set; } = string.Empty;
    public CourseLevel CourseLevel { get; private set; }
    public decimal PricePerHour { get; private set; }
    public int MaxStudents { get; private set; }
    public int TeacherId {get; private set;}

    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
    public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();
    public Teacher? Teacher { get; private set; }
    
    private Course() {}
    
    public Course(string courseName, string description, decimal pricePerHour, int maxStudents, CourseLevel courseLevel, int teacherId)
    {
        SetCourseName(courseName);
        SetDescription(description);
        CourseLevel = courseLevel;
        SetPrice(pricePerHour);
        SetMaxStudents(maxStudents);
        TeacherId = teacherId;
        
        SetCreated();
    }

    public void ChangePrice(decimal newPrice)
    {
        SetPrice(newPrice);
        Touch();
    }
    
    private void SetCourseName(string courseName)
    {
        if (string.IsNullOrWhiteSpace(courseName))
            throw new ArgumentException("Name cannot be null or empty");
        CourseName = courseName.Trim();
    }

    private void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be null or empty");
        Description = description;
    }

    private void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price cannot be zero or negative");
        PricePerHour = price;
    }

    private void SetMaxStudents(int maxStudents)
    {
        if (maxStudents <= 0)
            throw new ArgumentException("MaxStudents must be greater than 0");
        MaxStudents = maxStudents;
    }
}