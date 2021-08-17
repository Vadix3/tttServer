using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tttServer.Models;

namespace tttServer.Data
{
    public class tttGamesContext : DbContext
    {
        public tttGamesContext (DbContextOptions<tttGamesContext> options)
            : base(options)
        {
        }

        public DbSet<tttServer.Models.TblGames> TblGames { get; set; }
    }
}
