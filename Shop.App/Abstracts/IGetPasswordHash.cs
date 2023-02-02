using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Abstracts
{
    public interface IGetPasswordHash
    {
        string GetHash(string value);
    }
}
