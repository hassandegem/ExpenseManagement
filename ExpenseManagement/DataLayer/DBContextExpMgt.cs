using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseManagement.Models;

namespace ExpenseManagement.DataLayer
{
    public class DBContextExpMgt : DbContext
    {
        public DBContextExpMgt(DbContextOptions options) : base(options) { 
        }
        public DbSet<ExpenseEntity> Expences{ get; set; }
        public DbSet<ExpenseCategoryEntity> ExpencesCategory{ get; set; }
        public DbSet<UserProfile> UserProfile{ get; set; }
    }
}
