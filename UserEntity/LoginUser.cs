using System.ComponentModel.DataAnnotations;
namespace UserEntity
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Invalid Username ")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Range(3, 15)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,15}", ErrorMessage = "Invalid password")]
        public string password { get; set; }
        public LoginUser()
        {

        }
        public LoginUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
