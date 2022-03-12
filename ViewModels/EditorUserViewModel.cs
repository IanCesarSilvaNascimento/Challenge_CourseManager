using System.ComponentModel.DataAnnotations;
using CourseManager.Enums;

namespace CourseManager.ViewModels;

public class EditorUserViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O perfil é obrigatório")]
    [EnumDataType(typeof(ERole), ErrorMessage = "Digite 1 para administrador, 2 para secretário e 3 para usuário")]
    public ERole Role { get; set; }
}