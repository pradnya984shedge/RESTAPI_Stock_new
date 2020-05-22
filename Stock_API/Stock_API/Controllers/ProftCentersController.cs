using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock_API.Entities;
using Stock_API.Models;
using Stock_API.Services;

namespace Stock_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProftCentersController : ControllerBase
    {
        private readonly Stock_APIContext _context;
        private IProfitCenterservice _profitCenterservice;

        public ProftCentersController(Stock_APIContext context, IProfitCenterservice service)
        {
            _context = context;
            _profitCenterservice = service;
        }




        //GET: api/ProftCenters
        [HttpGet]
        public IEnumerable<ProftCenter> GetProftCenter()
        {
            
            var result = _context.ProftCenter.Include(c => c.stocks);
            return result;
            
        }

        // GET: api/ProftCenters/5
        [HttpGet("{id}")]
        public IActionResult GetProftCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proftCenter = _context.ProftCenter.Include(c => c.stocks).Where(c => c.Id == id);
            
            if (proftCenter == null)
            {
                return NotFound();
            }

            return Ok(proftCenter);
        }

        // PUT: api/ProftCenters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProftCenter([FromRoute] int id, [FromBody] ProftCenter proftCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proftCenter.Id)
            {
                return BadRequest();
            }

            _context.Entry(proftCenter).State = EntityState.Modified;

            if(proftCenter.stocks!=null)
            {
                foreach (var item in proftCenter.stocks)
                {
                    _context.stock.Add(item);
                }
            }
            

            try
                {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProftCenterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return CreatedAtAction(nameof(proftCenter), new { id = proftCenter.Id }, proftCenter);
            return NoContent();
        }

        // POST: api/ProftCenters
        [HttpPost]
        public async Task<IActionResult> PostProftCenter([FromBody] ProftCenter proftCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProftCenter.Add(proftCenter);

            if (proftCenter.stocks != null)
            {
                foreach (var item in proftCenter.stocks)
                {
                    _context.stock.Add(item);
                }
            }


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProftCenter", new { id = proftCenter.Id }, proftCenter);
        }

        // DELETE: api/ProftCenters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProftCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proftCenter = await _context.ProftCenter.FindAsync(id);
            if (proftCenter == null)
            {
                return NotFound();
            }

            if (proftCenter.stocks != null)
            {
                foreach (var item in proftCenter.stocks)
                {
                    _context.stock.Remove(item);
                }
            }

            _context.ProftCenter.Remove(proftCenter);
            await _context.SaveChangesAsync();

            return Ok(proftCenter);
        }

        private bool ProftCenterExists(int id)
        {
            return _context.ProftCenter.Any(e => e.Id == id);
        }

        

       
    }
}