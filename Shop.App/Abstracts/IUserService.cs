using Shop.App.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Abstracts
{
    public interface IUserService
    {
        Task<ViewUser> CreateAsync(CreateUser user);
        Task DeleteAsyncById(int id);
        Task<ViewUser> GetUserAsync(int id);
        Task<IEnumerable<ViewUser>> GetAllAsync();
        Task<decimal> PayAsync(int id, decimal sum);
    }
}
