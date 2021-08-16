using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tttGame.Models;

namespace tttServer.Data
{
    public class GameBoardContext : DbContext
    {
        public GameBoardContext (DbContextOptions<GameBoardContext> options)
            : base(options)
        {
        }

        public DbSet<tttGame.Models.GameBoard> GameBoard { get; set; }
    }
}
