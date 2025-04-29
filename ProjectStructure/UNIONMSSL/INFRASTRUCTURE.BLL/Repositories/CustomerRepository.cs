using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.DAL.Entities;
using CORE.DAL.Interfaces;
using INFRASTRUCTURE.BLL.Data;

namespace INFRASTRUCTURE.BLL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
        
    }
}
