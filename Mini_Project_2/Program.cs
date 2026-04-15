using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<SpeakerService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Common}/{action=Home}/{id?}");

app.Run();
