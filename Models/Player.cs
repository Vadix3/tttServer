using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tttServer.Models
{
    public class Player
    {

        public int ID { get; set; } // the players ID
        public int NumOfGames { get; set; } // number of games the user played

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username is too short!")]
        public string Username { get; set; } // players username, min of 3 characters

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name is too short!")]
        public string FirstName { get; set; } //players first name

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name is too short!")]
        public string LastName { get; set; } // players last name

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password is too short!")]
        public string Password { get; set; } // password

        [Required]
        [Compare("Password", ErrorMessage = "Passwords does not match")]
        public string ConfirmPassword { get; set; } // password confirmation
    }
}
