using models.mediator;
using models.memento;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<MessageHistory>();
builder.Services.AddSingleton<IChatMediator, ChatMediator>();
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Build the web host
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); 
});


var app = builder.Build();

// Middleware pipeline
app.UseCors("AllowAll");
app.UseRouting();
app.MapControllers();

app.Run();