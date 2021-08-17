using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using tttGame.Models;
using tttServer.Data;
using tttServer.Models;

namespace tttServer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBoardsController : ControllerBase
    {
        private readonly GameBoardContext _context;
        public const int SIZE = 5;
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

        // POST: api/GameBoards/test
        [HttpPost("test")]
        public string Make_Move([FromBody] string content)
        {
            Console.WriteLine("Got: " + content);

            //convert json to object
            char[,] board = JsonConvert.DeserializeObject<char[,]>(content);

            //find an empty square
            int[] position = Get_dumb_position(board);

            //mark the square
            board[position[0], position[1]] = 'O';

            //convert to json
            var json = JsonConvert.SerializeObject(board);

            //return the json
            return json;
        }

        /** A method that receives a matrix and returns a random empty position*/
        private int[] Get_dumb_position(char[,] demoAfter)
        {
            int[] pos = { 0, 0 };

            // array with empty spots
            ArrayList emptySpots = new ArrayList();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (demoAfter[i, j] == ' ')
                    { // if empty position is found
                        emptySpots.Add(new Position(i, j));
                    }
                }
            }

            Position position = (Position)emptySpots[new Random().Next(emptySpots.Count)];

            pos[0] = position.i;
            pos[1] = position.j;

            return pos;
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
