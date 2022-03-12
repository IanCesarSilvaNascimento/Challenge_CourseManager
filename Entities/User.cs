using CourseManager.Enums;

namespace CourseManager.Entities;

public class User : Base
{
    public User(string name, ERole role)
    {
        Name = name;
        Role = role;
    }

    public string Name { get; set; }

    public ERole Role { get; set; }

}