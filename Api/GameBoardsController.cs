using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using tttGame.Models;
using tttServer.Data;

namespace tttServer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBoardsController : ControllerBase
    {
        private readonly GameBoardContext _context;

        public GameBoardsController(GameBoardContext context)
        {
            _context = context;
        }

        // GET: api/GameBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameBoard>>> GetGameBoard()
        {
            return await _context.GameBoard.ToListAsync();
        }

        // GET: api/GameBoards/test
        [HttpGet("test")]
        public string Make_Move(string jsonMatrix)
        {
            //convert json to object
            //find an empty square
            //mark the square
            //convert to json
            //return the json



            int[,] temp = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    temp[i, j] = (i + j) % 3;
                }
            }
            return JsonConvert.SerializeObject(temp);
        }

        // GET: api/GameBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameBoard>> GetGameBoard(int id)
        {
            var gameBoard = await _context.GameBoard.FindAsync(id);

            if (gameBoard == null)
            {
                return NotFound();
            }

            return gameBoard;
        }

        // PUT: api/GameBoards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameBoard(int id, GameBoard gameBoard)
        {
            if (id != gameBoard.ID)
            {
                return BadRequest();
            }

            _context.Entry(gameBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameBoardExists(id))
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

        // POST: api/GameBoards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameBoard>> PostGameBoard(GameBoard gameBoard)
        {
            _context.GameBoard.Add(gameBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameBoard", new { id = gameBoard.ID }, gameBoard);
        }

        // DELETE: api/GameBoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameBoard>> DeleteGameBoard(int id)
        {
            var gameBoard = await _context.GameBoard.FindAsync(id);
            if (gameBoard == null)
            {
                return NotFound();
            }

            _context.GameBoard.Remove(gameBoard);
            await _context.SaveChangesAsync();

            return gameBoard;
        }

        private bool GameBoardExists(int id)
        {
            return _context.GameBoard.Any(e => e.ID == id);
        }
    }
}
