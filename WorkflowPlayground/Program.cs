using WorkflowCore.Interface;
using WorkflowPlayground;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddWorkflow(x =>
{
    x.UseSqlServer(@"Server=localhost,1433;Database=Workflow;User Id=sa;Password=pass@321;TrustServerCertificate=true;", true, true);
});
builder.Services.AddTransient<CreateOrderStep>();
builder.Services.AddTransient<CreatePaymentStep>();
builder.Services.AddTransient<UpdateInventoryStep>();
builder.Services.AddTransient<CreateShippingStep>();
builder.Services.AddTransient<NotifyCostumerStep>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.Services.GetRequiredService<IWorkflowHost>().RegisterWorkflow<OrderWorkflow, OrderWorflowData>();
app.Services.GetRequiredService<IWorkflowHost>().Start();

app.MapControllers();

app.Run();
