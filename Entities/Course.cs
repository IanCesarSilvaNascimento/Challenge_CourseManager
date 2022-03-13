using CourseManager.Enums;

namespace CourseManager.Entities;

public class Course : Base
{
    public Course()
    {
                     
    }

    public DateTime Duration { get; set; } = DateTime.UtcNow.Date.ToLocalTime();

    public string Title { get; set; }

    public EStatus Status { get; set; }
}