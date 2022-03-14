using System.Text.Json.Serialization;

namespace CourseManager.Entities;

public class Role : Base
{
    public Role()
    {
        Users = new List<User>();
    }

    public string Name { get; set; }

  
    public List<User> Users { get; set; }



}
