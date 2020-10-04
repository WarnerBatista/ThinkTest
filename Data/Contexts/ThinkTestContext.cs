using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class ThinkTestContext: DbContext
    {
        public ThinkTestContext(DbContextOptions<ThinkTestContext> options) :base (options) { }
        public DbSet<Task> task { get; set; }
    }
}
