using CourseManager.Enums;

namespace CourseManager.Entities;

public class Course : Base
{
    public Course(string title, EStatus status)
    {
        Title = title;
        Duration = DateTime.UtcNow.Date.ToLocalTime();
        Status = status;
    }

    public DateTime Duration { get; set; }

    public string Title { get; set; }

    public EStatus Status { get; set; }
}