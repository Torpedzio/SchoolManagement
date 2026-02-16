using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities;

public class Lesson : BaseEntity
{
    public int CourseId { get; private set; }
    public Course Course { get; private set; }
    public int TeacherId { get; private set; }
    public Teacher Teacher { get; private set; }
    public DateTime Date { get; private set; }
    public DurationTime DurationTime { get; private set; }
    public string? Room { get; private set; }
    public LessonStatus LessonStatus { get; private set; }
    
    private Lesson() {}

    public Lesson(int courseId, int teacherId, DateTime date, DurationTime durationTime, string room, LessonStatus lessonStatus)
    {
        CourseId = courseId;
        TeacherId = teacherId;
        Date = date;
        DurationTime = durationTime;
        Room = room;
        LessonStatus = lessonStatus;
        
        SetCreated();
    }

    private void Complite()
    {
        if (LessonStatus == LessonStatus.Completed)
            throw new ArgumentException("Lesson is already completed");
        LessonStatus = LessonStatus.Completed;
        Touch();
    }

    private void Cancel()
    {
        if (LessonStatus == LessonStatus.Cancelled)
            throw new ArgumentException("Lesson is already cancelled");
        LessonStatus = LessonStatus.Cancelled;
        Touch();
    }
}