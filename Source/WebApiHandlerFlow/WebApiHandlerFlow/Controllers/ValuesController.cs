using System.Web.Http;
using WebApiHandlerFlow.Infrastructure;

namespace WebApiHandlerFlow.Controllers
{
    public class ValuesController : ApiController
    {
        public DeleteValueResponse Delete(DeleteValueRequest request)
        {
            var handler = new DeleteValueHandler();
            var response = handler.DoHandle(request);
            return response;
        }
    }
}
