namespace CourseManager.Entities;

public class User : Base
{
    public User()
    {
        Role = new List<Role>();
    }

    public string Name { get; set; }
    public IList<Role> Role { get; set; }

}