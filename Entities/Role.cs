namespace CourseManager.Entities;

public class Role : Base
{
    public Role()
    {

    }

    public string Name { get; set; }
    
    public List<User> Users { get; set; } = new List<User>();
  


}
