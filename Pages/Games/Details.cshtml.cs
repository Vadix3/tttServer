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
    public class DetailsModel : PageModel
    {
        private readonly tttServer.Data.tttGamesContext _context;

        public DetailsModel(tttServer.Data.tttGamesContext context)
        {
            _context = context;
        }

        public TblGames TblGames { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGames = await _context.TblGames.FirstOrDefaultAsync(m => m.ID == id);

            if (TblGames == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
