using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> GetUser()
        {
            return await _db.Users.Include(x => x.Orders).OrderByDescending(x => x.Orders.Count()).FirstAsync();
        }
        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.Where(x => x.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
