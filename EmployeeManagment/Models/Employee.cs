using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalide Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Position is Required")]
        public string Position { get; set; }
    }
}
