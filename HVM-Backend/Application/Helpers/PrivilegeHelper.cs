using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class PrivilegeHelper
    {
        private HVMContext _dbContext;
        public PrivilegeHelper(HVMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckUserMeterRelation(int userid, int meterid)
        {
            return true;
        }

        public async Task<bool> CheckOperatorPrivilege(string userid)
        {
            var user = await _dbContext.Users.Where(x => x.Id == int.Parse(userid)).FirstOrDefaultAsync();
            return user == null ? false : user.IsOperator;
        }
    }
}
