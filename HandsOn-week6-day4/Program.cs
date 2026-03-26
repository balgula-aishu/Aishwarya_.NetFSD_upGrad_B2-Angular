var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//this handles requests to the home url "/"
app.MapGet("/", () => "Welcome to My First ASP.NET Core App");

app.Run();
