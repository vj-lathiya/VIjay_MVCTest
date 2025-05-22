using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijay_MVC.DB.Model;

namespace Vijay_MVC.DB.Service
{
    public interface IUserMasterService
    {
        Task<ApiResponse> InsertUser(UserMaster userMaster);
        Task<ApiResponse> GetUsers();
    }
}
