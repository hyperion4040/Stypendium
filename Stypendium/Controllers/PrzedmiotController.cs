using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stypendium.Models;

namespace Stypendium.Controllers
{
    [Route("/api/przedmiot")]
    public class PrzedmiotController : Controller
    {
        private  DataAccess _context;

        public PrzedmiotController(DataAccess context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var przedmioty = await _context.Informatyka.ToArrayAsync();
            var przedmiot = await _context.Przedmioty.ToArrayAsync();
            var response = przedmioty.Select(
                u => new
                {
                    id = u.Id,
                    semestr = u.Semestr,
                    przedmiot = u.Przedmiot.NazwaPrzedmiotu
                }
            );
            return Ok(response);
        }
    }
}