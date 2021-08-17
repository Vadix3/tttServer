using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly tttServer.Data.tttPlayersContext _context;

        public CreateModel(tttServer.Data.tttPlayersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblPlayers TblPlayers { get; set; }

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
