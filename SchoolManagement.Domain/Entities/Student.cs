namespace SchoolManagement.Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public bool IsActive { get; private set; }

    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
    
    private Student() {}

    public Student(string firstName, string lastName, string email, string? phoneNumber, DateTime dateOfBirth)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        PhoneNumber = phoneNumber;
        SetDateOfBirth(dateOfBirth);
        IsActive = true;
        
        SetCreated();
    }

    public void UpdateEmail(string email)
    {
        SetEmail(email);
        Touch();
    }
    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Student is already inactive");
        IsActive = false;
        Touch();
    }
    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("Student is already active");
        IsActive = true;
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
        try
        {
            var _ = new System.Net.Mail.MailAddress(email);
        }
        catch
        {
            throw new ArgumentException("Email format is invalid");
        }
        Email = email.Trim().ToLowerInvariant();
    }

    private void SetDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth > DateTime.UtcNow)
            throw new ArgumentException("Date of birth cannot be in the future");
        var age = DateTime.Now.Year - dateOfBirth.Year;
        if (age < 5)
            throw new ArgumentException("Date of birth cannot be less than 5 years");
        DateOfBirth = dateOfBirth;
    }
    
    private void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}