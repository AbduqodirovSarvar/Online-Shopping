using Shop.App.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Abstracts
{
    public interface IProductService
    {
        Task<ViewProduct> CreateAsync(CreateProduct product);
        Task DeleteAsyncById(int id);
        Task<ViewProduct> GetProductAsync(int id);
        Task<IEnumerable<ViewProduct>> GetAllAsync();
    }
}
