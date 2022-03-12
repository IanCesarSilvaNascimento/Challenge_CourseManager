using System.ComponentModel.DataAnnotations;
using CourseManager.Enums;

namespace CourseManager.ViewModels;

public class EditorCourseViewModel
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O título do curso deve conter entre 3 e 40 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O status é obrigatório")]
    [EnumDataType(typeof(EStatus),ErrorMessage ="Digite 1 para Previsto, 2 para Em andamento e 3 para Concluído")]
        public EStatus Status { get; set; }
}