using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalculatorAPI.Models;

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public CalculatorController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: api/Calculator
        [HttpGet]
        public IEnumerable<CalculationDetail> GetCalculations()
        {

            return _context.CalculationDetails;

        }

        // GET: api/Calculator/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CalculationDetail = await _context.CalculationDetails.FindAsync(id);

            if (CalculationDetail == null)
            {
                return NotFound();
            }

            return Ok(CalculationDetail);
        }

        // POST: api/Calculator/2/3
        [HttpGet("{firstInput}/{secondInput}")]
        public  int StartCalculation([FromRoute] int firstInput, int secondInput)
        {
            var result = firstInput + secondInput;
            var nc = new CalculationDetail();
            nc.FirstInput = firstInput;
            nc.SecontInput = secondInput;
            nc.Result = result;
            _context.CalculationDetails.Add(nc);
            _context.SaveChanges();

            return _context.CalculationDetails.OrderByDescending(x => x.Id).FirstOrDefault().Result;
        }

    }
}