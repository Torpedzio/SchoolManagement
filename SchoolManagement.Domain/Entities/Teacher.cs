using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public Instrument Instrument { get; private set; }
    public decimal HourlyRate { get; private set; }
    public bool IsActive { get; private set; }

    public ICollection<Course> Courses { get; private set; } = new List<Course>();
    public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();
    
    private Teacher() {}

    public Teacher(string firstName, string lastName, string email, Instrument instrument, decimal hourlyRate)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        Instrument = instrument;
        SetHourlyRate(hourlyRate);
        IsActive = true;
        
        SetCreated();
    }

    public void UpdateHourlyRate(decimal hourlyRate)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot change hourly rate of inactive teacher");
        SetHourlyRate(hourlyRate);
        Touch();
    }
    
    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("Teacher is already active");
        IsActive = true;
        Touch();
    }
    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Teacher is already inactive");
        IsActive = false;
        Touch();
    }
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
    
    private void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be null or empty");
        FirstName = firstName.Trim();
    }

    private void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be null or empty");
        LastName = lastName.Trim();
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty");
        if (!email.Contains("@"))
            throw new ArgumentException("Invalid email format");
        Email = email.Trim().ToLower();
    }

    private void SetHourlyRate(decimal hourlyRate)
    {
        if (hourlyRate <= 0)
            throw new ArgumentException("Hourly rate must be greater than zero");
        HourlyRate = hourlyRate;
    }
}