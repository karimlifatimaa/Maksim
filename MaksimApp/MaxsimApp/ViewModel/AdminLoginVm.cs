using System.ComponentModel.DataAnnotations;

namespace MaxsimApp.ViewModel
{
    public class AdminLoginVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent {  get; set; }
    }
}
