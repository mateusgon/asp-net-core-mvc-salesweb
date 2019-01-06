using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed ()
        {
            if( _context.Departament.Any() || _context.Seller.Any() )
            {
                return;
            }

            Departament departament = new Departament(1, "Computers");
            Seller s1 = new Seller(1, "Bob Brown", "teste@teste", new DateTime(1998, 4, 21), 1000.0, departament);
            SalesRecord sr1 = new SalesRecord(1, new DateTime(1998, 4, 21), 11000.0, SaleStatus.Billed, s1);

            _context.Departament.AddRange(departament);
            _context.Seller.AddRange(s1);
            _context.Sales.AddRange(sr1);
            _context.SaveChanges();
        }
    }
}
