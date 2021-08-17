using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace tttServer.Models
{
    public class TblGames
    {
        public int ID { get; set; } // the players ID

        [DisplayName("Participant ID")]
        public int Participant { get; set; } // Players foreign key id

        [DisplayName("Number of turns")]
        public int Num_of_turns { get; set; } // Number of turns until finist

        [DisplayName("Date played")]
        public DateTime Date { get; set; } // Date the game was played

        [DisplayName("Did user win?")]
        public string User_win { get; set; } // boolean if the user has won
    }
}
