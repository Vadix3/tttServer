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

namespace tttServer.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly tttServer.Data.tttPlayersContext _context;

        public EditModel(tttServer.Data.tttPlayersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPlayers TblPlayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Console.WriteLine("OnGetAsync");

            if (id == null)
            {
                Console.WriteLine("id == null");

                return NotFound();
            }

            TblPlayers = await _context.TblPlayers.FirstOrDefaultAsync(m => m.Id == id);

            if (TblPlayers == null)
            {
                Console.WriteLine("NotFound");

                return NotFound();
            }
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            // Problem is here, modelstate is never valid
            TblPlayers.ConfirmPassword = TblPlayers.Password;
            Console.WriteLine("TblPlayers got = " + TblPlayers.Id);
            Console.WriteLine("TblPlayers got = " + TblPlayers.Name);
            Console.WriteLine("TblPlayers got = " + TblPlayers.Last_name);
            Console.WriteLine("TblPlayers got = " + TblPlayers.Username);
            Console.WriteLine("TblPlayers got = " + TblPlayers.Password);
            Console.WriteLine("TblPlayers got = " + TblPlayers.Num_of_games);
            Console.WriteLine("TblPlayers got = " + TblPlayers.ConfirmPassword);

            if (!ModelState.IsValid)
            {
                Console.WriteLine("!ModelState.IsValid");


                var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

                foreach (var error in errors) {
                    Console.WriteLine("Erorr: "+error.Errors.ToString());
                }


                return Page();
            }

            _context.Attach(TblPlayers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayersExists(TblPlayers.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Console.WriteLine("RedirectToPage");

            return RedirectToPage("./Index");
        }

        private bool TblPlayersExists(int id)
        {
            return _context.TblPlayers.Any(e => e.Id == id);
        }
    }
}
