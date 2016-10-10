using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kazmierczak.Languer.DAO.BO;

namespace Kazmierczak.Languer.DAO
{
    public class DataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
