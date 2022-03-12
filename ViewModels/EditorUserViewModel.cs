using System.ComponentModel.DataAnnotations;
using CourseManager.Entities;


namespace CourseManager.ViewModels;

public class EditorUserViewModel
{

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O perfil é obrigatório")]
    public string Role { get; set; }


    
}