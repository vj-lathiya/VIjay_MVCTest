using Microsoft.AspNetCore.Mvc;
using Vijay_MVC.DB.Model;
using Vijay_MVC.DB.Service;

namespace Vijay_MVC.API.Controllers
{
    [Route("api/v1/Home")]
    [ApiController]

    public class HomeController : Controller
    {
        private IUserMasterService _usermasterService;
        public HomeController(IUserMasterService userMasterService)
        {
           _usermasterService = userMasterService;
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<ActionResult<ApiResponse>> InsertUser(UserMaster userMaster)
        {
            ApiResponse apiData = new ApiResponse();

            apiData = await _usermasterService.InsertUser(userMaster);
            return apiData;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<ApiResponse>> GetUsers()
        {
            ApiResponse apiData = new ApiResponse();

            apiData = await _usermasterService.GetUsers();
            return apiData;
        }
    }
}
