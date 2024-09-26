using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;

namespace WorkflowPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost(Name = "PlaceOrder")]
        public async Task<object> Get([FromServices] IWorkflowHost workflowHost)
        {
            var workflowData = new OrderWorflowData { OrderId = Guid.NewGuid() };
            
            var result = await workflowHost.StartWorkflow(
                workflowId: "OrderProcessingWorkflow",
                data: workflowData,
                version: 1
            );

            return new { workflowId = result };
        }
    }
}