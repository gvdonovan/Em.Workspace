using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = Biff.Model;

namespace Biff.Services.Contracts
{
    public interface IBiffService
    {
        Task<IEnumerable<model.BiffObject>> GetAsync();
        //IEnumerable<model.BiffObject> Get();
    }
}
