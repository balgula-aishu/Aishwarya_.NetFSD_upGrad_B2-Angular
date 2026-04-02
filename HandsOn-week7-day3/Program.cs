using Contact_Management_App.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add MVC services
builder.Services.AddControllersWithViews();

// ✅ Register DI Service
builder.Services.AddSingleton<IContactService, ContactService>();

var app = builder.Build();

// ✅ Fix bracket issue
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

// ✅ Map Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

app.Run();
