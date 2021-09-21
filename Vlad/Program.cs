using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Vlad
{
    class Program
    {
        static void Main(string[] args)
        {
            new Db.WaterSupplyContext(new DbContextOptionsBuilder<Db.WaterSupplyContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=waterdb;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
            .SaveChanges();
        }
    }
}
