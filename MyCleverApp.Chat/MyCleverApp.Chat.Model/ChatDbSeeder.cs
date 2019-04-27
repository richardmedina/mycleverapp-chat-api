using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Model
{
    public class ChatDbSeeder
    {
        private readonly ChatDbContext _context;
        public ChatDbSeeder(ChatDbContext context)
        {
            _context = context;
        }

        public async Task Ensure ()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
