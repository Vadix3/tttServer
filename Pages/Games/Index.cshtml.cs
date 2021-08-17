using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly tttServer.Data.tttGamesContext _context;

        public IndexModel(tttServer.Data.tttGamesContext context)
        {
            _context = context;
        }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();
        }
    }
}
