using Microsoft.EntityFrameworkCore;
using Shop.App.Abstracts;
using Shop.App.Mapper;
using Shop.App.Moduls;
using Shop.Domain.Entities;
using Shop.Domain.Enums;

namespace Shop.App.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;
        private readonly IGetPasswordHash _getPasswordHash;
        public UserService(IAppDbContext context, IGetPasswordHash getPasswordHash )
        {
            _context = context;
            _getPasswordHash = getPasswordHash;
        }
        public async Task<ViewUser> CreateAsync(CreateUser user)
        {
            if (await _context.Users.FirstOrDefaultAsync(x => x.Phone.Equals(user.Phone)) != null)
            {
                throw new Exception("User already exists");
            }

            User createduser = new User()
            {
                FullName = user.FullName,
                PasswordHash = _getPasswordHash.GetHash(user.Password),
                Phone = user.Phone,
                Balance = 1000,
                JoinedDate = DateTime.UtcNow,
                Role = user.Role ?? UserRole.User
            };

            ViewUser viewuser = new ViewUser()
            {
                FullName = createduser.FullName,
                Phone = createduser.Phone,
                JoinedDate = createduser.JoinedDate,
                Balance = createduser.Balance,
            };

            await _context.Users.AddAsync(createduser);
            await _context.SaveChangesAsync();
            return viewuser;
        }

        public async Task DeleteAsyncById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ViewUser>> GetAllAsync()
        {
            return await _context.Users.Select(x => new ViewUser
                    {
                        FullName= x.FullName,
                        Phone = x.Phone,
                        JoinedDate = x.JoinedDate,
                        Balance= x.Balance,
                    }).ToListAsync();
        }

        public async Task<ViewUser> GetUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var viewuser = new ViewUser()
            {
                FullName = user.FullName,
                Phone = user.Phone,
                JoinedDate = user.JoinedDate,
                Balance = user.Balance,
            };
            return viewuser;
        }

        public async Task<decimal> PayAsync(int id, decimal sum)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Balance = user.Balance+sum;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user.Balance;
        }
    }
}
