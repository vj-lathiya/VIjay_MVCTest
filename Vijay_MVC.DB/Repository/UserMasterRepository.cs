using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijay_MVC.DB.DataAccess;
using Vijay_MVC.DB.Model;
using Vitelytech.DB.DataAccess;

namespace Vijay_MVC.DB.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private IBaseDataProvider _baseDataProvider;
        public UserMasterRepository(IBaseDataProvider baseDataProvider)
        {
            _baseDataProvider = baseDataProvider;
        }

        #region Insert User Data
        public async Task<ApiResponse> InsertUser(UserMaster userMaster)
        {
            ApiResponse apiData = new ApiResponse();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@FirstName", userMaster.FirstName, DbType.String, size: 50, direction: ParameterDirection.Input);
                parameters.Add("@MiddleName", userMaster.MiddleName, DbType.String, size: 50, direction: ParameterDirection.Input);
                parameters.Add("@LastName", userMaster.LastName, DbType.String, size: 50, direction: ParameterDirection.Input);
                parameters.Add("@EmailId", userMaster.EmailId, DbType.String, size: 50, direction: ParameterDirection.Input);
                parameters.Add("@UserName", userMaster.UserName, DbType.String, size: 50, direction: ParameterDirection.Input);
                parameters.Add("@BirthDate", userMaster.BirthDate, DbType.String, size: 50, direction: ParameterDirection.Input);

                await _baseDataProvider.SaveData("SP_Insert_User", parameters);

                apiData.StatusCode = 200;
                apiData.Message = "User inserted successfully";
                apiData.Data = null;
            }
            catch (Exception ex)
            {
                apiData.StatusCode = 500;
                apiData.Message = "Error occurred while inserting user: " + ex.Message;
                apiData.Data = null;
            }
            return apiData;
        }
        #endregion

        #region Fetch User Data
        public async Task<ApiResponse> GetUsers()
        {
            ApiResponse apiData = new ApiResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                // Call SP to get user list
                var spResponse = await _baseDataProvider.GetData<UserMaster>("SP_GET_User_List", parameters);

                apiData.StatusCode = 200;
                apiData.Message = "User list fetched successfully";
                apiData.Data = spResponse;
            }
            catch (Exception ex)
            {
                apiData.StatusCode = 500;
                apiData.Message = "Error fetching user list: " + ex.Message;
                apiData.Data = null;
                
            }

            return apiData;
        }
        #endregion
    }
}
