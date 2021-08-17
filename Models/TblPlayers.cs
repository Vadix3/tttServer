using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tttServer.Models
{
    public class TblPlayers
    {
        public int Id { get; set; }
        
        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please enter first name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name too short")]
        public string Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name too short")]
        public string Last_name { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Please enter a Username")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username too short")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password too short")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords does not match")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Number of games")]
        public int Num_of_games { get; set; }
    }
}
