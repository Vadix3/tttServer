using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Pages
{
    public class GamesForPlayerModel : PageModel
    {
        private readonly tttServer.Data.tttGamesContext _context;

        public GamesForPlayerModel(tttServer.Data.tttGamesContext context)
        {
            _context = context;
        }

        public void OnGetUserId(int id)
        {
            Id = id;
            Console.WriteLine("Games for player with id = " + id);

            // Games for player
            var games = from m in _context.TblGames
                        select m;


            if (!string.IsNullOrEmpty(Id.ToString()))
            {

                games = games.Where(s => s.Participant.Equals(Id));
            }


            if (games == null)
            {
                Console.WriteLine("No games!");
            }
            else
            {
                Console.WriteLine("Games 1");
                Players_games = games.ToList();
                foreach(var item in Players_games) {
                    Console.WriteLine("Item = "+item.ToString());
                }
            }

        }

        [BindProperty]
        public TblGames TblGames { get; set; }
        public IList<TblGames> Players_games { get; set; }

        public int Id { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblGames.Add(TblGames);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
