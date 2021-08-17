using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly tttServer.Data.tttPlayersContext _context;

        public IndexModel(tttServer.Data.tttPlayersContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get;set; }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
        }
    }
}
