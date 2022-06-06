using BoardGamesWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly DBBoardGamesContext _context;

        public ChartsController(DBBoardGamesContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]

        public JsonResult JsonData()
         {
             var games = _context.Games.ToList();
             List<object> gamess = new List<object>();
             gamess.Add(new[] { "Вікова категорія", "Кількість ігор" });
             foreach(var c in games)
             {
                 //gamess.Add(new object[] { c.Name, c.Age.Id.Count() });
                 return new JsonResult(gamess);
             }
             return new JsonResult(null);
         }
        

    }


}
