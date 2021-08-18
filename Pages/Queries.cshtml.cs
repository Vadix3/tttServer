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

        // Descending players
        public IList<TblPlayers> Players_by_game_desc { get; set; }

        // Games that the selected player played
        public IList<TblGames> Players_games { get; set; }



        public QueriesModel(Data.tttGamesContext gamesContext, Data.tttPlayersContext playersContext)
        {
            _gamesContext = gamesContext;
            _playersContext = playersContext;
        }


        public async void OnPostMyMethod()
        {
            Console.WriteLine("Listener: " + Username);

            var user = await _playersContext.TblPlayers.FirstOrDefaultAsync(s => s.Username == Username);

            if (user == null) // check if we found something
            {
                Console.WriteLine("Not found");
            }

            // Games for player
            var games = from m in _gamesContext.TblGames
                        select m;

 
            if (!string.IsNullOrEmpty(user.Id.ToString()))
            {

                games = games.Where(s => s.Participant.Equals(user.Id));
            }


            if (games == null)
            {
                Console.WriteLine("No games!");
            }
            else
            {
                Console.WriteLine("Games 1");
                Players_games = games.ToList();
                Console.WriteLine("Games 2");

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

            // Players by game desc
            Players_by_game_desc = All_players.OrderByDescending(p => p.Num_of_games).ToList();

            // Games by player test
            var user = await _playersContext.TblPlayers.FirstOrDefaultAsync(s => s.Username == "YinoNews");

            if (user == null) // check if we found something
            {
                Console.WriteLine("Not found");
            }

            // Games for player
            var games = from m in _gamesContext.TblGames
                        select m;

            if (!string.IsNullOrEmpty(user.Id.ToString()))
            {
                games = games.Where(s => s.Participant.Equals(user.Id));
            }

            if (games == null)
            {
                Console.WriteLine("No games!");
            }
            else
            {
                Console.WriteLine("Got players games = " + games.Count());
                Players_games = games.ToList();
            }


        }

    }
}
