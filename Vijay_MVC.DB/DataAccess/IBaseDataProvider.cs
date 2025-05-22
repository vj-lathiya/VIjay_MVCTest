using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitelytech.DB.DataAccess
{
    public interface IBaseDataProvider
    {
        Task<List<T>> GetData<T>(string SpName, object Parameters);
        Task<int> SaveData<T>(string SpName, T Parameters);
    }
}
