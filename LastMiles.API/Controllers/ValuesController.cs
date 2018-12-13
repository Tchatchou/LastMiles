using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMiles.API.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET ap
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var v = await  _context.Testdbs.ToListAsync();
            return Ok(v);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var v =await _context.Testdbs.FirstOrDefaultAsync(x=>x.id==id);

            return Ok(v);
        }

      
    }
}
