using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijay_MVC.DB.Model;
using Vijay_MVC.DB.Repository;

namespace Vijay_MVC.DB.Service
{
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository userMasterRepository;

        public UserMasterService(IUserMasterRepository userMasterRepository)
        {
            this.userMasterRepository = userMasterRepository;
        }

        public async Task<ApiResponse> InsertUser(UserMaster userMaster)
        {
            ApiResponse apiData = new ApiResponse();
            try
            {
                var response = await userMasterRepository.InsertUser(userMaster);

                return apiData;

            }
            catch (Exception ex)
            {
                return apiData;
            }
        }

        public async Task<ApiResponse> GetUsers()
        {
            ApiResponse apiData = new ApiResponse();
            try
            {
                apiData = await userMasterRepository.GetUsers();
                return apiData;

            }
            catch (Exception ex)
            {
                return apiData;
            }
        }
    }
}
