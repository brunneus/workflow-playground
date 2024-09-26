using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowPlayground
{
    public class OrderWorflowData
    {
        public Guid OrderId { get; set; }
    }

    public class OrderWorkflow : IWorkflow<OrderWorflowData>
    {
        public string Id => "OrderProcessingWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<OrderWorflowData> builder)
        {
            builder
                .StartWith<CreateOrderStep>()
                .Then<CreatePaymentStep>()
                .Then<UpdateInventoryStep>()
                .Then<CreateShippingStep>()
                .Then<NotifyCostumerStep>();
        }
    }

    public class CreateOrderStep(ILogger<CreateOrderStep> logger) : StepBodyAsync
    {
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            logger.LogInformation("Creating order...");

            await Task.Delay(1000);

            return ExecutionResult.Next();
        }
    }

    public class CreatePaymentStep(ILogger<CreatePaymentStep> logger) : StepBodyAsync
    {
        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            logger.LogInformation("Creating payment...");

            await Task.Delay(2000);

            return ExecutionResult.Next();
        }
    }

    public class UpdateInventoryStep(ILogger<UpdateInventoryStep> logger) : StepBodyAsync
    {
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            logger.LogInformation("Updating inventory...");

            await Task.Delay(1000);

            return ExecutionResult.Next();
        }
    }

    public class CreateShippingStep(ILogger<CreateShippingStep> logger) : StepBodyAsync
    {
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            logger.LogInformation("Creating shipping...");

            await Task.Delay(400);

            return ExecutionResult.Next();
        }
    }

    public class NotifyCostumerStep(ILogger<NotifyCostumerStep> logger) : StepBodyAsync
    {
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            logger.LogInformation("Notifying customer...");

            await Task.Delay(800);

            return ExecutionResult.Next();
        }
    }
}