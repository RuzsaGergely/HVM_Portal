using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class LoggerHelper
    {
        public HVMContext _dbContext;
        public LoggerHelper(HVMContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> CreateLog(string level, string message, string username, User? user = null)
        {
            await _dbContext.AddAsync(new Log()
            {
                LogMessage = $"[{level}] {message} - Username: '{username}'",
                Time = DateTime.Now,
                User = user
            });
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
