using System;
using EFDemo;

namespace EF.Tests
{
    public class TestBase : IDisposable
    {
        public readonly Dal Dal;

        public TestBase()
        {
            Dal = new Dal(new EFDemoDbContext());
            Dal.ClearAllData();
        }

        public void Dispose()
        {
            Dal.ClearAllData();
        }
    }
}