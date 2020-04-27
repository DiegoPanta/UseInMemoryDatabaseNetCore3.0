using System.Collections.Generic;
using System.Threading.Tasks;
using ContratosApi.Data;
using ContratosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosApi.Controllers
{
    [ApiController]
    [Route("v1/contracties")]
    public class ContractController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Contract>>> Get ([FromServices] DataContext _context)
        {
            var contracts = await _context.Contracts.ToListAsync();

            return contracts;
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> Post([FromServices] DataContext _context, [FromBody] Contract model)
        {
            if (ModelState.IsValid)
            {
                _context.Contracts.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}