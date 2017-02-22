using CarPool.Db.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarPool.Db
{
    public class CpDbContext : DbContext
    {
        public CpDbContext()
            : base("conn_debug")
        {

        }
        #region Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; } 
        #endregion
    }
}