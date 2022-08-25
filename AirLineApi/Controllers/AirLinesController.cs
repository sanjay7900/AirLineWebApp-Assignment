using AirLineDbLayer.Data;
using AirLineDbLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirLineApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AirLinesController : Controller
    {
        private AirLineApiDbContext _context;

        public AirLinesController(AirLineApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAirLines()
        {
            var result = await _context.AirLine.ToListAsync();

            return Ok(JsonConvert.SerializeObject(result.OrderBy(n => n.Name)));

        }
        [HttpPost]
        public async Task<IActionResult> CreateAirLines(AirLineApiModel airline)
        {
            if(airline == null)
            {
                return BadRequest();
            }
            else
            {
                _context.AirLine.Add(airline);
                await _context.SaveChangesAsync();  
                return Ok();
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAirLines(int id)
        {
            var deletedata=  _context.AirLine.FirstOrDefault(A=>A.Id==id);  
            if(deletedata == null)
            {
                return NotFound();
            }
            else
            {
                 _context.AirLine.Remove(deletedata);
                await _context.SaveChangesAsync();
                return Ok();


            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAirLines(AirLineApiModel toupdate)
        {
            _context.AirLine.Update(toupdate);
           await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetAirLineId(int id)
        {
            var airline = _context.AirLine.FirstOrDefault(A => A.Id==id);   
            if(airline == null)
            {
                return NotFound();
            }
            else
            {
                await _context.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(airline));

            }

        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetAirlineByName(string name)
        {
            var airline= await _context.AirLine.FirstOrDefaultAsync(A => A.Name==name); 
            if( airline == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(JsonConvert.SerializeObject(airline));    
            }
        }
    }
}
