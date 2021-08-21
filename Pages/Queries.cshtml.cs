using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tttServer.Models;

namespace tttServer.Pages
{
    public class QueriesModel : PageModel
    {

        private readonly Data.tttGamesContext _gamesContext;
        private readonly Data.tttPlayersContext _playersContext;

        public IList<TblPlayers> All_players { get; set; } // A list of all the players

        // For the combo box
        public IList<TblPlayers> Player { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Usernames { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }


        // Games that the selected player played
        public IList<TblGames> Players_games { get; set; }



        public QueriesModel(Data.tttGamesContext gamesContext, Data.tttPlayersContext playersContext)
        {
            _gamesContext = gamesContext;
            _playersContext = playersContext;
        }


        public async Task<IActionResult> OnPostMyMethod()
        {
            Console.WriteLine("Listener: " + Username);

            var user = await _playersContext.TblPlayers.FirstOrDefaultAsync(s => s.Username == Username);

            if (user == null) // check if we found something
            {
                Console.WriteLine("Not found");
                return RedirectToPage("Queries");
            }
            else
            {
                Console.WriteLine("Sending user id = " + user.Id);
                return RedirectToPage("GamesForPlayer", "UserId", new { id = user.Id });
            }
        }




        public void OnPost()
        {
            Console.WriteLine("Queries");

        }

        public async Task OnGetAsync()
        {
            Console.WriteLine("On get async");

            //Get the list of players
            All_players = await _playersContext.TblPlayers.ToListAsync();

            // Combo box
            var query = from m in _playersContext.TblPlayers
                        select m.Username;
            Usernames = new SelectList(await query.ToListAsync());

        }

    }
}
