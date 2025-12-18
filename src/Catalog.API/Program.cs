
var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("DbConnectionString")!);
}).UseLightweightSessions();

var app = builder.Build();

//Configure the HTTP request pepline
app.MapCarter();

app.Run();
