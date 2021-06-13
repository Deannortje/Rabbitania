﻿using System.Threading.Tasks;
using backend_api.Models.User;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Data.User
{
    public class UserContext: DbContext, IUserContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
            
        }

        public UserContext()
        {
            
        }
        public DbSet<Models.User.User> Users { get; set; }
        
        public DbSet<UserEmails> UserEmail { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
