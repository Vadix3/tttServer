using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tttServer.Models;

namespace tttServer.Pages
{
    public class QueriesModel : PageModel
    {


        private readonly Data.tttGamesContext _context;

        public QueriesModel(Data.tttGamesContext context)
        {
            _context = context;
        }



        public void OnGet()
        {

            Console.WriteLine("Queries");


        }


    }
}
