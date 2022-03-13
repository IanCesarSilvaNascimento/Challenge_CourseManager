using CourseManager.Enums;

namespace CourseManager.Entities;

public class Course : Base
{
    public Course(){}

    public string Duration { get; set; } = "6 meses";

    public string Title { get; set; }

    public EStatus Status { get; set; }
}