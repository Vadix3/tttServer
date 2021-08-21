using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPlayersController : ControllerBase
    {
        private readonly tttPlayersContext _context;

        public TblPlayersController(tttPlayersContext context)
        {
            _context = context;
        }



        // GET: api/TblPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPlayers>>> GetTblPlayers()
        {
            Console.WriteLine("TblPlayers");
            return await _context.TblPlayers.ToListAsync();

        }

        // Show the players ordered by num of games DESC
        // GET: api/TblPlayers/Order
        [HttpGet("Order")]
        public async Task<ActionResult<IEnumerable<TblPlayers>>> GetTblPlayersOrder()
        {
            Console.WriteLine("QueryGamesAsync");
            var games = from m in _context.TblPlayers
                        select m
                        ;

            games = games.OrderByDescending(s => s.Num_of_games);

            var list = await games.ToListAsync();
            Console.WriteLine(list);
            return list;
        }

        // GET: api/TblPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPlayers>> GetTblPlayers(int id)
        {
            var tblPlayers = await _context.TblPlayers.FindAsync(id);

            if (tblPlayers == null)
            {
                return NotFound();
            }

            return tblPlayers;
        }

        // POST: api/TblPlayers/login
        [HttpPost("login")]
        public async Task<ActionResult<TblPlayers>> LoginUser([FromBody] Credentials creds)
        {
            Console.WriteLine("Login credentials: "+creds.Username+" , "+creds.Password);
            var user = await _context.TblPlayers.FirstOrDefaultAsync(s => s.Username == creds.Username && s.Password == creds.Password);
            if (user == null) // check if we found something
            {
                return NotFound();
            }

            Console.WriteLine("Found: " + user);

            return user;
        }

        // PUT: api/TblPlayers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPlayers(int id, TblPlayers tblPlayers)
        {
            if (id != tblPlayers.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPlayers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblPlayers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPlayers>> PostTblPlayers(TblPlayers tblPlayers)
        {
            _context.TblPlayers.Add(tblPlayers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlayers", new { id = tblPlayers.Id }, tblPlayers);
        }

        // DELETE: api/TblPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPlayers>> DeleteTblPlayers(int id)
        {
            var tblPlayers = await _context.TblPlayers.FindAsync(id);
            if (tblPlayers == null)
            {
                return NotFound();
            }

            _context.TblPlayers.Remove(tblPlayers);
            await _context.SaveChangesAsync();

            return tblPlayers;
        }

        private bool TblPlayersExists(int id)
        {
            return _context.TblPlayers.Any(e => e.Id == id);
        }
    }
}
