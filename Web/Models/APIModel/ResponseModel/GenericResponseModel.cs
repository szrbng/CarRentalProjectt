using System.Collections.Generic;

namespace Web.Models.APIModel.ResponseModel
{
    public class GenericResponseModel<T>
    {
        public List<T> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
