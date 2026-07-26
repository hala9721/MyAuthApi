using Microsoft.EntityFrameworkCore;
using MyAuth.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Infrastructure.Database
{
    public sealed class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
