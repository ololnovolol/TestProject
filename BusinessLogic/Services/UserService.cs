using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAcessLayar.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<UserModel>> GetUsers() 
        {
            IQueryable<User> query = DataContext.Set<User>();
            var records = await query.ToListAsync();
            return records.Select(i => Mapper.Map<User, UserModel>(i));
        }
    }
}
