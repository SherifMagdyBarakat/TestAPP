using System.ComponentModel.DataAnnotations;

namespace TestAPP.ViewModel
{
    public class CreateRoleViewModel
    {
       
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
 
    }
}
