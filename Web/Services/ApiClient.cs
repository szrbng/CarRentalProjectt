

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models.APIModel.RequestModel;
using Web.Models.APIModel.ResponseModel;
using Web.Operations;
using Web.Services.Models;

namespace Web.Services
{
    public class ApiClient:BaseClientOperations
    {
        public ApiClient(HttpClient client,JsonSerializer  serializer):base(client,serializer)
        {

        }

        public async Task<GenericResponseModel<Brand>> GetBrands()
        {
            return await base.Get<GenericResponseModel<Brand>>($"/api/Brands/getall", null);
        }
        //public async Task<ApiResponseModel<object>> Login(LoginRequestModel model)
        //{

        //    return await base.Post<ApiResponseModel<object>, object>($"/api/Auth/login", model);
        //}
    }
}
