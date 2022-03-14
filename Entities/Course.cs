using CourseManager.Enums;

namespace CourseManager.Entities;

public class Course : Base
{
    public Course(){}

    public string Duration { get; set; } 

    public string Title { get; set; }

    public EStatus Status { get; set; }
}