using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Pages
{
    public class PlayerGamesModel : PageModel
    {
        private readonly tttServer.Data.tttPlayersContext _context;

        public PlayerGamesModel(tttServer.Data.tttPlayersContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            //Get the list of players
            All_players = await _context.TblPlayers.ToListAsync();
        }

        [BindProperty]
        public TblPlayers TblPlayers { get; set; }
        public IList<TblPlayers> All_players { get; set; } // A list of all the players

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblPlayers.Add(TblPlayers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
