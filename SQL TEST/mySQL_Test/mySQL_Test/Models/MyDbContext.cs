using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySQL_Test.Models
{
    class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //User형태의 table을 만든다. users가 table의 이름이 된다.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=127.0.0.1:Database=test:User=root:Password=1234");
        }
    }
}
