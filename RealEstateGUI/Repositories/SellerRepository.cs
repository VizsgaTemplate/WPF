using Jedlik.EntityFramework.Helper.Repositories;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateGUI.Repositories
{
    public class SellerRepository : GenericRepository<Seller>
    {
        public SellerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
