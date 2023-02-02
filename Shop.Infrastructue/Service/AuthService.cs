using Microsoft.EntityFrameworkCore;
using Shop.App.Abstracts;
using Shop.Infrastructue.Abstracts;


namespace Shop.Infrastructue.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IGetPasswordHash _getpasswordhash;

        public AuthService(IAppDbContext db, ITokenService token, IGetPasswordHash getpasswordhash)
        {
            _context = db;
            _tokenService = token;
            _getpasswordhash = getpasswordhash;
        }
        public async Task<string> Login(string phone, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else if (user.PasswordHash != _getpasswordhash.GetHash(password))
            {
                throw new Exception("Phone or Password invalid");
            }
            return _tokenService.GetToken(user);
        }
    }
}
