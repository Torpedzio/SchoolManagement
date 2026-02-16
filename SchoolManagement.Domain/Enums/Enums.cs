namespace SchoolManagement.Domain.Enums;

public enum PaymentType
{
    CreditCard,
    Cash
}

public enum PaymentStatus
{
    Pending,
    Paid,
    Overdue
}

public enum Instrument
{
    Piano,
    Guitar,
    Trumpet,
    Drums,
    Saxophone,
    Violin
}

public enum CourseLevel
{
    Beginner,
    Intermediate,
    Advanced
}

public enum DurationTime
{
    ThirtyMinutes,
    SixtyMinutes,
    NinetyMinutes,
    TwoHours
}

public enum LessonStatus
{
    Scheduled,
    Cancelled,
    Completed
}

public enum EnrollmentStatus
{
    Active,
    Suspended,
    Completed
}