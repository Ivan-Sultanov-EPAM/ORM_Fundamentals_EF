using System;
using EFDemo;
using Microsoft.EntityFrameworkCore;

namespace EF.Tests
{
    public class TestBase : IDisposable
    {
        public readonly Dal Dal;
        public EfDemoDbContext DbContext;

        public TestBase()
        {
            DbContext = new EfDemoDbContext();
            
            DbContext.Database.Migrate();
            
            Dal = new Dal(DbContext);

            Dal.ClearAllData();
        }

        public void Dispose()
        {
            Dal.ClearAllData();
            DbContext.Dispose();
        }
    }
}