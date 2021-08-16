using System;
using System.Collections.Generic;
using System.Text;

namespace tttGame.Models
{
    public class GameBoard
    {
        public int ID { get; set; }

        string GameMatrixJson { get; set; } // a json form of the character matrix that indicates the board
    }

}
