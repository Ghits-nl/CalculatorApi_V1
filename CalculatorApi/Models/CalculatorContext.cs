using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Models
{
    public class CalculatorContext: DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options): base(options)
        {

        }

        public DbSet<CalculationDetail> CalculationDetails { get; set; }
    }
}
