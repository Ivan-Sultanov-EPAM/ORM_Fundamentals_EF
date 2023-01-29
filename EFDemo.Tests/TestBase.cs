using System;
using EFDemo;
using Microsoft.EntityFrameworkCore;

namespace EF.Tests
{
    public class TestBase : IDisposable
    {
        public readonly Dal Dal;
        public EFDemoDbContext _dbContext;

        public TestBase()
        {
            _dbContext = new EFDemoDbContext();
            
            _dbContext.Database.Migrate();
            
            Dal = new Dal(_dbContext);

            Dal.ClearAllData();
        }

        public void Dispose()
        {
            Dal.ClearAllData();
            _dbContext.Dispose();
        }
    }
}